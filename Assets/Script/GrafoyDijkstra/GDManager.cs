using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDManager : MonoBehaviour
{
    public Grafo grafo;
    public GameObject startWaypoint; // Starting waypoint
    public GameObject[] Vertices;
    public GameObject[] Aristas;

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
        //print("Mid");
        //grafo.PrintMatrix(grafo.MId);
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

        for (int i=0; i< Vertices.Length;i++)
        {
            grafo.AgregarVertice(Vertices[i]);
        }
        for(int i=0; i< Aristas.Length;i++)
        {
            AristaScript arista = Aristas[i].GetComponent<AristaScript>();
            if (arista != null)
            {
                grafo.AgregarArista(4, arista.Vertice1, arista.Vertice2, arista.Weight);
            }

        }
    }
}
