using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Tower DefenseTower;
    [SerializeField] bool isPlaceable=true; 
    public bool IsPlaceable { get { return isPlaceable; } }

    public bool getIsPlaceable()
    {
        return isPlaceable; 
    }

 
    void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced=DefenseTower.CreateTower(DefenseTower,transform.position);
            isPlaceable = !isPlaced;
        }
    }
}
