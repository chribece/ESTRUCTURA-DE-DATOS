using System;

namespace FigurasGeometricas
{
    // Clase que representa un círculo
    public class Circulo
    {
        // Atributo privado para almacenar el radio del círculo
        private double radio;

        // Constructor que inicializa el radio del círculo
        public Circulo(double radio)
        {
            this.radio = radio;
        }

        // CalcularArea es una función que devuelve un valor double,
        // se utiliza para calcular el área de un círculo, requiere como argumento el radio del círculo
        public double CalcularArea()
        {
            return Math.PI * radio * radio;
        }

        // CalcularPerimetro es una función que devuelve un valor double,
        // se utiliza para calcular el perímetro (circunferencia) del círculo
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * radio;
        }
    }

    // Clase que representa un cuadrado
    public class Cuadrado
    {
        // Atributo privado para almacenar el lado del cuadrado
        private double lado;

        // Constructor que inicializa el lado del cuadrado
        public Cuadrado(double lado)
        {
            this.lado = lado;
        }

        // CalcularArea es una función que devuelve un valor double,
        // se utiliza para calcular el área del cuadrado, requiere el lado como argumento
        public double CalcularArea()
        {
            return lado * lado;
        }

        // CalcularPerimetro es una función que devuelve un valor double,
        // se utiliza para calcular el perímetro del cuadrado
        public double CalcularPerimetro()
        {
            return 4 * lado;
        }
    }

    // Clase principal para probar las figuras
    class Program
    {
        static void Main(string[] args)
        {
            // Crear un círculo con radio 5
            Circulo miCirculo = new Circulo(5);
            Console.WriteLine("Área del círculo: " + miCirculo.CalcularArea());
            Console.WriteLine("Perímetro del círculo: " + miCirculo.CalcularPerimetro());

            // Crear un cuadrado con lado 4
            Cuadrado miCuadrado = new Cuadrado(4);
            Console.WriteLine("Área del cuadrado: " + miCuadrado.CalcularArea());
            Console.WriteLine("Perímetro del cuadrado: " + miCuadrado.CalcularPerimetro());
        }
    }
}