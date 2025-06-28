/*Escribir un programa que almacene el abecedario en una lista, elimine de la lista las letras que ocupen posiciones múltiplos de 3, 
y muestre por pantalla la lista resultante.*/

using System;
using System.Collections.Generic;
class Programa
{
    static void Main()
    {
        // 1. Crear una lista con el abecedario
        List<char> abecedario = new List<char>();

        for (char letra = 'A'; letra <= 'Z'; letra++)
        {
            abecedario.Add(letra);
        }

        // 2. Eliminar letras cuya posición (índice + 1) sea múltiplo de 3
        // Usamos una lista auxiliar para no modificar la lista mientras iteramos sobre ella
        List<char> resultado = new List<char>();

        for (int i = 0; i < abecedario.Count; i++)
        {
            if ((i + 1) % 3 != 0)
            {
                resultado.Add(abecedario[i]);
            }
        }

        // 3. Mostrar la lista resultante
        Console.WriteLine("Abecedario sin letras en posiciones múltiplos de 3:");
        Console.WriteLine(string.Join(", ", resultado));
    }
}