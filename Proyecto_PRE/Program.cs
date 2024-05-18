using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_PRE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            menu();
        }

        struct strEmpleados
        {
            public string nombre;
            public string apellido;
            public string sexo;
            public string correo;
            public double salario;
        }
        struct strAlumnos
        {
            public string nombre;
            public double[] notas;
            public double promedio;
            public string estado;
        }
        public static void menu()
        {
            int opc = 0;

            do
            {

                try
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Console.WriteLine("************** Menú ****************");
                    Console.WriteLine("1. Introducir datos empleado.");
                    Console.WriteLine("2. Mostrar datos empleados.");
                    Console.WriteLine("3. Introducir datos alumnos.");
                    Console.WriteLine("4. Mostrar datos alumnos.");
                    Console.WriteLine("5. Salir.");
                    Console.WriteLine("*************************************");
                    Console.Write("Digite la opción: ");
                    opc = int.Parse(Console.ReadLine());

                    switch (opc)
                    {
                        case 1:
                            agregarEmpleado();
                            break;
                        case 2:
                            mostrarEmpleados();
                            break;
                        case 3:
                            agregarAlumnos();
                            break;
                        case 4:
                            mostrarAlumnos();
                            break;
                        case 5:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n\t---------------------------------------------------------\n");
                            Console.WriteLine("\t\t\tSaliendo del programa\t".ToUpper());
                            Console.WriteLine("\n\t---------------------------------------------------------\n");
                            break;
                        default:
                            Console.WriteLine("Opcion no valida. Por favor, elija una opcion validas.");
                            break;
                    }

                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n---------------Entrada de dato no valido. Por favor, escribir una opcion valida---------------");
                    opc = 0;
                    Console.WriteLine($"\n---------------Error: {ex.Message}  ---------------\n");
                    Console.ReadLine();

                }
            } while (opc != 5);

            Console.ReadKey();
        }
        public static void agregarEmpleado()
        {

            strEmpleados empleados;
            //Ingresar los datos
            Console.WriteLine("\nIngrese los datos del empleado:");
            Console.Write("\tNombres: ");
            empleados.nombre = Console.ReadLine();
            Console.Write("\tApellidos: ");
            empleados.apellido = Console.ReadLine();
            do
            {
                Console.Write("\tSexo (M o F): ");
                empleados.sexo = Console.ReadLine();
                if (empleados.sexo != "M" && empleados.sexo != "m" && empleados.sexo != "F" && empleados.sexo != "f")
                {
                    Console.WriteLine("\tPor fa escriba 'M' o 'F'.");
                }
            } while (empleados.sexo != "M" && empleados.sexo != "m" && empleados.sexo != "F" && empleados.sexo != "f");
            Console.Write("\tCorreo electrónico: ");
            empleados.correo = Console.ReadLine();
            Console.Write("\tSalario: $");
            empleados.salario = Double.Parse(Console.ReadLine());

            double descuento;
            string descuentoTex = null;
            if (empleados.salario > 750)
            {
                descuento = empleados.salario * (10.00 / 100.00); //decuento  10%
                empleados.salario = empleados.salario - descuento;
                descuentoTex = " Se aplico descuento del 10% que son $" + descuento + " menos";
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n----------------------------------------------------------------------------\n");
            Console.WriteLine($"\t Nombres: {empleados.nombre}");
            Console.WriteLine($"\t Apellidos: {empleados.apellido}");
            Console.WriteLine($"\t Sexo: {empleados.sexo.ToUpper()}");
            Console.WriteLine($"\t Correo electrónico: {empleados.correo}");
            Console.WriteLine($"\t Salario: ${empleados.salario}{descuentoTex}");
            Console.ForegroundColor = ConsoleColor.White;
            string archivoEmpleado = "Empleados.txt";
            try
            {
                using (StreamWriter escribir = new StreamWriter(archivoEmpleado, true))//"Empleados.txt"
                {
                    string linea = $"{empleados.nombre}, {empleados.apellido}, {empleados.sexo.ToUpper()}, {empleados.correo}, {empleados.salario}{descuentoTex}";
                    escribir.WriteLine(linea);

                }
            }
            catch (Exception error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n---------------Error: {error.Message}  ---------------\n");
                Console.ReadLine();
            }


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nEmpleado Agregado Exitosamente : ) Presione Enter para continuar"); //  : )
        }
        public static void mostrarEmpleados()
        {
            try
            {
                String Opcion;
                String mensajeStarNotas = "No se abrio el archivo de texto";
                    Console.Write("\tDesea abrir el archivo de texto? (s/n): ");
                    Opcion = Console.ReadLine();
                    if (Opcion == "S" || Opcion == "s")
                    {
                        Process.Start("Empleados.txt");
                        mensajeStarNotas = "Archivo de texto abierto correctamente";
                    }
                using (StreamReader leer = new StreamReader("Empleados.txt"))
                {
                    string linea;
                    int fila = 0;
                    Console.WriteLine("\nLista de empleados:\n");

                    while ((linea = leer.ReadLine()) != null)
                    {
                        char[] separador = { ',' };
                        string[] campos = linea.Split(separador);

                        if (campos.Length < 5)
                        {
                            Console.WriteLine("Línea incompleta.");
                        }
                        // Mostrar los datos de los empleados
                        Console.WriteLine("\n----------------------------------------------------------------------------\n");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"Empleado {fila + 1}:");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Nombre: {campos[0].Trim()}");
                        Console.WriteLine($"Apellido: {campos[1].Trim()}");
                        Console.WriteLine($"Sexo: {campos[2].Trim()}");
                        Console.WriteLine($"Correo electrónico: {campos[3].Trim()}");
                        Console.WriteLine($"Salario: ${campos[4].Trim()}");

                        fila++;
                    }

                    if (fila == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("No hay empleados.");
                    }
                }
                Console.ForegroundColor= ConsoleColor.Blue;
                Console.WriteLine($"\n{mensajeStarNotas.ToUpper()}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error al mostrar empleados: {error.Message}");
            }
            
            Console.WriteLine("\n\nPresione Enter para continuar");
        }
        public static void agregarAlumnos()
        {

            strAlumnos alumnos;
            //Ingresar los datos
            Console.WriteLine("\n\tIngrese los datos del alumno:");
            Console.Write("\tNombre: ");
            alumnos.nombre = Console.ReadLine();
            alumnos.notas = new double[4];
            Console.WriteLine("\tIngrese Notas: ");
            double notasSuma = 0;
            for (int i = 0; i < alumnos.notas.Length; i++)
            {
                Console.Write($"\tNota {i+1}: ");
                alumnos.notas[i] = double.Parse(Console.ReadLine());
                
                if (alumnos.notas[i] >= 0 && alumnos.notas[i] <= 10)
                {
                    notasSuma += alumnos.notas[i]; // notaSuma = notaSuma + alumnos.notas[i]
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t**************************************************************\n");
                    Console.WriteLine("\n\tNo es una nota entre 0 y 10. Nota no valida intenta otra vez.\n");
                    Console.WriteLine("\n\t**************************************************************\n");
                    i--;
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            alumnos.promedio = notasSuma / alumnos.notas.Length; //4
            alumnos.estado = "Reprobado";
            string archivoAlumnos = "Alumnos.txt";
            string archivoAlumnosReApro = "AlumnosReprobados.txt";
            if (alumnos.promedio > 5)
            {
                alumnos.estado = "Aprobado";
                archivoAlumnosReApro = "AlumnosAprobados.txt";
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t**************************************************************\n");
            Console.Write($"\n\tAlumno: {alumnos.nombre} fue ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (alumnos.estado == "Reprobado")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write($"{alumnos.estado}\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"\n\tNota promedio de: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{Math.Round(alumnos.promedio, 2)}\n\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t**************************************************************\n");
            Console.ForegroundColor = ConsoleColor.White;

            //nombre del archivo
            try
            {
                // Guardar los datos 
                using (StreamWriter escribir = new StreamWriter(archivoAlumnosReApro, true))//"Alumnos.txt"
                {
                    string notasString = string.Join(", ", alumnos.notas);

                    string linea = $"{alumnos.nombre}, {notasString}, {alumnos.promedio}, {alumnos.estado}";
                    escribir.WriteLine(linea);
                }
                using (StreamWriter escribir = new StreamWriter(archivoAlumnos, true))//"Alumnos.txt"
                {
                    string notasString = string.Join(", ", alumnos.notas);

                    string linea = $"{alumnos.nombre}, {notasString}, {alumnos.promedio}, {alumnos.estado}";
                    escribir.WriteLine(linea);
                }
            }
            
            catch (Exception error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error.Message);
            }


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nAlumnos Agregado Exitosamente : ) Presione Enter para continuar"); //a  : )
        }
        public static void mostrarAlumnos()
        {
            try
            {

                String archivoAlumnos = "Alumnos.txt";
                int opcAlumnos;
                do
                {
                    Console.WriteLine("\n\tMostrar alumnos Reprobados o Aprobados: ");
                    Console.WriteLine("\t1 - Aprobados");
                    Console.WriteLine("\t2 - Reprobados");
                    Console.WriteLine("\t3 - Todos");
                    Console.Write("\tDigite la opción: ");
                    opcAlumnos = int.Parse(Console.ReadLine());
                
                    switch (opcAlumnos)
                    {
                        case 1:
                            archivoAlumnos = "AlumnosAprobados.txt";
                            break;
                        case 2:
                            archivoAlumnos = "AlumnosReprobados.txt";
                            break;
                        case 3:
                            archivoAlumnos = "Alumnos.txt"; ;
                            break;
                        default:
                            Console.WriteLine("Opcion no valida. Por favor, elija una opcion validas.");
                            continue;
                    }
                } while (opcAlumnos != 1 && opcAlumnos != 2 && opcAlumnos != 3);
                String Opcion;
                String mensajeStarAlumnos = "No se abrio el archivo de texto";
                Console.Write("\tDesea abrir el archivo de texto? (s/n): ");
                Opcion = Console.ReadLine();
                if (Opcion == "S" || Opcion == "s")
                {
                    Process.Start(archivoAlumnos);
                    mensajeStarAlumnos = "Archivo de texto abierto correctamente";

                }

                using (StreamReader leer = new StreamReader(archivoAlumnos))
                {
                    string linea;
                    int fila = 0;
                    Console.WriteLine("\nLista de alumnos:\n");

                    while ((linea = leer.ReadLine()) != null)
                    {
                        char[] separador = { ',' };
                        string[] campos = linea.Split(separador);

                        if (campos.Length < 5)
                        {
                            Console.WriteLine("Linea incompleta.");

                        }
                        // Mostrar los datos de los aluimnos
                        Console.WriteLine("\n----------------------------------------------------------------------------\n");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"\tAlumno {fila + 1}:");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\tNombre: {campos[0].Trim()}");
                        for (int i = 1; i <= 4; i++)
                        {
                            Console.WriteLine($"\tNota {i}: {campos[i].Trim()}");
                        }
                        Console.WriteLine($"\tPromedio:{campos[5].Trim()}");

                        if (campos[6].Trim().Equals("Reprobado"))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else { Console.ForegroundColor = ConsoleColor.Green;}

                        Console.WriteLine($"\tEstado: {campos[6].Trim()}");

                        Console.ForegroundColor = ConsoleColor.White;
                        fila++;
                    }

                    if (fila == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\tNo hay alumnos.");
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"\n{mensajeStarAlumnos.ToUpper()}");
                    Console.ForegroundColor = ConsoleColor.White;

                }
            }
            catch (Exception error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error al mostrar alumnos: {error.Message}");
            }

            Console.WriteLine("\n\nPresione Enter para continuar");
        }

    }
}