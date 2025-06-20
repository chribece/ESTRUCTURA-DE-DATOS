using System;

public class Agenda
{
    private Contacto[] contactos;
    private int indice;

    public Agenda(int capacidad)
    {
        contactos = new Contacto[capacidad];
        indice = 0;
    }

    // Método para agregar un contacto
    public void AgregarContacto(Contacto contacto)
    {
        if (indice < contactos.Length)
        {
            contactos[indice++] = contacto;
        }
        else
        {
            Console.WriteLine("La agenda está llena.");
        }
    }

    // Método para mostrar todos los contactos
    public void MostrarContactos()
    {
        Console.WriteLine("\n--- Lista de Contactos ---");
        foreach (var contacto in contactos)
        {
            if (contacto != null)
                Console.WriteLine(contacto.ToString());
        }
    }

    // Método para buscar contactos por nombre
    public void BuscarContactoPorNombre(string nombre)
    {
        bool encontrado = false;
        foreach (var contacto in contactos)
        {
            if (contacto != null && contacto.Nombre.ToLower() == nombre.ToLower())
            {
                Console.WriteLine(contacto.ToString());
                encontrado = true;
            }
        }
        if (!encontrado)
        {
            Console.WriteLine("No se encontró ningún contacto con ese nombre.");
        }
    }

    // Usando una matriz para mostrar datos en formato tabular (solo ejemplo)
    public void MostrarMatrizContactos()
    {
        Console.WriteLine("\n--- Matriz de Contactos ---");
        string[,] matriz = new string[contactos.Length, 2];

        for (int i = 0; i < contactos.Length; i++)
        {
            if (contactos[i] != null)
            {
                matriz[i, 0] = contactos[i].Nombre;
                matriz[i, 1] = contactos[i].Telefono;
            }
        }

        for (int i = 0; i < contactos.Length; i++)
        {
            if (matriz[i, 0] != null)
            {
                Console.WriteLine($"Nombre: {matriz[i, 0]}, Teléfono: {matriz[i, 1]}");
            }
        }
    }
}