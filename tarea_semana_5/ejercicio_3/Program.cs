/*Programa  que almacena en una lista los números del 1 al 10 y los muestre por pantalla en orden inverso separados por comas..*/
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // 1. Crear la lista con los números del 1 al 10
        List<int> numeros = new List<int>();
        for (int i = 1; i <= 10; i++)
        {
            numeros.Add(i);
        }

        // 2. Invertir la lista
        numeros.Reverse();

        // 3. Convertir los números a cadena separados por coma
        string resultado = string.Join(", ", numeros);

        // 4. Mostrar el resultado
        Console.WriteLine("Números en orden inverso:");
        Console.WriteLine(resultado);
    }
}