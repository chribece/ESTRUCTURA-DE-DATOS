//Programa que almacena las asignaturas de un curso (Matemáticas, Física, Química, Historia y Lengua) en una lista y la muestre por pantalla.
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Crear una nueva lista de strings para almacenar las asignaturas
        List<string> asignaturas = new List<string>();

        // Agregar las asignaturas a la lista
        asignaturas.Add("Matemáticas");
        asignaturas.Add("Física");
        asignaturas.Add("Química");
        asignaturas.Add("Historia");
        asignaturas.Add("Lengua");

        // Mostrar las asignaturas usando un bucle foreach
        Console.WriteLine("Asignaturas del curso:");
        
        foreach (string asignatura in asignaturas)
        {
            Console.WriteLine(asignatura);
        }
    }
}