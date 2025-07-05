Console.WriteLine("2525 - ESTRUCTURA DE DATOS - UEA / SEMANA 06");
Console.WriteLine("Ejemplo de Lista Enlazada con cálculo de longitud\n");


ListaEnlazada lista = new ListaEnlazada();

// Agregamos elementos a la lista
lista.Agregar(10);
lista.Agregar(20);
lista.Agregar(30);
lista.Agregar(40);
lista.Agregar(50);

lista.Mostrar();

// Calculamos la longitud
int longitud = lista.CalcularLongitud();
Console.WriteLine("La longitud de la lista es: " + longitud);

// Agregar más elementos y volver a calcular
lista.Agregar(60);
lista.Agregar(70);

Console.WriteLine("\nDespués de agregar más elementos:");
lista.Mostrar();
longitud = lista.CalcularLongitud();
Console.WriteLine("La nueva longitud de la lista es: " + longitud);