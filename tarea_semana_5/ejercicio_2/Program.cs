/*Programa que almacena las asignaturas de un curso (Matemáticas, Física, Química, Historia y Lengua) 
en una lista, pregunte al usuario la nota que ha sacado en cada asignatura, y después las muestre por pantalla 
con el mensaje En <asignatura> has sacado <nota> donde <asignatura> es cada una des las asignaturas de la lista 
y<nota> cada una de las correspondientes notas introducidas por el usuario.*/


using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Crear las listas para asignaturas y notas
        List<string> asignaturas = new List<string>()
        {
            "Matemáticas",
            "Física",
            "Química",
            "Historia",
            "Lengua"
        };
        
        List<double> notas = new List<double>();

        // Pedir la nota para cada asignatura
        for (int i = 0; i < asignaturas.Count; i++)
        {
            double nota;
            
            // Bucle para validar la entrada hasta obtener un número válido
            while (true)
            {
                Console.WriteLine($"\nIngresa tu nota en {asignaturas[i]} (0-10):");
                
                if (double.TryParse(Console.ReadLine(), out nota))
                {
                    if (nota >= 0 && nota <= 10)
                    {
                        break;
                    }
                    Console.WriteLine("La nota debe estar entre 0 y 10.");
                }
                else
                {
                    Console.WriteLine("Por favor, ingresa un número válido.");
                }
            }

            // Almacenar la nota válida
            notas.Add(nota);
        }

        // Mostrar los resultados
        Console.WriteLine("\n=== Resultados ===");
        for (int i = 0; i < asignaturas.Count; i++)
        {
            Console.WriteLine($"En {asignaturas[i]} has sacado {notas[i]:F2}");
        }
    }
}