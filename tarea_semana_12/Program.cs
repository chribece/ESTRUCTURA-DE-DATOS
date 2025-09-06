using System;
using System.Collections.Generic;

namespace TorneoFutbol
{
    // Clase jugador
    public class Jugador
    {
        // Propiedades autoimplementadas: almacenan los datos del jugador.
        public string Id { get; set; }      // Identificador único del jugador (clave para evitar duplicados)
        public string Nombre { get; set; }  // Nombre completo del jugador
        public string Posicion { get; set; } // Posición en el campo (delantero, defensa, etc.)

       
        // MÉTODO Equals Define cuándo dos objetos Jugador son "iguales".
        // Se usa para detectar duplicados.
      
        public override bool Equals(object obj)
        {
            // Verifica si el objeto recibido es de tipo Jugador
            if (obj is Jugador otro)
            {
                // Dos jugadores son iguales si tienen el mismo ID (clave única)
                return Id == otro.Id;
            }
            // Si no es un Jugador, no son iguales
            return false;
        }

       
        // MÉTODO GetHashCode, genera un código hash único para el objeto.
        // Requerido cuando se sobrescribe Equals, especialmente en HashSet y Dictionary.
  
        public override int GetHashCode()
        {
            // Devuelve el hash del ID. Si ID es null, devuelve 0 (evita excepciones).
            return Id?.GetHashCode() ?? 0;
        }

  
        // MÉTODO ToString, personaliza cómo se muestra el objeto cuando se imprime.
        // Útil para reportes y depuración.
        public override string ToString()
        {
            return $"[{Id}] {Nombre} - {Posicion}";
        }
    }

 
    // Clase equipo
    // Usa HashSet para almacenar jugadores y evitar duplicados.
    public class Equipo
    {
        public string Id { get; set; }          // Identificador único del equipo
        public string Nombre { get; set; }      // Nombre del equipo (ej: "Los Halcones")

        // HashSet<Jugador>: Estructura que almacena jugadores SIN DUPLICADOS.
        public HashSet<Jugador> Jugadores { get; set; } = new HashSet<Jugador>();

        // MÉTODO AgregarJugador, añade un jugador al equipo.
        public void AgregarJugador(Jugador jugador)
        {
            Jugadores.Add(jugador); // HashSet evita duplicados automáticamente
        }

        // MÉTODO ToString, mostrar información resumida del equipo.
        public override string ToString()
        {
            return $"Equipo: {Nombre} (ID: {Id}) - Jugadores: {Jugadores.Count}";
        }
    }

    // Clase torneo
    public class Torneo
    {
         // Dictionary<string, Equipo>: Estructura clave-valor.
        private Dictionary<string, Equipo> equipos = new Dictionary<string, Equipo>();

        // MÉTODO RegistrarEquip, permite al usuario registrar un nuevo equipo mediante teclado.
           public void RegistrarEquipo()
        {
            Console.Write("Ingrese ID del equipo: ");
            string id = Console.ReadLine()?.Trim(); // ?. evita NullReferenceException

            // Validación: ID no puede estar vacío
            if (string.IsNullOrEmpty(id))
            {
                Console.WriteLine(" ID no puede estar vacío.");
                return; // Termina la ejecución del método
            }

            // Validación: Evitar duplicados de equipos
            if (equipos.ContainsKey(id))
            {
                Console.WriteLine(" El equipo ya existe.");
                return;
            }

            Console.Write("Ingrese nombre del equipo: ");
            string nombre = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                Console.WriteLine("Nombre no puede estar vacío.");
                return;
            }

            // Crear nuevo objeto Equipo y agregarlo al diccionario
            equipos[id] = new Equipo { Id = id, Nombre = nombre };
            Console.WriteLine($" Equipo '{nombre}' registrado con ID '{id}'.");
        }

       
        // MÉTODO RegistrarJugador, registra un jugador en un equipo existente.     
        public void RegistrarJugador()
        {
            Console.Write("Ingrese ID del equipo: ");
            string idEquipo = Console.ReadLine()?.Trim();

            // Buscar equipo por ID. Si no existe, TryGetValue retorna false.
            if (!equipos.TryGetValue(idEquipo, out Equipo equipo))
            {
                Console.WriteLine(" Equipo no encontrado.");
                return;
            }

            // Solicitar datos del jugador
            Console.Write("Ingrese ID del jugador: ");
            string idJugador = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(idJugador))
            {
                Console.WriteLine(" ID de jugador no puede estar vacío.");
                return;
            }

            Console.Write("Ingrese nombre del jugador: ");
            string nombre = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(nombre))
            {
                Console.WriteLine(" Nombre de jugador no puede estar vacío.");
                return;
            }

            Console.Write("Ingrese posición del jugador: ");
            string posicion = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(posicion))
            {
                Console.WriteLine(" Posición no puede estar vacía.");
                return;
            }

            // Crear objeto Jugador
            Jugador jugador = new Jugador { Id = idJugador, Nombre = nombre, Posicion = posicion };

            // Intentar agregar al HashSet. Retorna true si se agregó, false si ya existía.
            if (equipo.Jugadores.Add(jugador))
            {
                Console.WriteLine($" Jugador '{nombre}' agregado al equipo '{equipo.Nombre}'.");
            }
            else
            {
                Console.WriteLine(" El jugador ya está registrado en este equipo.");
            }
        }

        // MÉTODO ListarEquipos, muestra todos los equipos y sus jugadores en consola.
 
        public void ListarEquipos()
        {
            if (equipos.Count == 0)
            {
                Console.WriteLine("📭 No hay equipos registrados.");
                return;
            }

            Console.WriteLine("\n=== LISTA DE EQUIPOS Y JUGADORES ===");
            foreach (var kvp in equipos) // kvp = KeyValuePair<string, Equipo>
            {
                Console.WriteLine(kvp.Value); // Imprime resumen del equipo

                // Si no tiene jugadores, lo indicamos
                if (kvp.Value.Jugadores.Count == 0)
                {
                    Console.WriteLine("    Sin jugadores.");
                }
                else
                {
                    // Recorremos el HashSet de jugadores
                    foreach (var jugador in kvp.Value.Jugadores)
                    {
                        Console.WriteLine($"   → {jugador}");
                    }
                }
                Console.WriteLine(); // Espacio entre equipos
            }
        }

        // MÉTODO ConsultarEquipo, busca y muestra un equipo específico por su ID.
        public void ConsultarEquipo()
        {
            Console.Write("Ingrese ID del equipo a consultar: ");
            string idEquipo = Console.ReadLine()?.Trim();

            if (equipos.TryGetValue(idEquipo, out Equipo equipo))
            {
                Console.WriteLine($"\n=== EQUIPO: {equipo.Nombre} ===");
                if (equipo.Jugadores.Count == 0)
                {
                    Console.WriteLine("    Sin jugadores registrados.");
                }
                else
                {
                    foreach (var jugador in equipo.Jugadores)
                    {
                        Console.WriteLine($"   → {jugador}");
                    }
                }
            }
            else
            {
                Console.WriteLine(" Equipo no encontrado.");
            }
        }

        // MÉTODO GenerarReporte, muestra estadísticas generales del torneo.
        public void GenerarReporte()
        {
            if (equipos.Count == 0)
            {
                Console.WriteLine("📭 No hay datos para generar reporte.");
                return;
            }

            Console.WriteLine("\n=== REPORTE GENERAL DEL TORNEO ===");
            int totalJugadores = 0;

            // Recorremos solo los valores (objetos Equipo) del diccionario
            foreach (var equipo in equipos.Values)
            {
                Console.WriteLine($"{equipo.Nombre}: {equipo.Jugadores.Count} jugadores");
                totalJugadores += equipo.Jugadores.Count;
            }

            Console.WriteLine($"\n TOTAL DE EQUIPOS: {equipos.Count}");
            Console.WriteLine($" TOTAL DE JUGADORES: {totalJugadores}");
        }
    }

    // CLASE PROGRAM, contiene el método Main, que inicia la aplicación.
    class Program
    {
        static void Main(string[] args)
        {
            // Creamos una instancia del torneo (modelo de datos + lógica)
            var torneo = new Torneo();
            string opcion;

            // Bucle de menú: se repite hasta que el usuario elija salir (opción "0")
            do
            {
                // Limpiar pantalla para mejor experiencia de usuario
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("   SISTEMA DE GESTIÓN DE TORNEO 2025");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Registrar nuevo equipo");
                Console.WriteLine("2. Registrar jugador en equipo");
                Console.WriteLine("3. Listar todos los equipos y jugadores");
                Console.WriteLine("4. Consultar equipo por ID");
                Console.WriteLine("5. Generar reporte general");
                Console.WriteLine("0. Salir");
                Console.WriteLine("========================================");
                Console.Write("Seleccione una opción: ");
                opcion = Console.ReadLine(); // Leer opción del usuario

                // Procesar la opción seleccionada
                switch (opcion)
                {
                    case "1":
                        torneo.RegistrarEquipo();
                        break;
                    case "2":
                        torneo.RegistrarJugador();
                        break;
                    case "3":
                        torneo.ListarEquipos();
                        break;
                    case "4":
                        torneo.ConsultarEquipo();
                        break;
                    case "5":
                        torneo.GenerarReporte();
                        break;
                    case "0":
                        Console.WriteLine(" ¡Gracias por usar el sistema!");
                        break;
                    default:
                        Console.WriteLine(" Opción no válida.");
                        break;
                }

                // Pausa para que el usuario pueda leer el resultado antes de volver al menú
                if (opcion != "0")
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != "0"); // Repetir mientras no se elija salir
        }
    }
}