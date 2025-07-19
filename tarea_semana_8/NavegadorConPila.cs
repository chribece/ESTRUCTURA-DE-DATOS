using System;
using System.Collections.Generic;

public class NavegadorConPila
{
    private Stack<PaginaWeb> historial = new Stack<PaginaWeb>();
    private Stack<PaginaWeb> historialTemporal = new Stack<PaginaWeb>();

    public void VisitarPagina(PaginaWeb pagina)
    {
        if (pagina == null)
            throw new ArgumentNullException(nameof(pagina));

        historial.Push(pagina);
        historialTemporal.Clear();
        Console.WriteLine($"Página visitada: {pagina.Titulo}");
    }

    public PaginaWeb RetrocederPagina()
    {
        if (historial.Count <= 1)
        {
            Console.WriteLine("No se puede retroceder: solo hay una página en el historial");
            return historial.Peek();
        }

        var paginaActual = historial.Pop();
        historialTemporal.Push(paginaActual);
        
        Console.WriteLine($"Retrocediendo a: {historial.Peek().Titulo}");
        return historial.Peek();
    }

    public PaginaWeb AvanzarPagina()
    {
        if (historialTemporal.Count == 0)
        {
            Console.WriteLine("No hay páginas para avanzar");
            return historial.Count > 0 ? historial.Peek() : null;
        }

        var pagina = historialTemporal.Pop();
        historial.Push(pagina);
        
        Console.WriteLine($"Avanzando a: {pagina.Titulo}");
        return pagina;
    }

    public PaginaWeb PaginaActual()
    {
        return historial.Count > 0 ? historial.Peek() : null;
    }

    public List<PaginaWeb> ObtenerHistorial()
    {
        return new List<PaginaWeb>(historial);
    }

    public List<PaginaWeb> ObtenerHistorialTemporal()
    {
        return new List<PaginaWeb>(historialTemporal);
    }
}