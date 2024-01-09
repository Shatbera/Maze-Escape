using System.Collections.Generic;
using System;
using UnityEngine;

public class Maze : MonoBehaviour
{
    [SerializeField] private GameObject m_WallPF; //change with object pooler
    [SerializeField] private Transform m_WallsParent;
    private readonly List<GameObject> m_Walls = new List<GameObject>();

    private static int wallLength = 6;
    [ContextMenu("Generate Maze")]
    public void GenerateMaze()
    {
        CleanWalls();

        List<WallPoint> wallPoints = MazeGenerator.Generate(8);
        foreach(var pt in wallPoints)
        {
            CreateWall(pt);
        }  
    }

    private void CreateWall(WallPoint wallPoint)
    {
        var point_a = wallPoint.point_a;
        var point_b = wallPoint.point_b;
        Vector3 position_a = transform.position + new Vector3(point_a.Item1 * wallLength, 0, point_a.Item2 * wallLength);
        Vector3 position_b = transform.position + new Vector3(point_b.Item1 * wallLength, 0, point_b.Item2 * wallLength);

        Vector3 midPoint = (position_a + position_b) * 0.5f;

        Quaternion rotation = Quaternion.LookRotation(position_b - position_a, Vector3.up);

        GameObject wall = Instantiate(m_WallPF, midPoint, rotation, m_WallsParent);

        float distance = Vector3.Distance(position_a, position_b);
        wall.transform.localScale = new Vector3(distance, wall.transform.localScale.y, wall.transform.localScale.z);

        m_Walls.Add(wall);
    }

    [ContextMenu("Clear Maze")]
    private void CleanWalls()
    {
        for(int i = 0; i < m_Walls.Count; i++)
        {
            if (Application.isPlaying)
            {
                Destroy(m_Walls[i]);
            }
            else
            {
                DestroyImmediate(m_Walls[i]);
            }
        }
        m_Walls.Clear();
    }
}
