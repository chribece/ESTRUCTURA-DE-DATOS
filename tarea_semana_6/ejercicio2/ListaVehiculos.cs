using System;

namespace ProyectoEstacionamiento.Models
{

    // Clase que implementa una lista enlazada simple para almacenar vehículos.
 
    public class ListaVehiculos
    {
        // Puntero al primer nodo de la lista (cabeza)
        private NodoVehiculo? cabeza;  // Puede ser null si la lista está vacía

     
        // Constructor que inicializa una lista vacía
     
        public ListaVehiculos()
        {
            cabeza = null;  // Lista comienza vacía
        }

      
        // Agrega un nuevo vehículo al final de la lista
      
        public void AgregarVehiculo(string placa, string marca, string modelo, int año, decimal precio)
        {
            // Validación de datos de entrada
            if (string.IsNullOrWhiteSpace(placa))
                throw new ArgumentException("La placa no puede estar vacía", nameof(placa));
            
            // Creación del nuevo nodo
            NodoVehiculo nuevoNodo = new NodoVehiculo(placa, marca, modelo, año, precio);

            // Caso 1: Lista vacía - el nuevo nodo se convierte en la cabeza
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                return;
            }

            // Caso 2: Lista no vacía - recorremos hasta el último nodo
            NodoVehiculo actual = cabeza;
            while (actual.Siguiente != null)  // Buscamos el último nodo
            {
                actual = actual.Siguiente;
            }
            
            // Enlazamos el nuevo nodo al final de la lista
            actual.Siguiente = nuevoNodo;
        }

        // Busca un vehículo por su placa (retorna null si no se encuentra)
      
        public NodoVehiculo? BuscarPorPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa))
                return null;

            // Recorremos la lista desde la cabeza
            NodoVehiculo? actual = cabeza;
            while (actual != null)
            {
                // Comparamos las placas (ignorando mayúsculas/minúsculas)
                if (actual.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase))
                {
                    return actual;  // Nodo encontrado
                }
                actual = actual.Siguiente;  // Avanzamos al siguiente nodo
            }
            
            return null;  // No se encontró el vehículo
        }

     
        // Muestra todos los vehículos de un año específico

        public void MostrarPorAño(int año)
        {
            NodoVehiculo? actual = cabeza;
            bool encontrado = false;

            Console.WriteLine($"\nVehículos del año {año}:");
            
            // Recorremos toda la lista
            while (actual != null)
            {
                if (actual.Año == año)
                {
                    MostrarVehiculo(actual);  // Mostramos coincidencias
                    encontrado = true;
                }
                actual = actual.Siguiente;
            }

            if (!encontrado)
            {
                Console.WriteLine($"No se encontraron vehículos del año {año}.");
            }
        }

        
        // Muestra todos los vehículos en la lista
    
        public void MostrarTodos()
        {
            if (cabeza == null)
            {
                Console.WriteLine("\nNo hay vehículos registrados.");
                return;
            }

            Console.WriteLine("\nLista de todos los vehículos registrados:");
            NodoVehiculo? actual = cabeza;
            
            // Recorrido secuencial de la lista
            while (actual != null)
            {
                MostrarVehiculo(actual);
                actual = actual.Siguiente;
            }
        }

      
        // Elimina un vehículo por su placa
            public bool EliminarVehiculo(string placa)
        {
            // Validaciones iniciales
            if (string.IsNullOrWhiteSpace(placa) || cabeza == null)
                return false;

            // Caso 1: El nodo a eliminar es la cabeza
            if (cabeza.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase))
            {
                cabeza = cabeza.Siguiente;  // La nueva cabeza es el siguiente nodo
                return true;
            }

            // Caso 2: Buscar el nodo en el resto de la lista
            NodoVehiculo? actual = cabeza;
            while (actual.Siguiente != null)
            {
                if (actual.Siguiente.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase))
                {
                    // "Saltamos" el nodo a eliminar
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    return true;
                }
                actual = actual.Siguiente;
            }

            return false;  // No se encontró el vehículo
        }

      
        // Método auxiliar para mostrar los datos de un vehículo
  
        private void MostrarVehiculo(NodoVehiculo vehiculo)
        {
            Console.WriteLine($"Placa: {vehiculo.Placa}");
            Console.WriteLine($"Marca: {vehiculo.Marca}");
            Console.WriteLine($"Modelo: {vehiculo.Modelo}");
            Console.WriteLine($"Año: {vehiculo.Año}");
            Console.WriteLine($"Precio: {vehiculo.Precio:C}");
            Console.WriteLine("-----------------------------");
        }
    }
}