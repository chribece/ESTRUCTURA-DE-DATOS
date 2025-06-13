using System;
class Programa
{
    static void Main()
    {
        // Declaración de variables para almacenar los datos del estudiante
        int id;
        string nombres;
        string apellidos;
        string direccion;
        string[] telefonos = new string[3]; //Array para almacenar 3 teléfonos
        Console.WriteLine("=== Registro de Estudiante ===\n");

        // Solicitar ID del estudiante
        Console.Write("Ingrese el ID del estudiante: ");
        id = int.Parse(Console.ReadLine());

        // Solicitar los nombres del estudiante
        Console.Write("Ingrese los nombres del estudiante: ");
        nombres = Console.ReadLine();

        // Solicitar los apellidos del estudiante
        Console.Write("Ingrese los apellidos del estudiante: ");
        apellidos = Console.ReadLine();

        // Solicitar la direccion del estudiante
        Console.Write("Ingrese la direccion del estudiante: ");
        direccion = Console.ReadLine();

        // Solicitar los 3 teléfonos usando un bucle for
        for (int i = 0; i < telefonos.Length; i++)
        {
            Console.Write($"Ingrese el teléfono #{i + 1}: ");
            telefonos[i] = Console.ReadLine();
        }
        Console.Clear();
        // Mostrar los datos registrados
        Console.WriteLine("=== Datos del Estudiante Registrado ===");
        Console.WriteLine($"ID         : {id}");
        Console.WriteLine($"Nombres    : {nombres}");
        Console.WriteLine($"Apellidos  : {apellidos}");
        Console.WriteLine($"Dirección  : {direccion}");

        // Mostrar los teléfonos usando un ciclo foreach
        Console.WriteLine("Teléfonos:");
        foreach (string telefono in telefonos)
        {
            Console.WriteLine($"- {telefono}");
        }

        Console.WriteLine("\nRegistro finalizado.");

    }


}
