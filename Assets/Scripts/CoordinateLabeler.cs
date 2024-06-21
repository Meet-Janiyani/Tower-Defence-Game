using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
 
[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor =Color.white;
    [SerializeField] Color blockedColor =Color.gray;
    [SerializeField] Color exploredColor =Color.yellow;
    [SerializeField] Color pathColor =new Color(1f,0.5f,0f);

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    GridManager gridManager;

    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        DisplayCoordinates();
    }
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
            label.enabled=true;
        }

        ToggleLabels();
        ColorCoordinates();
    }

    private void DisplayCoordinates()
    {
        coordinates.x = (int)(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = (int)(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.y);
        label.text = coordinates.x.ToString()+","+coordinates.y.ToString();
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }

    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.C)) 
        {
            label.enabled = !label.IsActive();
        }
    }

    void ColorCoordinates()
    {
        if (gridManager==null)
        {
            return;
        }

        Node node = gridManager.GetNode(coordinates);

        if (node == null)
        {
            return;
        }

        if (!node.isWalkable)
        {
            label.color = blockedColor;
        }else if (node.isPath)
        {
            label.color = pathColor;
        }else if (node.isExplored)
        {
            label.color = exploredColor;
        }
        else
        {
            label.color = defaultColor;
        }
    }
}
