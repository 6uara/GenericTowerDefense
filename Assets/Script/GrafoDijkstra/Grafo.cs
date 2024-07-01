using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grafo : MonoBehaviour,IGrafo
{
    static int n = 100;
    public int[,] MAdy;
    public int[,] MId;
    public GameObject[] Etiqs;
    public int cantNodos;

    public void InicializarGrafo()
    {
        MAdy = new int[n, n];
        MId = new int[n, n];
        Etiqs = new GameObject[n];
        cantNodos = 0;
    }
    public void AgregarVertice(GameObject v)
    {
        Etiqs[cantNodos] = v;
        for (int i = 0; i <= cantNodos; i++)
        {
            MAdy[cantNodos, i] = 0;
            MAdy[i, cantNodos] = 0;
        }
        cantNodos++;
        //print(cantNodos);
    }
    public void EliminarVertice(GameObject v)
    {
        int ind = Vert2Indice(v);

        for (int k = 0; k < cantNodos; k++)
        {
            MAdy[k, ind] = MAdy[k, cantNodos - 1];
        }

        for (int k = 0; k < cantNodos; k++)
        {
            MAdy[ind, k] = MAdy[cantNodos - 1, k];
        }

        Etiqs[ind] = Etiqs[cantNodos - 1];
        cantNodos--;
    }
    public int Vert2Indice(GameObject v)
    {
        int i = cantNodos - 1;
        while (i >= 0)
        {
            if(Etiqs[i] != null && Etiqs[i] == v)
            {
                return i;
            }else{
                if(i>0){
                    i--;
                }
            }
        }

        return i;
    }
    public void AgregarArista(int id, GameObject v1, GameObject v2, int peso)
    {
        int o = Vert2Indice(v1);
        int d = Vert2Indice(v2);
        MAdy[o, d] = peso;
        MId[o, d] = id;
    }
    public void EliminarArista(GameObject v1, GameObject v2)
    {
        int o = Vert2Indice(v1);
        int d = Vert2Indice(v2);
        MAdy[o, d] = 0;
        MId[o, d] = 0;
    }
    public bool ExisteArista(GameObject v1, GameObject v2)
    {
        int o = Vert2Indice(v1);
        int d = Vert2Indice(v2);
        return MAdy[o, d] != 0;
    }
    public int PesoArista(GameObject v1, GameObject v2)
    {
        int o = Vert2Indice(v1);
        int d = Vert2Indice(v2);
        return MAdy[o, d];
    }
}