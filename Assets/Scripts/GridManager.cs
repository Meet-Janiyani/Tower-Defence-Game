using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    Dictionary<Vector2Int,Node> grid=new Dictionary<Vector2Int,Node>();
    [SerializeField] Vector2Int gridSize;

    public Dictionary<Vector2Int, Node> Grid { get => grid; }

    void Awake()
    {
        CreateGrid();    
    }

    public Node GetNode(Vector2Int coordinates)
    {
        if (Grid.ContainsKey(coordinates))
        {
            return Grid[coordinates];
        }
        return null;
    }

    public void CreateGrid()
    {
        for(int x = 0; x < gridSize.x; x++)
        {
            for(int y=0; y<gridSize.y; y++)
            {
                Grid.Add(new Vector2Int(x, y), new Node(new Vector2Int(x, y), true));
            }
        }
    }
}
