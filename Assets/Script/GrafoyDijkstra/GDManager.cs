using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDManager : MonoBehaviour
{
    public Grafo grafo;
    public GameObject startWaypoint; // Starting waypoint

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
        //print("MAdy");
        //grafo.PrintMatrix(grafo.MAdy);
        print("Mid");
        grafo.PrintMatrix(grafo.MId);
        //print("Cantidad de Nodos:");
        //print(grafo.cantNodos);
        //print("etiqs");
        //for(int i=0;i< grafo.Etiqs.Length;i++)
        //{
            //print("Etiqs index "+i+" = "+ grafo.Etiqs[i]);
        //}
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
        GameObject[] Edges = GameObject.FindGameObjectsWithTag("Edge");
        foreach(GameObject edge in Edges)
        {
            AristaScript arista = edge.GetComponent<AristaScript>();
            print(edge);
            if (arista != null)
            {
                grafo.AgregarArista(4, arista.Vertice1, arista.Vertice2, arista.Weight);
            }

        }
    }
}
