using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    private int V;
    private List<List<int>> adj;

    public Graph(int v)
    {
        V = v;
        adj = new List<List<int>>(v);
        for (int i = 0; i < v; ++i)
        {
            adj.Add(new List<int>());
        }
    }

    public void AddEdge(int v, int w)
    {
        adj[v].Add(w);
    }

 /*   public void BFS(int s)
    {
        bool[] visited = new bool[V];
        Queue<int> queue = new Queue<int>();

        visited[s] = true;
        queue.Enqueue(s);

        while (queue.Count != 0)
        {
            s = queue.Dequeue();
            Console.Write(s + " ");

            foreach (int i in adj[s])
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    queue.Enqueue(i);
                }
            }
        }
    }*/
}

