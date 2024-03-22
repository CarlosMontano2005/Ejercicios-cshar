using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRET_J
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaración de variables
            int opcion; // Variable para almacenar la opción del usuario
            double radio, arista, altura, resultado; // Variables para almacenar las dimensiones y el resultado de los cálculos

            // Ciclo de repetición que muestra el menú hasta que el usuario decida salir
            do
            {
                // Limpiar la consola para mostrar el menú
                Console.Clear();

                // Mostrar el menú de opciones al usuario
                Console.WriteLine("************** Menú. ****************");
                Console.WriteLine("Elija la unidad a convertir:");
                Console.WriteLine("1. Esfera.");
                Console.WriteLine("2. Cubo.");
                Console.WriteLine("3. Cilindro.");
                Console.WriteLine("4. Salir");
                Console.WriteLine("********************************************");
                Console.Write("Digite la opción: ");

                // Leer la opción ingresada por el usuario
                opcion = int.Parse(Console.ReadLine());

                // Switch statement para manejar la opción seleccionada por el usuario
                switch (opcion)
                {
                    case 1:
                        // Cálculo del volumen de una esfera
                        Console.Write("Ingrese el radio de la esfera en centímetros: ");
                        radio = Convert.ToDouble(Console.ReadLine());
                        resultado = 4.0 / 3.0 * Math.PI * Math.Pow(radio, 3);
                        Console.WriteLine("El volumen de la esfera es: " + resultado + " centímetros cúbicos");
                        Console.ReadKey();
                        break;
                    case 2:
                        // Cálculo del volumen de un cubo
                        Console.Write("Ingrese el valor de la arista del cubo en centímetros: ");
                        arista = Convert.ToDouble(Console.ReadLine());
                        resultado = Math.Pow(arista, 3);
                        Console.WriteLine("El volumen del cubo es: " + resultado + " centímetros cúbicos");
                        Console.ReadKey();
                        break;
                    case 3:
                        // Cálculo del volumen de un cilindro
                        Console.Write("Ingrese el radio de la base del cilindro en centímetros: ");
                        radio = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Ingrese la altura del cilindro en centímetros: ");
                        altura = Convert.ToDouble(Console.ReadLine());
                        resultado = Math.PI * Math.Pow(radio, 2) * altura;
                        Console.WriteLine("El volumen del cilindro es: " + resultado + " centímetros cúbicos");
                        Console.ReadKey();
                        break;
                    case 4:
                        // Salir del programa
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        // Opción inválida
                        Console.WriteLine("Opción inválida, por favor seleccione una opción correcta.");
                        Console.ReadKey();
                        break;
                }
            } while (opcion != 4); // El ciclo se repite mientras la opción ingresada sea diferente de 4 (Salir)


        }

    }

}
