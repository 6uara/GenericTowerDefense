using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrafo
    {
        void InicializarGrafo();
        void AgregarVertice(GameObject v);
        void EliminarVertice(GameObject v);
        //ConjuntoTDA Vertices();
        void AgregarArista(int id, GameObject v1, GameObject v2, int peso);
        void EliminarArista(GameObject v1, GameObject v2);
        bool ExisteArista(GameObject v1, GameObject v2);
        int PesoArista(GameObject v1, GameObject v2);
    }
