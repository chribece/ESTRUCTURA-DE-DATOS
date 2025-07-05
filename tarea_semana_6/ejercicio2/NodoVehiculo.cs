using System;

namespace ProyectoEstacionamiento.Models
{
    public class NodoVehiculo
    {
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }
        public decimal Precio { get; set; }
        public NodoVehiculo? Siguiente { get; set; }

        public NodoVehiculo(string placa, string marca, string modelo, int año, decimal precio)
        {
            Placa = placa ?? throw new ArgumentNullException(nameof(placa));
            Marca = marca ?? throw new ArgumentNullException(nameof(marca));
            Modelo = modelo ?? throw new ArgumentNullException(nameof(modelo));
            Año = año;
            Precio = precio;
            Siguiente = null;
        }
    }
}