using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRET_F
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Establecer el título de la consola
            Console.Title = "Conversion de Unidades";

            // Establecer el color de fondo de la consola
            Console.BackgroundColor = ConsoleColor.Yellow;

            // Establecer el color del texto en la consola
            Console.ForegroundColor = ConsoleColor.Black;

            // Limpiar la consola con el color de fondo establecido
            Console.Clear();

            // Establecer la altura de la ventana de la consola
            Console.WindowHeight = 20; // alto de la ventana

            // Establecer el ancho de la ventana de la consola
            Console.WindowWidth = 60; //ancho de la ventana

            // Declarar variables para almacenar las conversiones de unidades
            double m, cm, mm, km;

            // Establecer el título de la consola para esta parte específica del programa
            Console.Title = "Conversion de metros a otras longitudes";

            // Imprimir mensaje solicitando la cantidad de metros a convertir y las unidades a las que se desea convertir
            Console.WriteLine("Dijite la cantidad de metros a convertir a: km, mm, cm");

            // Leer la entrada del usuario y almacenarla en la variable 'm'
            m = double.Parse(Console.ReadLine());

            // Realizar las conversiones de metros a otras unidades
            cm = m * 100; // Convertir metros a centímetros
            km = m / 1000; // Convertir metros a kilómetros
            mm = m * 10000; // Convertir metros a milímetros

            // Imprimir los resultados de las conversiones
            Console.WriteLine("La conversion es de: ");
            Console.WriteLine(" cm: " + cm + "cm\n km: " + km + "km\n mm: " + mm + "mm");

            // Esperar a que el usuario presione una tecla para salir
            Console.ReadLine();
            Console.ReadKey();

        }
    }
}
