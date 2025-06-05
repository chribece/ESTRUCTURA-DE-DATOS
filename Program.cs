using System;

namespace FigurasGeometricas
{
    // Clase que representa un círculo
    public class circulo
    {
        // Atributo privado para almacenar el radio del círculo
        private double radio;

        // Constructor que inicializa el radio del círculo
        public circulo(double radio)
        {
            this.radio = radio;
        }

        // CalcularArea es una función que devuelve un valor double,
        // se utiliza para calcular el área de un círculo, requiere como argumento el radio del círculo
        public double calcular_area()
        {
            return Math.PI * radio * radio;
        }

        // CalcularPerimetro es una función que devuelve un valor double,
        // se utiliza para calcular el perímetro (circunferencia) del círculo
        public double calcular_perimetro()
        {
            return 2 * Math.PI * radio;
        }
    }

    // Clase que representa un cuadrado
    public class cuadrado
    {
        // Atributo privado para almacenar el lado del cuadrado
        private double lado;

        // Constructor que inicializa el lado del cuadrado
        public cuadrado(double lado)
        {
            this.lado = lado;
        }

        // CalcularArea es una función que devuelve un valor double,
        // se utiliza para calcular el área del cuadrado, requiere el lado como argumento
        public double calcular_area()
        {
            return lado * lado;
        }

        // CalcularPerimetro es una función que devuelve un valor double,
        // se utiliza para calcular el perímetro del cuadrado
        public double calcularperimetro()
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
            circulo miCirculo = new circulo(5);
            Console.WriteLine("Área del círculo: " + miCirculo.calcular_area());
            Console.WriteLine("Perímetro del círculo: " + miCirculo.calcular_perimetro());

            // Crear un cuadrado con lado 4
            cuadrado miCuadrado = new cuadrado(4);
            Console.WriteLine("Área del cuadrado: " + miCuadrado.calcular_area());
            Console.WriteLine("Perímetro del cuadrado: " + miCuadrado.calcular_perimetro());
        }
    }
}