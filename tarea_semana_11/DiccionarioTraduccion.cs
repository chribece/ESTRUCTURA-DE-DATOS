using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

// Clase que gestiona el almacenamiento y búsqueda de traducciones entre español e inglés.

public class DiccionarioTraduccion
{
    private readonly Dictionary<string, string> _diccionario;

    public DiccionarioTraduccion()
    {
        _diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "tiempo", "time" },
            { "persona", "person" },
            { "año", "year" },
            { "camino", "way" },
            { "forma", "way" },
            { "día", "day" },
            { "cosa", "thing" },
            { "hombre", "man" },
            { "mundo", "world" },
            { "vida", "life" },
            { "mano", "hand" },
            { "parte", "part" },
            { "niño", "child" },
            { "niña", "child" },
            { "ojo", "eye" },
            { "mujer", "woman" },
            { "lugar", "place" },
            { "trabajo", "work" },
            { "semana", "week" },
            { "caso", "case" },
            { "punto", "point" },
            { "tema", "point" },
            { "gobierno", "government" },
            { "empresa", "company" },
            { "compañía", "company" },
            { "perro", "dog" },
        };
    }

  
    //Agrega o actualiza una palabra en el diccionario.
  
    public void AgregarPalabra(string palabraEs, string traduccionEn)
    {
        if (!string.IsNullOrWhiteSpace(palabraEs) && !string.IsNullOrWhiteSpace(traduccionEn))
        {
            _diccionario[palabraEs.Trim().ToLower()] = traduccionEn.Trim().ToLower();
        }
    }


    // Traduce una palabra si existe; devuelve null si no.

    public string? TraducirPalabra(string? palabra)
    {
        if (string.IsNullOrEmpty(palabra))
            return null;

        return _diccionario.TryGetValue(palabra, out string traduccion) ? traduccion : null;
    }

  
    // Traduce una frase completa, conservando palabras no registradas.
  
    public string TraducirFrase(string frase)
    {
        if (string.IsNullOrWhiteSpace(frase))
            return string.Empty;

        var partes = Regex.Split(frase, @"(\W+)")
                          .Where(s => !string.IsNullOrEmpty(s));

        var resultado = new System.Text.StringBuilder();
        foreach (string parte in partes)
        {
            if (Regex.IsMatch(parte, @"\w+"))
            {
                resultado.Append(TraducirPalabra(parte) ?? parte);
            }
            else
            {
                resultado.Append(parte);
            }
        }
        return resultado.ToString();
    }
}