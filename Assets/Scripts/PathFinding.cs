using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    [SerializeField] Node currentSearchNode;
    Vector2Int[] Direction = {Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid;
    // Start is called before the first frame update
    void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();    
        if(gridManager != null)
        {
            grid = gridManager.Grid;
        }
    }


    void Start()
    {
        ExploringNeighbours();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExploringNeighbours()
    {
        List<Node> neighbours= new List<Node>();

        foreach(Vector2Int direction in Direction) 
        {
            Vector2Int neighbourCoordinates=currentSearchNode.coordinates+direction;
            
            if(grid.ContainsKey(neighbourCoordinates))
            {
                neighbours.Add(grid[neighbourCoordinates]);
                grid[neighbourCoordinates].isExplored=true;
                grid[currentSearchNode.coordinates].isPath = true;
            }
        }
    }
}
