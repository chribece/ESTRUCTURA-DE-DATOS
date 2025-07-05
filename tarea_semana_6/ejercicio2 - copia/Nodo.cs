// Clase Nodo: representa un elemento de la lista
class Nodo
{
    public Vehiculo Vehiculo{ get; set; }
    public Nodo Siguiente{ get; set; }      // Referencia al siguiente nodo

    // Constructor que inicializa el nodo con un valor
    public Nodo(Vehiculo vehiculo)
    {
        Vehiculo = vehiculo;
        Siguiente = null;      // Por defecto, el siguiente nodo es null
    }
}