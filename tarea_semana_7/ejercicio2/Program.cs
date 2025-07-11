using System;
using System.Collections.Generic;

class TorresDeHanoi
{
    // Tres pilas que representan las torres A, B y C
    static Stack<int> torreA = new Stack<int>();
    static Stack<int> torreB = new Stack<int>();
    static Stack<int> torreC = new Stack<int>();

    static void Main()
    {
        Console.WriteLine("Ingrese la cantidad de discos:");
        int n = int.Parse(Console.ReadLine() ?? "3"); // Número de discos, por defecto 3

        // Inicializamos la torre A con discos de mayor a menor (n abajo, 1 arriba)
        for (int i = n; i >= 1; i--)
        {
            torreA.Push(i);
        }

        // Mostramos el estado inicial
        MostrarTorres();

        // Iniciamos el proceso de mover discos
        MoverDiscos(n, torreA, torreC, torreB, "A", "C", "B");
    }


    // Función recursiva que mueve discos de una torre a otra usando un auxiliar.
 
    /// <param name="cantidad">Número de discos a mover.</param>
    /// <param name="origen">Pila torre origen.</param>
    /// <param name="destino">Pila torre destino.</param>
    /// <param name="auxiliar">Pila torre auxiliar.</param>
    /// <param name="nombreOrigen">Nombre de la torre origen (para mostrar).</param>
    /// <param name="nombreDestino">Nombre de la torre destino (para mostrar).</param>
    /// <param name="nombreAuxiliar">Nombre de la torre auxiliar (para mostrar).</param>
    static void MoverDiscos(int cantidad, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar,
                            string nombreOrigen, string nombreDestino, string nombreAuxiliar)
    {
        if (cantidad == 1)
        {
            // Mover disco directamente de origen a destino
            int disco = origen.Pop();
            destino.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
            MostrarTorres();
            return;
        }

        // Mover n-1 discos de origen a auxiliar
        MoverDiscos(cantidad - 1, origen, auxiliar, destino, nombreOrigen, nombreAuxiliar, nombreDestino);

        // Mover disco restante de origen a destino
        int discoMayor = origen.Pop();
        destino.Push(discoMayor);
        Console.WriteLine($"Mover disco {discoMayor} de {nombreOrigen} a {nombreDestino}");
        MostrarTorres();

        // Mover los n-1 discos de auxiliar a destino
        MoverDiscos(cantidad - 1, auxiliar, destino, origen, nombreAuxiliar, nombreDestino, nombreOrigen);
    }

   
    /// Muestra el estado actual de las tres torres.

    static void MostrarTorres()
    {
        Console.WriteLine("Estado actual de las torres:");

        MostrarTorre("A", torreA);
        MostrarTorre("B", torreB);
        MostrarTorre("C", torreC);

        Console.WriteLine(new string('-', 30));
    }


    /// Muestra los discos en una torre específica.
    static void MostrarTorre(string nombre, Stack<int> torre)
    {
        // Para mostrar sin modificar la pila, convertimos a array y mostramos de abajo hacia arriba
        int[] discos = torre.ToArray();
        Array.Reverse(discos);

        Console.Write($"{nombre}: ");
        if (discos.Length == 0)
        {
            Console.WriteLine("(vacía)");
            return;
        }

        foreach (int disco in discos)
        {
            Console.Write(disco + " ");
        }
        Console.WriteLine();
    }
}
