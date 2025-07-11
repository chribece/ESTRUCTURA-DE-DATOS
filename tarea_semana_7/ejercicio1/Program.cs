using System;
using System.Collections.Generic;

class ProgramaBalanceo
{
    static void Main()
    {
        Console.WriteLine("Introduce una expresión matemática:");
        string? expresion = Console.ReadLine(); // Puede ser null

        // Validamos que la expresión no sea null antes de continuar
        if (string.IsNullOrEmpty(expresion))
        {
            Console.WriteLine("No se ingresó ninguna expresión válida.");
            return;
        }

        bool balanceada = VerificarBalanceo(expresion);

        if (balanceada)
            Console.WriteLine("Fórmula balanceada.");
        else
            Console.WriteLine("Fórmula NO balanceada.");
    }


    // Función que utiliza una pila para verificar si los símbolos están balanceados.
 
    static bool VerificarBalanceo(string texto)
    {
        Stack<char> pila = new Stack<char>(); // Creamos una pila vacía

        foreach (char simbolo in texto)
        {
            // Si encontramos un símbolo de apertura, lo apilamos
            if (simbolo == '(' || simbolo == '{' || simbolo == '[')
            {
                pila.Push(simbolo);
            }
            // Si encontramos un símbolo de cierre, verificamos si hay uno de apertura correspondiente
            else if (simbolo == ')' || simbolo == '}' || simbolo == ']')
            {
                // Si la pila está vacía, no hay apertura para este cierre
                if (pila.Count == 0)
                    return false;

                char apertura = pila.Pop(); // Sacamos el último símbolo de apertura

                // Comprobamos si el símbolo de apertura corresponde al de cierre
                if (!EsPar(apertura, simbolo))
                    return false;
            }
        }

        // Si la pila queda vacía, todo está balanceado
        return pila.Count == 0;
    }

 
    // Función auxiliar para comprobar si los símbolos son pares correctos.
    static bool EsPar(char apertura, char cierre)
    {
        if (apertura == '(' && cierre == ')') return true;
        if (apertura == '{' && cierre == '}') return true;
        if (apertura == '[' && cierre == ']') return true;
        return false;
    }
}
