using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConjuntoTD : IConjuntoTD
    {
        GameObject[] a;
        int cant;

        public void Agregar(GameObject x)
        {
            if (!this.Pertenece(x))
            {
                a[cant] = x;
                cant++;
            }
        }

        public bool ConjuntoVacio()
        {
            return cant == 0;
        }

        public GameObject Elegir()
        {
            return a[cant - 1];
        }

        public void InicializarConjunto()
        {
            a = new GameObject[100];
            cant = 0;
        }

        public bool Pertenece(GameObject x)
        {
            int i = 0;
            while (i < cant && a[i] != x)
            {
                i++;
            }
            return (i < cant);
        }

        public void Sacar(GameObject x)
        {
            int i = 0;
            while (i < cant && a[i] != x)
            {
                i++;
            }
            if (i < cant)
            {
                a[i] = a[cant - 1];
                cant--;
            }
        }
    }
