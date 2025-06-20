// Clase que representa un contacto en la agenda
public class Contacto
{
    public string Nombre { get; set; }
    public string Telefono { get; set; }

    public Contacto(string nombre, string telefono)
    {
        Nombre = nombre;
        Telefono = telefono;
    }

    public override string ToString()
    {
        return $"Nombre: {Nombre}, Teléfono: {Telefono}";
    }
}