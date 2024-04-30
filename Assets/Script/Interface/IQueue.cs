using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQueue<T>
{
    void InicializarCola(int cantidad);
    void Acolar(T elemento);
    void Desacolar();
    T Primero();
    bool ColaVacia();
}
