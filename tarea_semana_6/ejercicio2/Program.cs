using System;
using ProyectoEstacionamiento.Models;

namespace ProyectoEstacionamiento
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaVehiculos estacionamiento = new ListaVehiculos();
            bool salir = false;

            while (!salir)
            {
                MostrarMenu();
                string? opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarVehiculo(estacionamiento);
                        break;
                    case "2":
                        BuscarVehiculo(estacionamiento);
                        break;
                    case "3":
                        MostrarPorAño(estacionamiento);
                        break;
                    case "4":
                        estacionamiento.MostrarTodos();
                        break;
                    case "5":
                        EliminarVehiculo(estacionamiento);
                        break;
                    case "6":
                        salir = true;
                        Console.WriteLine("\nSaliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("\nOpción no válida. Por favor, intente nuevamente.");
                        break;
                }
            }
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\nSistema de Registro de Vehículos - Área de Ingeniería de Sistemas");
            Console.WriteLine("1. Agregar vehículo");
            Console.WriteLine("2. Buscar vehículo por placa");
            Console.WriteLine("3. Ver vehículos por año");
            Console.WriteLine("4. Ver todos los vehículos registrados");
            Console.WriteLine("5. Eliminar vehículo registrado");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
        }

        static void AgregarVehiculo(ListaVehiculos estacionamiento)
        {
            try
            {
                Console.Write("\nIngrese la placa del vehículo: ");
                string? placa = Console.ReadLine();
                Console.Write("Ingrese la marca del vehículo: ");
                string? marca = Console.ReadLine();
                Console.Write("Ingrese el modelo del vehículo: ");
                string? modelo = Console.ReadLine();
                Console.Write("Ingrese el año del vehículo: ");
                int año = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Ingrese el precio del vehículo: ");
                decimal precio = decimal.Parse(Console.ReadLine() ?? "0");

                estacionamiento.AgregarVehiculo(
                    placa ?? throw new InvalidOperationException("La placa es requerida"),
                    marca ?? throw new InvalidOperationException("La marca es requerida"),
                    modelo ?? throw new InvalidOperationException("El modelo es requerido"),
                    año,
                    precio);

                Console.WriteLine("\nVehículo registrado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }

        static void BuscarVehiculo(ListaVehiculos estacionamiento)
        {
            Console.Write("\nIngrese la placa del vehículo a buscar: ");
            string? placaBuscar = Console.ReadLine();
            NodoVehiculo? encontrado = estacionamiento.BuscarPorPlaca(placaBuscar ?? string.Empty);

            if (encontrado != null)
            {
                Console.WriteLine("\nVehículo encontrado:");
                Console.WriteLine($"Placa: {encontrado.Placa}");
                Console.WriteLine($"Marca: {encontrado.Marca}");
                Console.WriteLine($"Modelo: {encontrado.Modelo}");
                Console.WriteLine($"Año: {encontrado.Año}");
                Console.WriteLine($"Precio: {encontrado.Precio:C}");
            }
            else
            {
                Console.WriteLine("\nNo se encontró ningún vehículo con esa placa.");
            }
        }

        static void MostrarPorAño(ListaVehiculos estacionamiento)
        {
            try
            {
                Console.Write("\nIngrese el año para filtrar los vehículos: ");
                int añoFiltrar = int.Parse(Console.ReadLine() ?? "0");
                estacionamiento.MostrarPorAño(añoFiltrar);
            }
            catch (FormatException)
            {
                Console.WriteLine("\nError: Por favor ingrese un año válido.");
            }
        }

        static void EliminarVehiculo(ListaVehiculos estacionamiento)
        {
            Console.Write("\nIngrese la placa del vehículo a eliminar: ");
            string? placaEliminar = Console.ReadLine();
            bool eliminado = estacionamiento.EliminarVehiculo(placaEliminar ?? string.Empty);

            if (eliminado)
            {
                Console.WriteLine("\nVehículo eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("\nNo se encontró ningún vehículo con esa placa.");
            }
        }
    }
}