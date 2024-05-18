using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Proyecto_PRE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Configurar la configuración regional para usar el punto como separador decimal
            CultureInfo cultureInfo = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            menu();
        }
        //creando estructura empleado
        struct strEmpleados
        {
            public string nombre;
            public string apellido;
            public string sexo;
            public string correo;
            public double salario;
        }
        //creando estructura alumnos
        struct strAlumnos
        {
            public string nombre;
            public double[] notas;
            public double promedio;
            public string estado;
        }
        //funcion menu
        public static void menu()
        {
            int opc = 0; // Variable para almacenar la opción seleccionada por el usuario

            do
            {
                try
                {
                    // Configurar colores de la consola
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear(); // Limpiar la consola

                    // Mostrar el menú al usuario
                    Console.WriteLine("************** Menú ****************");
                    Console.WriteLine("1. Introducir datos empleado.");
                    Console.WriteLine("2. Mostrar datos empleados.");
                    Console.WriteLine("3. Introducir datos alumnos.");
                    Console.WriteLine("4. Mostrar datos alumnos.");
                    Console.WriteLine("5. Salir.");
                    Console.WriteLine("*************************************");
                    Console.Write("Digite la opción: ");

                    // Leer la opción seleccionada por el usuario y convertirla a entero
                    opc = int.Parse(Console.ReadLine());

                    // Evaluar la opción seleccionada
                    switch (opc)
                    {
                        case 1:
                            agregarEmpleado(); // Llamar al método para agregar empleado
                            break;
                        case 2:
                            mostrarEmpleados(); // Llamar al método para mostrar empleados
                            break;
                        case 3:
                            agregarAlumnos(); // Llamar al método para agregar alumnos
                            break;
                        case 4:
                            mostrarAlumnos(); // Llamar al método para mostrar alumnos
                            break;
                        case 5:
                            // Mensaje de salida del programa
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\n\t---------------------------------------------------------\n");
                            Console.WriteLine("\t\t\tSaliendo del programa\t".ToUpper());
                            Console.WriteLine("\n\t---------------------------------------------------------\n");
                            break;
                        default:
                            // Mensaje en caso de opción no válida
                            Console.WriteLine("Opcion no valida. Por favor, elija una opcion validas.");
                            break;
                    }

                    // Esperar que el usuario presione una tecla para continuar
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción que ocurra durante la lectura de la opción
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;
                    // Mensaje de error y mostrar la excepción
                    Console.WriteLine("\n---------------Entrada de dato no valido. Por favor, escribir una opcion valida---------------");
                    opc = 0; // Reiniciar la opción para continuar el bucle
                    Console.WriteLine($"\n---------------Error: {ex.Message}  ---------------\n");
                    Console.ReadLine();
                }
            } while (opc != 5); // Continuar el bucle mientras la opción no sea 5 (salir)

            // Esperar que el usuario presione una tecla antes de cerrar la aplicación
            Console.ReadKey();
        }
        //funcion agregar empleado
        public static void agregarEmpleado()
        {
            strEmpleados empleados; // Declaración de la variable para almacenar los datos del empleado

            // Ingresar los datos del empleado
            Console.WriteLine("\nIngrese los datos del empleado:");
            Console.Write("\tNombres: ");
            empleados.nombre = Console.ReadLine(); // Leer el nombre del empleado
            Console.Write("\tApellidos: ");
            empleados.apellido = Console.ReadLine(); // Leer el apellido del empleado

            // Solicitar y validar el sexo del empleado
            do
            {
                Console.Write("\tSexo (M o F): ");
                empleados.sexo = Console.ReadLine(); // Leer el sexo del empleado
                if (empleados.sexo != "M" && empleados.sexo != "m" && empleados.sexo != "F" && empleados.sexo != "f")
                {
                    Console.WriteLine("\tPor fa escriba 'M' o 'F'."); // Mensaje de error si el sexo no es válido
                }
            } while (empleados.sexo != "M" && empleados.sexo != "m" && empleados.sexo != "F" && empleados.sexo != "f");

            Console.Write("\tCorreo electrónico: ");
            empleados.correo = Console.ReadLine(); // Leer el correo electrónico del empleado
            Console.Write("\tSalario: $");
            empleados.salario = Double.Parse(Console.ReadLine()); // Leer el salario del empleado y convertirlo a doble

            double descuento;
            string descuentoTex = null;

            // Aplicar descuento si el salario es mayor a 750
            if (empleados.salario > 750)
            {
                descuento = empleados.salario * (10.00 / 100.00); // Calcular el descuento del 10%
                empleados.salario = empleados.salario - descuento; // Restar el descuento del salario
                descuentoTex = " Se aplico descuento del 10% que son $" + descuento + " menos"; // Mensaje de descuento
            }

            // Mostrar los datos del empleado en la consola
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n----------------------------------------------------------------------------\n");
            Console.WriteLine($"\t Nombres: {empleados.nombre}");
            Console.WriteLine($"\t Apellidos: {empleados.apellido}");
            Console.WriteLine($"\t Sexo: {empleados.sexo.ToUpper()}");
            Console.WriteLine($"\t Correo electrónico: {empleados.correo}");
            Console.WriteLine($"\t Salario: ${empleados.salario}{descuentoTex}");
            Console.ForegroundColor = ConsoleColor.White;

            string archivoEmpleado = "Empleados.txt"; // Nombre del archivo donde se guardarán los datos del empleado
            try
            {
                // Abrir el archivo para agregar datos (en modo de añadir al final)
                using (StreamWriter escribir = new StreamWriter(archivoEmpleado, true))
                {
                    // Crear una línea con los datos del empleado
                    string linea = $"{empleados.nombre}, {empleados.apellido}, {empleados.sexo.ToUpper()}, {empleados.correo}, {empleados.salario}{descuentoTex}";
                    escribir.WriteLine(linea); // Escribir la línea en el archivo
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra durante la escritura del archivo
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n---------------Error: {ex.Message}  ---------------\n");
                Console.ReadLine();
            }

            // Mensaje de confirmación de que el empleado ha sido agregado
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nEmpleado Agregado Exitosamente : ) Presione Enter para continuar");
        }
        // funcion mostrar empleado
        public static void mostrarEmpleados()
        {
            try
            {
                String Opcion; // Variable para almacenar la opción del usuario
                String mensajeStarNotas = "No se abrio el archivo de texto"; // Mensaje predeterminado si no se abre el archivo

                // Preguntar al usuario si desea abrir el archivo de texto
                Console.Write("\tDesea abrir el archivo de texto? (s/n): ");
                Opcion = Console.ReadLine();

                if (Opcion == "S" || Opcion == "s")
                {
                    // Abrir el archivo de texto con el programa predeterminado del sistema
                    Process.Start("Empleados.txt");
                    mensajeStarNotas = "Archivo de texto abierto correctamente";
                }

                // Leer el archivo de texto "Empleados.txt"
                using (StreamReader leer = new StreamReader("Empleados.txt"))
                {
                    string linea;
                    int fila = 0; // Contador para el número de empleados
                    Console.WriteLine("\nLista de empleados:\n");

                    // Leer cada línea del archivo
                    while ((linea = leer.ReadLine()) != null)
                    {
                        // Separar la línea en campos utilizando la coma como separador
                        char[] separador = { ',' };
                        string[] campos = linea.Split(separador);

                        if (campos.Length < 5)
                        {
                            // Mensaje si la línea está incompleta
                            Console.WriteLine("Línea incompleta.");
                        }

                        // Mostrar los datos de los empleados
                        Console.WriteLine("\n----------------------------------------------------------------------------\n");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"Empleado {fila + 1}:"); // Mostrar el número de empleado
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"Nombre: {campos[0].Trim()}"); // Mostrar el nombre del empleado
                        Console.WriteLine($"Apellido: {campos[1].Trim()}"); // Mostrar el apellido del empleado
                        Console.WriteLine($"Sexo: {campos[2].Trim()}"); // Mostrar el sexo del empleado
                        Console.WriteLine($"Correo electrónico: {campos[3].Trim()}"); // Mostrar el correo electrónico del empleado
                        Console.WriteLine($"Salario: ${campos[4].Trim()}"); // Mostrar el salario del empleado

                        fila++; // Incrementar el contador de empleados
                    }

                    // Mensaje si no hay empleados en el archivo
                    if (fila == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("No hay empleados.");
                    }
                }

                // Mostrar mensaje si se abrió el archivo de texto correctamente
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\n{mensajeStarNotas.ToUpper()}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra durante la lectura del archivo
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error al mostrar empleados: {ex.Message}");
            }

            // Mensaje para que el usuario presione Enter para continuar
            Console.WriteLine("\n\nPresione Enter para continuar");
        }
        //funcion agregar alumnos
        public static void agregarAlumnos()
        {
            strAlumnos alumnos; // Declaración de la variable para almacenar los datos del alumno

            // Ingresar los datos del alumno
            Console.WriteLine("\n\tIngrese los datos del alumno:");
            Console.Write("\tNombre: ");
            alumnos.nombre = Console.ReadLine(); // Leer el nombre del alumno
            alumnos.notas = new double[4]; // Inicializar el array de notas del alumno
            Console.WriteLine("\tIngrese Notas: ");
            double notasSuma = 0; // Variable para sumar las notas

            // Bucle para ingresar las notas
            for (int i = 0; i < alumnos.notas.Length; i++)
            {
                Console.Write($"\tNota {i + 1}: ");
                alumnos.notas[i] = double.Parse(Console.ReadLine()); // Leer cada nota y convertirla a doble

                if (alumnos.notas[i] >= 0 && alumnos.notas[i] <= 10)
                {
                    notasSuma += alumnos.notas[i]; // Sumar la nota a la suma total
                }
                else
                {
                    // Mensaje de error si la nota no está entre 0 y 10
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t**************************************************************\n");
                    Console.WriteLine("\n\tNo es una nota entre 0 y 10. Nota no valida intenta otra vez.\n");
                    Console.WriteLine("\n\t**************************************************************\n");
                    i--; // Decrementar el índice para volver a pedir la nota
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            // Calcular el promedio de las notas
            alumnos.promedio = notasSuma / alumnos.notas.Length; // 4
            alumnos.estado = "Reprobado"; // Inicializar el estado como "Reprobado"
            string archivoAlumnos = "Alumnos.txt"; // Nombre del archivo general de alumnos
            string archivoAlumnosReApro = "AlumnosReprobados.txt"; // Nombre del archivo para alumnos reprobados

            if (alumnos.promedio > 5)
            {
                alumnos.estado = "Aprobado"; // Cambiar el estado a "Aprobado" si el promedio es mayor a 5
                archivoAlumnosReApro = "AlumnosAprobados.txt"; // Cambiar el archivo a "AlumnosAprobados.txt"
            }

            // Mostrar el estado del alumno en la consola
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t**************************************************************\n");
            Console.Write($"\n\tAlumno: {alumnos.nombre} fue ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (alumnos.estado == "Reprobado")
            {
                Console.ForegroundColor = ConsoleColor.Red; // Cambiar el color si el alumno está reprobado
            }
            Console.Write($"{alumnos.estado}\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"\n\tNota promedio de: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{Math.Round(alumnos.promedio, 2)}\n\n"); // Mostrar el promedio redondeado a 2 decimales
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t**************************************************************\n");
            Console.ForegroundColor = ConsoleColor.White;

            try
            {
                // Guardar los datos del alumno en el archivo correspondiente (aprobados o reprobados)
                using (StreamWriter escribir = new StreamWriter(archivoAlumnosReApro, true))
                {
                    string notasString = string.Join(", ", alumnos.notas); // Convertir las notas a una cadena separada por comas
                    string linea = $"{alumnos.nombre}, {notasString}, {alumnos.promedio}, {alumnos.estado}";
                    escribir.WriteLine(linea); // Escribir la línea en el archivo
                }

                // Guardar los datos del alumno en el archivo general de alumnos
                using (StreamWriter escribir = new StreamWriter(archivoAlumnos, true))
                {
                    string notasString = string.Join(", ", alumnos.notas); // Convertir las notas a una cadena separada por comas
                    string linea = $"{alumnos.nombre}, {notasString}, {alumnos.promedio}, {alumnos.estado}";
                    escribir.WriteLine(linea); // Escribir la línea en el archivo
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra durante la escritura del archivo
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }

            // Mensaje de confirmación de que el alumno ha sido agregado
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nAlumnos Agregado Exitosamente : ) Presione Enter para continuar");
        }
        //funcion mostrar alumnos
        public static void mostrarAlumnos()
        {
            try
            {
                String archivoAlumnos = "Alumnos.txt"; // Nombre del archivo de alumnos por defecto
                int opcAlumnos; // Variable para almacenar la opción del usuario

                do
                {
                    // Mostrar el menú para seleccionar qué alumnos mostrar
                    Console.WriteLine("\n\tMostrar alumnos Reprobados o Aprobados: ");
                    Console.WriteLine("\t1 - Aprobados");
                    Console.WriteLine("\t2 - Reprobados");
                    Console.WriteLine("\t3 - Todos");
                    Console.Write("\tDigite la opción: ");
                    opcAlumnos = int.Parse(Console.ReadLine()); // Leer la opción seleccionada

                    // Seleccionar el archivo correspondiente según la opción elegida
                    switch (opcAlumnos)
                    {
                        case 1:
                            archivoAlumnos = "AlumnosAprobados.txt"; // Mostrar alumnos aprobados
                            break;
                        case 2:
                            archivoAlumnos = "AlumnosReprobados.txt"; // Mostrar alumnos reprobados
                            break;
                        case 3:
                            archivoAlumnos = "Alumnos.txt"; // Mostrar todos los alumnos
                            break;
                        default:
                            Console.WriteLine("Opcion no valida. Por favor, elija una opcion valida.");
                            continue; // Repetir el bucle si la opción no es válida
                    }
                } while (opcAlumnos != 1 && opcAlumnos != 2 && opcAlumnos != 3);

                // Preguntar al usuario si desea abrir el archivo de texto
                String Opcion;
                String mensajeStarAlumnos = "No se abrio el archivo de texto";
                Console.Write("\tDesea abrir el archivo de texto? (s/n): ");
                Opcion = Console.ReadLine();

                if (Opcion == "S" || Opcion == "s")
                {
                    // Abrir el archivo de texto con el programa predeterminado del sistema
                    Process.Start(archivoAlumnos);
                    mensajeStarAlumnos = "Archivo de texto abierto correctamente";
                }

                // Leer el archivo de texto seleccionado
                using (StreamReader leer = new StreamReader(archivoAlumnos))
                {
                    string linea;
                    int fila = 0; // Contador para el número de alumnos
                    Console.WriteLine("\nLista de alumnos:\n");

                    // Leer cada línea del archivo
                    while ((linea = leer.ReadLine()) != null)
                    {
                        // Separar la línea en campos utilizando la coma como separador
                        char[] separador = { ',' };
                        string[] campos = linea.Split(separador);

                        if (campos.Length < 5)
                        {
                            Console.WriteLine("Linea incompleta.");
                        }

                        // Mostrar los datos de los alumnos
                        Console.WriteLine("\n----------------------------------------------------------------------------\n");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"\tAlumno {fila + 1}:"); // Mostrar el número de alumno
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"\tNombre: {campos[0].Trim()}"); // Mostrar el nombre del alumno

                        // Mostrar las notas del alumno
                        for (int i = 1; i <= 4; i++)
                        {
                            Console.WriteLine($"\tNota {i}: {campos[i].Trim()}");
                        }

                        // Mostrar el promedio del alumno
                        Console.WriteLine($"\tPromedio: {campos[5].Trim()}");

                        // Cambiar el color del texto según el estado del alumno
                        if (campos[6].Trim().Equals("Reprobado"))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }

                        // Mostrar el estado del alumno
                        Console.WriteLine($"\tEstado: {campos[6].Trim()}");
                        Console.ForegroundColor = ConsoleColor.White;

                        fila++; // Incrementar el contador de alumnos
                    }

                    // Mensaje si no hay alumnos en el archivo
                    if (fila == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\tNo hay alumnos.");
                    }

                    // Mostrar mensaje si se abrió el archivo de texto correctamente
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"\n{mensajeStarAlumnos.ToUpper()}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra durante la lectura del archivo
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error al mostrar alumnos: {ex.Message}");
            }

            // Mensaje para que el usuario presione Enter para continuar
            Console.WriteLine("\n\nPresione Enter para continuar");
        }


    }
}
