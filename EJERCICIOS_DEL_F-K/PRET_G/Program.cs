using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRET_G
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Establecer el título de la consola
            Console.Title = "Calculo de salario de un empleado";

            // Establecer el color de fondo de la consola
            Console.BackgroundColor = ConsoleColor.Blue;

            // Establecer el color del texto en la consola
            Console.ForegroundColor = ConsoleColor.Black;

            // Limpiar la consola con el color de fondo establecido
            Console.Clear();

            // Establecer la altura de la ventana de la consola
            Console.WindowHeight = 20; // alto de la ventana

            // Establecer el ancho de la ventana de la consola
            Console.WindowWidth = 90; // ancho de la ventana

            // Declarar una variable para almacenar el nombre del empleado
            string nomEmpleado;

            // Imprimir mensaje solicitando el nombre del empleado y leer la entrada del usuario
            Console.WriteLine("Nombre del Empleado: ");
            nomEmpleado = Console.ReadLine();

            // Declarar variables para almacenar el número total de horas trabajadas en el mes y el salario total a pagar
            int TiempoMes;
            double pagoTotal;

            // Imprimir mensaje solicitando el número total de horas trabajadas en el mes y leer la entrada del usuario
            Console.WriteLine("Horas Totales Trabajadas del mes: ");
            TiempoMes = int.Parse(Console.ReadLine());

            // Calcular el salario total a pagar según el número de horas trabajadas
            if (TiempoMes > 150)
            {
                pagoTotal = TiempoMes * 30;
            }
            else
            {
                if (TiempoMes == 150)
                {
                    //se suma las 30 horas mas las  20 horas y se divide entre 2 osea la cantidad que hay para un promedio de tiempo 
                    pagoTotal = TiempoMes * ((30 + 20) / 2); // 30 + 20 = 50 / 2 = 25 se hace un aproximado 
                }
                else
                {
                    pagoTotal = TiempoMes * 20;
                }
            }

            // Imprimir el salario total a pagar y los detalles del empleado y las horas trabajadas
            Console.WriteLine("El total salario a pagar por las horas trabajas " + TiempoMes + " horas Del Empleado " + nomEmpleado + " Es de : $" + pagoTotal);
            Console.WriteLine("\tEmpleado : " + nomEmpleado);
            Console.WriteLine("\tHoras Total Mes : " + TiempoMes);
            Console.WriteLine("\tPago de Salario : $" + pagoTotal);

            // Esperar a que el usuario presione una tecla para salir
            Console.ReadLine();
            Console.ReadKey();

        }
    }
}
