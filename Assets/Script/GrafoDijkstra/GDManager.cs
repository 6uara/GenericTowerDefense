using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDManager : MonoBehaviour
{
    public Grafo grafo;

    void Start()
    {
        InitializeGraph();
    }

    void InitializeGraph()
    {
        // Initialize the graph instance
        grafo.InicializarGrafo();

        // Find all GameObjects with tag "Waypoint" and add them as vertices
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        foreach (GameObject waypoint in waypoints)
        {
            grafo.AgregarVertice(waypoint);
        }

        // Add edges between waypoints based on adjacency or proximity
        for (int i = 0; i < grafo.cantNodos; i++)
        {
            GameObject v1 = grafo.Etiqs[i];
            for (int j = 0; j < grafo.cantNodos; j++)
            {
                GameObject v2 = grafo.Etiqs[j];
                if (v1 != v2 && v1.CompareTag("Waypoint") && v2.CompareTag("Waypoint"))
                {
                    // Check if there's a direct connection (edge) between v1 and v2
                    if (CheckEdge(v1, v2))
                    {
                        // Calculate distance or weight for the edge (optional)
                        int weight = CalculateEdgeWeight(v1, v2);

                        // Add the edge to the graph
                        grafo.AgregarArista(0, v1, v2, weight); // Assuming id=0 for simplicity
                    }
                }
            }
        }
    }

    bool CheckEdge(GameObject v1, GameObject v2)
    {
        // Placeholder method to check if there's an edge between v1 and v2.
        // Example: check if v1 and v2 are within a certain distance (pathfinding range).
        float distance = Vector3.Distance(v1.transform.position, v2.transform.position);
        if (distance <= 5f) // Example: if within 5 units
        {
            return true;
        }
        return false;
    }

    int CalculateEdgeWeight(GameObject v1, GameObject v2)
    {
        // Placeholder method to calculate the weight or distance of an edge between v1 and v2.
        // Example: use actual distance between waypoints as edge weight.
        return (int)Vector3.Distance(v1.transform.position, v2.transform.position);
    }
}
