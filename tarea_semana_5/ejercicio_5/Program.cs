/*Escribir un programa que pida al usuario una palabra y muestre por pantalla el número de veces que contiene cada vocal..*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Pedir la palabra al usuario y evitar valores null
        Console.Write("Introduce una palabra: ");
        string? palabra = Console.ReadLine(); // podría ser null

        // Si es null, asignamos una cadena vacía
        palabra = palabra?.ToLower() ?? "";

        // Inicializar un diccionario para contar las vocales
        Dictionary<char, int> contadorVocales = new Dictionary<char, int>
        {
            { 'a', 0 },
            { 'e', 0 },
            { 'i', 0 },
            { 'o', 0 },
            { 'u', 0 }
        };

        // Contar las vocales
        foreach (char letra in palabra)
        {
            if (contadorVocales.ContainsKey(letra))
            {
                contadorVocales[letra]++;
            }
        }

        // Mostrar los resultados
        Console.WriteLine("\nNúmero de veces que aparece cada vocal:");
        foreach (var kvp in contadorVocales)
        {
            Console.WriteLine($"La vocal '{kvp.Key}' aparece {kvp.Value} veces.");
        }
    }
}