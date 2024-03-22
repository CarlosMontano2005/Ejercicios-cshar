using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRET_H
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Establecer el título de la consola
            Console.Title = "Calculo de notas";

            // Establecer el color de fondo de la consola
            Console.BackgroundColor = ConsoleColor.White;

            // Establecer el color del texto en la consola
            Console.ForegroundColor = ConsoleColor.Black;

            // Limpiar la consola con el color de fondo establecido
            Console.Clear();

            // Establecer la altura de la ventana de la consola
            Console.WindowHeight = 20; // alto de la ventana

            // Establecer el ancho de la ventana de la consola
            Console.WindowWidth = 65; // ancho de la ventana

            // Declarar variables para almacenar las notas y el promedio
            double nota_1, nota_2, nota_3, promedio;

            // Solicitar y almacenar las tres notas del usuario
            Console.Title = "Notas promedio PAL";
            Console.WriteLine("Ingrese la Nota #1");
            nota_1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la Nota #2");
            nota_2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la Nota #3");
            nota_3 = double.Parse(Console.ReadLine());

            // Calcular el promedio de las tres notas ingresadas
            promedio = (nota_1 + nota_2 + nota_3) / 3; // Suma de notas entre la cantidad de notas 

            // Determinar si el estudiante pasó la materia basado en su promedio
            if (promedio >= 7)
            {
                // Verificar si el promedio es 10
                if (promedio == 10)
                {
                    Console.WriteLine("Felicidades tu nota alcanzó los 10: " + promedio);
                }
                else
                {
                    Console.WriteLine("Pasaste la materia con una nota de : " + Math.Round(promedio, 2)); // Redondear el promedio a 2 decimales
                }
            }
            else
            {
                Console.WriteLine("Lamentablemente no pasas la materia con una nota de : " + Math.Round(promedio, 2)); // Redondear el promedio a 2 decimales
            }

            // Esperar a que el usuario presione una tecla para salir
            Console.ReadLine();
            Console.ReadKey();

        }
    }
}
