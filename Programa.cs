using System;
using System.Collections.Generic;

namespace CongresoCola
{
    class Asistente
    {
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Operador { get; set; }
        public int Asiento { get; set; }

        public Asistente(string nombre, string cedula, string operador)
        {
            Nombre = nombre;
            Cedula = cedula;
            Operador = operador;
            Asiento = 0;
        }
    }

    class Program
    {
        // Estructura utilizada: Queue (Cola) con complejidad O(1) para insertar y eliminar
        static Queue<Asistente> cola = new Queue<Asistente>();
        static List<Asistente> registrados = new List<Asistente>();

        static int asientoActual = 1;
        const int MAX_ASIENTOS = 100; // Límite de las pruebas del reporte

        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=========================================");
                Console.WriteLine(" CONGRESO - ASIGNACIÓN DE ASIENTOS (FIFO)");
                Console.WriteLine("=========================================");
                Console.WriteLine("1. Registrar asistente (Operador 1 o 2)");
                Console.WriteLine("2. Mostrar reporte general de asistentes");
                Console.WriteLine("3. Buscar asistente por cédula");
                Console.WriteLine("4. Verificar disponibilidad y estado de asientos");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = 0;

                switch (opcion)
                {
                    case 1:
                        RegistrarAsistente();
                        break;
                    case 2:
                        MostrarReporte();
                        break;
                    case 3:
                        Buscar();
                        break;
                    case 4:
                        Disponibles();
                        break;
                    case 5:
                        Console.WriteLine("\nSistema finalizado.");
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta.");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 5);
        }

        // Proceso Principal: Registrar, agregar a Queue y asignación automática
        static void RegistrarAsistente()
        {
            Console.Clear();

            // Una vez ocupados los 100 asientos, el sistema impide nuevos registros
            if (registrados.Count >= MAX_ASIENTOS)
            {
                Console.WriteLine("=========================================================");
                Console.WriteLine("¡ALERTA! Una vez ocupados los 100 asientos, el sistema");
                Console.WriteLine("impide nuevos registros de asistentes.");
                Console.WriteLine("=========================================================");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("--- PROCESO: REGISTRAR ASISTENTE ---");
            Console.Write("Nombre del asistente: ");
            string nombre = Console.ReadLine();

            Console.Write("Número de Cédula: ");
            string cedula = Console.ReadLine();

            Console.Write("Identificar Operador encargado (1 o 2): ");
            string op = Console.ReadLine();
            string operador = op == "1" ? "Operador 1" : "Operador 2";

            // 1. Crear el objeto asistente
            Asistente nuevo = new Asistente(nombre, cedula, operador);

            // 2. Agregar el asistente a la cola (Mantiene el orden de llegada FIFO)
            cola.Enqueue(nuevo);
            Console.WriteLine($"\n[PROCESO] Asistente agregado a la Queue por {operador} correctamente.");

            // 3. ¿Existen asientos disponibles? -> ASIGNACIÓN AUTOMÁTICA
            if (asientoActual <= MAX_ASIENTOS)
            {
                // Saca de la cola respetando estrictamente el orden de llegada
                Asistente asignado = cola.Dequeue();
                asignado.Asiento = asientoActual;

                // Almacena en la lista para la reportería final
                registrados.Add(asignado);

                Console.WriteLine("\n[ASIGNACIÓN AUTOMÁTICA DE ASIENTO]");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine($"Se respetó el orden de llegada. Asiento asignado: {asignado.Asiento}");
                Console.WriteLine($"Registrado por: {asignado.Operador}");
                Console.WriteLine("-------------------------------------------------");
                
                asientoActual++; // Incrementa automáticamente evitando duplicados
            }

            Console.ReadKey();
        }

        // Proceso Principal: Mostrar los asistentes registrados (Reportería)
        static void MostrarReporte()
        {
            Console.Clear();
            Console.WriteLine("===============================================================");
            Console.WriteLine("                REPORTERÍA: ASISTENTES REGISTRADOS             ");
            Console.WriteLine("===============================================================");
            
            if (registrados.Count == 0)
            {
                Console.WriteLine("No existen asistentes registrados en el sistema.");
            }
            else
            {
                Console.WriteLine("Nombre\t\tCédula\t\tOperador\tAsiento asignado");
                Console.WriteLine("---------------------------------------------------------------");
                foreach (Asistente a in registrados)
                {
                    Console.WriteLine($"{a.Nombre}\t{a.Cedula}\t{a.Operador}\tAsiento #{a.Asiento}");
                }
            }
            Console.WriteLine("===============================================================");
            Console.ReadKey();
        }

        static void Buscar()
        {
            Console.Clear();
            Console.Write("Ingrese la cédula a consultar: ");
            string cedula = Console.ReadLine();
            bool encontrado = false;

            foreach (Asistente a in registrados)
            {
                if (a.Cedula == cedula)
                {
                    Console.WriteLine("\n[Asistente Localizado]");
                    Console.WriteLine($"Nombre: {a.Nombre} | {a.Operador} | Asiento: {a.Asiento}");
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado) Console.WriteLine("\nNo existe el asistente.");
            Console.ReadKey();
        }

        // Proceso Principal: Consultar asientos ocupados y verificar disponibilidad
        static void Disponibles()
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("          VERIFICAR DISPONIBILIDAD        ");
            Console.WriteLine("=========================================");
            Console.WriteLine("Asientos ocupados : " + registrados.Count);
            Console.WriteLine("Asientos libres   : " + (MAX_ASIENTOS - registrados.Count));
            Console.WriteLine("Personas en cola  : " + cola.Count);
            Console.WriteLine("=========================================");
            Console.ReadKey();
        }
    }
}
