public interface IStack<T>
{
    void InicializarPila(int cantidad);
    void Apilar(T elemento);
    void Desapilar();
    T Tope();
    bool PilaVacia();
}
