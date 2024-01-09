using System;
using System.Collections.Generic;
using UnityEngine;

public class WallPoint
{
    public Tuple<int, int> point_a;
    public Tuple<int, int> point_b;
    public WallPoint(Tuple<int, int> point_a, Tuple<int, int> point_b)
    {
        this.point_a = point_a;
        this.point_b = point_b;
    }
}
public class MazeGenerator : MonoBehaviour
{
    
    public static List<WallPoint> Generate(int n)
    {
        List<Tuple<int, int>> vertexes = new List<Tuple<int, int>>();
        List<Tuple<int, int>> allEdges = new List<Tuple<int, int>>();
        List<Tuple<int, int>> wallEdges = new List<Tuple<int, int>>();


        //fill vertexes
        for (int i = 0; i < n; i++)
        {
            for(int j = 0; j < n; j++)
            {
                vertexes.Add(Tuple.Create(i, j));
            }
        }


        //assign initial colors
        List<int> colors = new List<int>();
        for (int i = 0; i < n * n; i++)
        {
            colors.Add(i + 1);
        }

        //insert all edges
        for (int i = 0; i < vertexes.Count; i++)
        {
            int row = vertexes[i].Item1;
            int col = vertexes[i].Item2;

            if (col + 1 < n)
            {
                allEdges.Add(Tuple.Create(i, i + 1));
            }

            if (row + 1 < n)
            {
                allEdges.Add(Tuple.Create(i, i + n));
            }
        }

        //shuffle edges
        for (int i = 0; i < allEdges.Count; i++)
        {
            Tuple<int, int> temp = allEdges[i];
            int randomIndex = UnityEngine.Random.Range(i, allEdges.Count);
            allEdges[i] = allEdges[randomIndex];
            allEdges[randomIndex] = temp;
        }


        //generate maze
        for (int i = 0; i < allEdges.Count; i++)
        {
            var edge = allEdges[i];
            if (colors[edge.Item1] != colors[edge.Item2])
            {
                int color1 = colors[edge.Item1];
                int color2 = colors[edge.Item2];

                for (int j = 0; j < n * n; j++)
                {
                    if (colors[j] == color1)
                    {
                        colors[j] = color2;
                    }
                }
            }
            else
            {
                wallEdges.Add(edge);
            }     
        }


        List<WallPoint> wallPoints = new();
        foreach (var edge in wallEdges)
        {
            wallPoints.Add(new WallPoint(vertexes[edge.Item1], vertexes[edge.Item2]));
        }

        return wallPoints;
    }
}
