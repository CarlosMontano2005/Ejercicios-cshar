using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRET_K
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Establecer el título de la consola
            Console.Title = "Convertirdor de temperatura";

            // Establecer el tamaño de la ventana de la consola
            Console.WindowHeight = 20; // alto de la ventana
            Console.WindowWidth = 100; // ancho de la ventana

            // Declarar variables para almacenar la opción del usuario y las temperaturas
            int opcTemperatura;
            double C, K, F, cantTemperatura;

            // Ciclo de repetición que muestra el menú hasta que el usuario decida salir
            do
            {
                // Limpiar la consola y establecer colores predeterminados
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();

                // Mostrar el menú de opciones al usuario
                Console.WriteLine("1. Celsius -> F° y K°");
                Console.WriteLine("2. Fahrenheit -> C° y K°");
                Console.WriteLine("3. Kelvin -> F° y C°.");
                Console.WriteLine("4. Salir");

                Console.WriteLine("Escoja la opción de conversión del menú: ");
                opcTemperatura = int.Parse(Console.ReadLine());

                // Switch statement para manejar la opción seleccionada por el usuario
                switch (opcTemperatura)
                {
                    case 1:
                        // Conversión de Celsius a Fahrenheit y Kelvin
                        Console.Write("\n Digite La Cantidad de temperatura a convertir temperatura: ");
                        cantTemperatura = double.Parse(Console.ReadLine());
                        F = ((9 * (cantTemperatura)) / 5) + 32;
                        K = ((5 * (F - 32)) / 9) + 273.15;
                        colorTemperatura(opcTemperatura, cantTemperatura);
                        Console.WriteLine("\n La temperatura de  " + cantTemperatura + "° Celsius a Fahrenheit es :  " + Math.Round(F, 2) + "° y de Fahrenheit a Kelvin " + Math.Round(K, 2) + "°");
                        Console.ReadLine();
                        break;
                    case 2:
                        // Conversión de Fahrenheit a Celsius y Kelvin
                        Console.Write("\n Digite La Cantidad de temperatura a convertir temperatura: ");
                        cantTemperatura = double.Parse(Console.ReadLine());
                        C = ((5 * (cantTemperatura - 32)) / 9);
                        K = C + 273.15;
                        colorTemperatura(opcTemperatura, cantTemperatura);
                        Console.WriteLine("\n La temperatura de  " + cantTemperatura + "° Fahrenheit a Celsius es :  " + Math.Round(C, 2) + "° y de Celsius a Kelvin " + Math.Round(K, 2) + "°");
                        Console.ReadLine();
                        break;
                    case 3:
                        // Conversión de Kelvin a Fahrenheit y Celsius
                        Console.Write("\n Digite La Cantidad de temperatura a convertir temperatura: ");
                        cantTemperatura = double.Parse(Console.ReadLine());
                        F = ((9 * (cantTemperatura - 273.15)) / 5) + 32;
                        C = ((5 * (F - 32)) / 9);
                        colorTemperatura(opcTemperatura, cantTemperatura);
                        Console.WriteLine("\n La temperatura de  " + cantTemperatura + "° Kelvin a Fahrenheit es : " + Math.Round(F, 2) + "° y de Fahrenheit a  Celsius es " + Math.Round(C, 2) + "°");
                        Console.ReadLine();
                        break;
                    case 4:
                        // Salir del programa
                        Console.WriteLine("----------------------Salió del Programa -------------------------");
                        break;
                    default:
                        Console.WriteLine("OPCION NO ENCONTRADA ERROR");
                        // Opción inválida
                        break;
                }
            } while (opcTemperatura != 4);

            Console.ReadLine();
        }

        // Método para establecer el color de fondo de la consola según la temperatura y la unidad
        public static void colorTemperatura(int opc_Temperatura, double cant_Temperatura)
        {
            // Establecer colores según el rango de temperatura y la unidad de medida
            if (opc_Temperatura == 1 && cant_Temperatura > 25 || opc_Temperatura == 2 && cant_Temperatura > 77 || opc_Temperatura == 3 && cant_Temperatura > 298.15)
            {
                Console.BackgroundColor = ConsoleColor.Red; // Rango caliente
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
            }
            else if (opc_Temperatura == 1 && cant_Temperatura > 0 && cant_Temperatura <= 25 || opc_Temperatura == 2 && cant_Temperatura > 32 && cant_Temperatura <= 77 || opc_Temperatura == 3 && cant_Temperatura > 273.15 && cant_Temperatura <= 298.15)
            {
                Console.BackgroundColor = ConsoleColor.Green; // Rango ambiente
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
            }
            else if (opc_Temperatura == 1 && cant_Temperatura <= 0 || opc_Temperatura == 2 && cant_Temperatura <= 32 || opc_Temperatura == 3 && cant_Temperatura <= 273.15)
            {
                Console.BackgroundColor = ConsoleColor.Blue; // Rango frío
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
            }
        }
    }
}
