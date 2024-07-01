using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDManager : MonoBehaviour
{
    public Grafo grafo;

    public static GDManager Instance;

    private void Awake() 
    {
        if(Instance != null)
        {
            Destroy(this);
        }else{
            Instance = this;
        }
    }

    void Start()
    {
        InitializeGraph();
    }

    void InitializeGraph()
    {
        grafo = new Grafo();
        grafo.InicializarGrafo();//Inicializa el Grafo

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Waypoint");//Agarra todos los GameObject con Tag "Waypoint" y los añade como vertices
        foreach (GameObject waypoint in waypoints)
        {
            grafo.AgregarVertice(waypoint);
        }
        for (int i = 0; i < grafo.cantNodos; i++)// Añade las aristas a los waypoints basado en proximidad (revisar)
        {
            GameObject v1 = grafo.Etiqs[i];
            for (int j = 0; j < grafo.cantNodos; j++)
            {
                GameObject v2 = grafo.Etiqs[j];
                if (v1 != v2 && v1.CompareTag("Waypoint") && v2.CompareTag("Waypoint"))
                {

                    if (CheckEdge(v1, v2))//Chequear si hay conexion directa entre v1 y v2 , osea si hay arista entre v1 y v2
                    {
                        int weight = CalculateEdgeWeight(v1, v2);//calcula el peso de la arista
                        grafo.AgregarArista(0, v1, v2, weight); // Añade la arista al Grafo con id0
                    }
                }
            }
        }
    }

    bool CheckEdge(GameObject v1, GameObject v2)
    {
        float distance = Vector3.Distance(v1.transform.position, v2.transform.position);
        if (distance <= 5f) // Example: if within 5 units
        {
            return true;
        }
        return false;
    }

    int CalculateEdgeWeight(GameObject v1, GameObject v2)
    {
        return (int)Vector3.Distance(v1.transform.position, v2.transform.position);
    }
}
