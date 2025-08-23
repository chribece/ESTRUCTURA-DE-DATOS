using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Crear conjunto global de 500 ciudadanos
        var conjuntoGlobal = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            conjuntoGlobal.Add($"Ciudadano {i}");
        }

        // ===== IMPRIMIR CONJUNTO GLOBAL =====
        ImprimirConjunto(conjuntoGlobal, "=== LISTADO COMPLETO DE LOS 500 CIUDADANOS ===");

        Random random = new Random();
        
        // Crear conjunto A (Pfizer - 75 ciudadanos)
        var conjuntoA = new HashSet<string>(conjuntoGlobal.OrderBy(x => random.Next()).Take(75));
        
        // Crear conjunto B (AstraZeneca - 75 ciudadanos)
        var conjuntoB = new HashSet<string>(conjuntoGlobal.OrderBy(x => random.Next()).Take(75));

        // ===== IMPRIMIR CONJUNTO PFIZER (A) =====
        ImprimirConjunto(conjuntoA, "=== CIUDADANOS VACUNADOS CON PFIZER (A) ===");

        // ===== IMPRIMIR CONJUNTO ASTRAZENECA (B) =====
        ImprimirConjunto(conjuntoB, "=== CIUDADANOS VACUNADOS CON ASTRAZENECA (B) ===");

        // Operaciones de teoría de conjuntos
        var noVacunados = conjuntoGlobal.Except(conjuntoA.Union(conjuntoB)).ToList();
        var ambasVacunas = conjuntoA.Intersect(conjuntoB).ToList();
        var soloPfizer = conjuntoA.Except(conjuntoB).ToList();
        var soloAstraZeneca = conjuntoB.Except(conjuntoA).ToList();

        // Resultados estadísticos
        Console.WriteLine("\n===== RESUMEN =====");
        Console.WriteLine($"Total ciudadanos: {conjuntoGlobal.Count}");
        Console.WriteLine($"Vacunados con Pfizer (A): {conjuntoA.Count}");
        Console.WriteLine($"Vacunados con AstraZeneca (B): {conjuntoB.Count}");
        Console.WriteLine($"No vacunados: {noVacunados.Count}");
        Console.WriteLine($"Ambas vacunas: {ambasVacunas.Count}");
        Console.WriteLine($"Solo Pfizer: {soloPfizer.Count}");
        Console.WriteLine($"Solo AstraZeneca: {soloAstraZeneca.Count}");
    }

    // Método auxiliar para imprimir cualquier conjunto ordenado
    static void ImprimirConjunto(IEnumerable<string> conjunto, string titulo)
    {
        Console.WriteLine($"\n{titulo}");
        var ordenado = conjunto
            .OrderBy(c => 
            {
                int numero = int.Parse(c.Split(' ')[1]);
                return numero;
            });

        foreach (var ciudadano in ordenado)
        {
            Console.WriteLine(ciudadano);
        }
        Console.WriteLine($"Total: {ordenado.Count()} ciudadanos");
    }
}