using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra
{
    public static int[] ShortestPath(int[,] graph, int start)
    {
        int verticesCount = graph.GetLength(0);
        int[] distances = new int[verticesCount];
        bool[] visited = new bool[verticesCount];

        for (int i = 0; i < verticesCount; i++)
        {
            distances[i] = int.MaxValue;
            visited[i] = false;
        }

        distances[start] = 0;

        for (int count = 0; count < verticesCount - 1; count++)
        {
            int u = MinimumDistance(distances, visited);
            visited[u] = true;

            for (int v = 0; v < verticesCount; v++)
            {
                if (!visited[v] && graph[u, v] != 0 && distances[u] != int.MaxValue &&
                    distances[u] + graph[u, v] < distances[v])
                {
                    distances[v] = distances[u] + graph[u, v];
                }
            }
        }

        return distances;
    }

    private static int MinimumDistance(int[] distances, bool[] visited)
    {
        int min = int.MaxValue;
        int minIndex = -1;

        for (int v = 0; v < distances.Length; v++)
        {
            if (!visited[v] && distances[v] <= min)
            {
                min = distances[v];
                minIndex = v;
            }
        }

        return minIndex;
    }
}
