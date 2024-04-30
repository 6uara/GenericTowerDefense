using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stack<T> : IStack<T>
{
    private int indice;
    private bool inicializado = false;
    private T[] array;

    public void Apilar(T elemento)
    {
        if (inicializado)
        {
            array[indice] = elemento;
            indice++;
        }
        else
        {
            throw new Exception("Pila no inicializada");
        }
    }

    public void Desapilar()
    {
        if (inicializado)
        {
            if (indice != 0)
            {
                array[indice] = default;
                indice--;
            }
            else
            {
                throw new Exception("La pila no contiene ningun valor");
            }
        }
        else
        {
            throw new Exception("Pila no inicializada");
        }
    }

    public void InicializarPila(int cantidad)
    {
        array = new T[cantidad];
        indice = 0;
        inicializado = true;
    }

    public bool PilaVacia()
    {
        if (inicializado)
        {
            if (indice != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            throw new Exception("Pila no inicializada");
        }
    }

    public T Tope()
    {
        if (indice != 0)
        {
            return array[indice-1];
        }
        else
        {
            throw new Exception("La pila no contiene ningun valor");
        }
    }
}
