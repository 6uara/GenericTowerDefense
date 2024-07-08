using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConjuntoTD
{
        void InicializarConjunto();
        bool ConjuntoVacio();
        void Agregar(GameObject x);
        GameObject Elegir();
        void Sacar(GameObject x);
        bool Pertenece(GameObject x);
    
}
