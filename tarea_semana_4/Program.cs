using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido a la Agenda Telefónica");

        // Crear la agenda con capacidad para 5 contactos
        Agenda agenda = new Agenda(5);

        // Menú interactivo
        while (true)
        {
            Console.WriteLine("\n--- Menú ---");
            Console.WriteLine("1. Agregar Contacto");
            Console.WriteLine("2. Mostrar Contactos");
            Console.WriteLine("3. Buscar Contacto por Nombre");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese el nombre: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese el teléfono: ");
                    string telefono = Console.ReadLine();

                    // Crear un contacto usando la clase Contacto
                    Contacto nuevoContacto = new Contacto(nombre, telefono);
                    agenda.AgregarContacto(nuevoContacto);

                    // Opcional: usar record
                    RegistroContacto registro = new RegistroContacto(nombre, telefono);
                    Console.WriteLine($"\nRegistro creado: {registro}");
                    break;

                case "2":
                    Console.WriteLine("Mostrando contactos...");
                    agenda.MostrarContactos();
                    Console.WriteLine("\nMostrando en formato de matriz...");
                    agenda.MostrarMatrizContactos();
                    break;

                case "3":
                    Console.Write("Ingrese el nombre a buscar: ");
                    string nombreBuscar = Console.ReadLine();
                    agenda.BuscarContactoPorNombre(nombreBuscar);
                    break;

                case "4":
                    Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                    return;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}