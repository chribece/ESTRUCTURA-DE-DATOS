using System;

// Clase principal que maneja la interfaz de usuario y el flujo del programa.

class Program
{
    static void Main(string[] args)
    {
        var diccionario = new DiccionarioTraduccion();
        bool salir = false;

        Console.WriteLine("=== TRADUCTOR BÁSICO ESPAÑOL ↔ INGLÉS ===");
        Console.WriteLine("Autor Christian Becerra.\n");

        while (!salir)
        {
            MostrarMenu();
            string opcion = Console.ReadLine()?.Trim();

            switch (opcion)
            {
                case "1":
                    ProcesarTraduccion(diccionario);
                    break;
                case "2":
                    AgregarNuevaPalabra(diccionario);
                    break;
                case "0":
                    salir = true;
                    Console.WriteLine("Gracias por usar el traductor. ¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.\n");
                    break;
            }
        }
    }

    static void MostrarMenu()
    {
        Console.WriteLine("==================== MENÚ ====================");
        Console.WriteLine();
        Console.WriteLine("1. Traducir una frase");
        Console.WriteLine("2. Agregar palabras al diccionario");
        Console.WriteLine("0. Salir");
        Console.WriteLine();
        Console.Write("Seleccione una opción: ");
    }

    static void ProcesarTraduccion(DiccionarioTraduccion diccionario)
    {
        Console.WriteLine("\n--- Traducción de frase ---");
        Console.Write("Ingrese una frase en español: ");
        string frase = Console.ReadLine();

        string traduccion = diccionario.TraducirFrase(frase);
        Console.WriteLine($"Traducción (parcial): {traduccion}\n");
    }

    static void AgregarNuevaPalabra(DiccionarioTraduccion diccionario)
    {
        Console.WriteLine("\n--- Agregar nueva palabra al diccionario ---");
        Console.Write("Ingrese la palabra en español: ");
        string palabraEs = Console.ReadLine();

        Console.Write("Ingrese la traducción en inglés: ");
        string traduccionEn = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(palabraEs) || string.IsNullOrWhiteSpace(traduccionEn))
        {
            Console.WriteLine("Error: Ni la palabra ni la traducción pueden estar vacías.\n");
            return;
        }

        diccionario.AgregarPalabra(palabraEs, traduccionEn);
        Console.WriteLine($"¡'{palabraEs}' agregada como '{traduccionEn}'!\n");
    }
}