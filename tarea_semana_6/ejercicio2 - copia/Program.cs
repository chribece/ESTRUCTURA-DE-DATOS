using System;
using Estacionamiento;
namespace Estacionamiento
{

    class Program
    {
        static void Main(string[] args)
        {
            ListaEnlazada estacionamiento = new ListaEnlazada();
            string opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("=== Estacionamiento - Área de Ingeniería de Sistemas ===");
                Console.WriteLine("1. Agregar vehículo");
                Console.WriteLine("2. Buscar vehículo por placa");
                Console.WriteLine("3. Ver vehículos por año");
                Console.WriteLine("4. Ver todos los vehículos");
                Console.WriteLine("5. Eliminar vehículo por placa");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarVehiculo(estacionamiento);
                        break;
                    case "2":
                        BuscarPorPlaca(estacionamiento);
                        break;
                    case "3":
                        VerPorAnio(estacionamiento);
                        break;
                    case "4":
                        estacionamiento.VerTodos();
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case "5":
                        EliminarPorPlaca(estacionamiento);
                        break;
                    case "6":
                        Console.WriteLine("Saliendo del sistema. ¡Gracias!");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }

            } while (opcion != "6");
        }

        static void AgregarVehiculo(ListaEnlazada lista)
        {
            Console.Write("Ingrese la placa: ");
            string placa = Console.ReadLine();
            Console.Write("Ingrese la marca: ");
            string marca = Console.ReadLine();
            Console.Write("Ingrese el modelo: ");
            string modelo = Console.ReadLine();
            Console.Write("Ingrese el año: ");
            int anio = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el precio: ");
            decimal precio = decimal.Parse(Console.ReadLine());

            Vehiculo v = new Vehiculo(placa, marca, modelo, anio, precio);
            lista.Agregar(v);
            Console.WriteLine("Vehículo agregado correctamente.");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void BuscarPorPlaca(ListaEnlazada lista)
        {
            Console.Write("Ingrese la placa a buscar: ");
            string placa = Console.ReadLine();
            Vehiculo v = lista.BuscarPorPlaca(placa);
            if (v != null)
            {
                Console.WriteLine("Vehículo encontrado:");
                Console.WriteLine(v);
            }
            else
            {
                Console.WriteLine("Vehículo no encontrado.");
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void VerPorAnio(ListaEnlazada lista)
        {
            Console.Write("Ingrese el año a filtrar: ");
            int anio = int.Parse(Console.ReadLine());
            lista.VerPorAnio(anio);
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void EliminarPorPlaca(ListaEnlazada lista)
        {
            Console.Write("Ingrese la placa a eliminar: ");
            string placa = Console.ReadLine();
            bool eliminado = lista.EliminarPorPlaca(placa);
            if (eliminado)
            {
                Console.WriteLine("Vehículo eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Vehículo no encontrado.");
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}