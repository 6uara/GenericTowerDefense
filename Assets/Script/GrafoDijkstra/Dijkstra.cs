using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Dijkstra : MonoBehaviour
{
    public static int[] distance;
    public static string[] nodos;

    private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
    {
        int min = int.MaxValue;
        int minIndex = 0;

        for (int v = 0; v < verticesCount; ++v)
        {
            if (shortestPathTreeSet[v] == false && distance[v] <= min)
            {
                min = distance[v];
                minIndex = v;
            }
        }

        return minIndex;
    }

    public static void Dijks(Grafo grafo, GameObject source)
    {
        int verticesCount = grafo.cantNodos;

        // Convert GameObject source to its corresponding index in Etiqs array
        int sourceIndex = grafo.Vert2Indice(source);

        // Get adjacency matrix from Grafo
        int[,] graph = grafo.MAdy;

        // Initialize distances and path tracking arrays
        distance = new int[verticesCount];
        bool[] shortestPathTreeSet = new bool[verticesCount];
        GameObject[] nodos1 = new GameObject[verticesCount];
        GameObject[] nodos2 = new GameObject[verticesCount];

        for (int i = 0; i < verticesCount; ++i)
        {
            distance[i] = int.MaxValue;
            shortestPathTreeSet[i] = false;
            nodos1[i] = nodos2[i] = null;
        }

        // Distance to source vertex is 0
        distance[sourceIndex] = 0;
        nodos1[sourceIndex] = nodos2[sourceIndex] = grafo.Etiqs[sourceIndex];

        // Find shortest path for all vertices
        for (int count = 0; count < verticesCount - 1; ++count)
        {
            int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
            shortestPathTreeSet[u] = true;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (!shortestPathTreeSet[v] && graph[u, v] != 0 && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                {
                    distance[v] = distance[u] + graph[u, v];
                    nodos1[v] = grafo.Etiqs[u];
                    nodos2[v] = grafo.Etiqs[v];
                }
            }
        }

        // Build path of nodes
        nodos = new string[verticesCount];
        GameObject nodOrig = grafo.Etiqs[sourceIndex];
        for (int i = 0; i < verticesCount; i++)
        {
            if (nodos1[i] != null)
            {
                List<GameObject> l1 = new List<GameObject>();
                l1.Add(nodos1[i]);
                l1.Add(nodos2[i]);
                while (l1[0] != nodOrig)
                {
                    for (int j = 0; j < verticesCount; j++)
                    {
                        if (j != sourceIndex && l1[0] == nodos2[j])
                        {
                            l1.Insert(0, nodos1[j]);
                            break;
                        }
                    }
                }
                for (int j = 0; j < l1.Count; j++)
                {
                    if (j == 0)
                    {
                        nodos[i] = l1[j].name;
                    }
                    else
                    {
                        nodos[i] += "," + l1[j].name;
                    }
                }
            }
        }
    }
}

