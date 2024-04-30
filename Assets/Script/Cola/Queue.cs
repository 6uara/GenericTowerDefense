using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Queue<T> : IQueue<T>
{
    private int indice;
    private bool inicializado = false;
    private T[] array;

    public void Acolar(T elemento)
    {
        if (inicializado)
        {
            if (indice == array.Length - 1)
            {
                throw new Exception("La cola está completa");
            }

            for (int i = indice; i > 0; i--)
            {
                array[i] = array[i - 1];
            }

            array[0] = elemento;
            indice++;
        }
        else
        {
            throw new Exception("Cola no inicializada");
        }
    }

    public bool ColaVacia()
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
            throw new Exception("Cola no inicializada");
        }
    }

    public T Desacolar()
    {
        if (inicializado)
        {
            if (indice != 0)
            {
                array[indice - 1] = default;
                T res = array[indice - 1];
                indice--;
                return res;
            }
            else
            {
                throw new Exception("La cola está vacía");
            }
        }
        else
        {
            throw new Exception("Cola no inicializada");
        }
    }

    public void InicializarCola(int cantidad)
    {
        array = new T[cantidad];
        indice = 0;
        inicializado = true;
    }

    public T Primero()
    {
        if (indice != 0)
        {
            return array[indice - 1];
        }
        else
        {
            throw new Exception("La cola no contiene ningun valor");
        }
    }
}
