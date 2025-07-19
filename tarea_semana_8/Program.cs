using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        NavegadorConPila navegador = new NavegadorConPila();

        // Visitar algunas páginas
        navegador.VisitarPagina(new PaginaWeb("google.com", "Google"));
        navegador.VisitarPagina(new PaginaWeb("github.com", "GitHub"));
        navegador.VisitarPagina(new PaginaWeb("www.uea.edu.ec", "Universidad Estatal Amazónica"));

     
        // Mostrar historial actual
        MostrarHistorial(navegador);

        // Retroceder
        var actual = navegador.RetrocederPagina();
        Console.WriteLine($"\nPágina actual después de retroceder: {actual}");

        // Mostrar historial después de retroceder
        MostrarHistorial(navegador);

        // Avanzar
        actual = navegador.AvanzarPagina();
        Console.WriteLine($"\nPágina actual después de avanzar: {actual}");

        // Mostrar historial completo
        MostrarHistorialCompleto(navegador);
    }

    static void MostrarHistorial(NavegadorConPila navegador)
    {
        Console.WriteLine("\nHistorial principal (de más reciente a más antiguo):");
        foreach (var pag in navegador.ObtenerHistorial())
        {
            Console.WriteLine(pag);
        }
    }

    static void MostrarHistorialCompleto(NavegadorConPila navegador)
    {
        MostrarHistorial(navegador);
        
        Console.WriteLine("\nHistorial temporal (páginas para avanzar):");
        var tempHist = navegador.ObtenerHistorialTemporal();
        if (tempHist.Count == 0)
        {
            Console.WriteLine("(Vacío)");
        }
        else
        {
            foreach (var pag in tempHist)
            {
                Console.WriteLine(pag);
            }
        }

        var paginaActual = navegador.PaginaActual();
        Console.WriteLine($"\nPágina actual: {(paginaActual != null ? paginaActual.ToString() : "Ninguna")}");
    }
}