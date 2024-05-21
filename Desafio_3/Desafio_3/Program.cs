using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace Desafio_3
{
    internal class Program
    {
        struct datoAlumnos
        {
            public string carnet;
            public string nombre;
            public string carrera;
            public double[] notas; //aqui se almacenaran dos notas, nota 1 y nota 2
        }
        static void Main(string[] args)
        {
            menu();
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
                    Console.WriteLine("1. Agregar alumnos.");
                    Console.WriteLine("2. Buscar alumnos.");
                    Console.WriteLine("3. Mostrar alumnos.");
                    Console.WriteLine("4. Salir.");
                    Console.WriteLine("*************************************");
                    Console.Write("Digite la opción: ");
                    opc = int.Parse(Console.ReadLine());

                    switch (opc)
                    {
                        case 1:
                            agregarAlumnos();
                            break;
                        case 2:
                            buscarAlumnos();
                            break;
                        case 3:
                            mostrarAlumnos();
                            break;
                        case 4:
                            Console.WriteLine("Saliendo del programa");
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
            } while (opc != 4);
        }
        private static void agregarAlumnos()
        {
            datoAlumnos alumnos ;
            alumnos.notas = new double[2];
            Console.WriteLine("\nIngresa los datos de los alumnos: \n");
            Console.Write("\tCarnet: ");
            alumnos.carnet = Console.ReadLine();
            Console.Write("\tNombre: ");
            alumnos.nombre = Console.ReadLine();
            Console.Write("\tCarrera: ");
            alumnos.carrera = Console.ReadLine();
            Console.Write("\tIngrese las 2 notas: \n ");
            double notasSuma = 0;
            for (int i = 0; i < alumnos.notas.Length; i++)
            {
                Console.Write($"\tNota {i + 1}: ");
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
            double promedio;
            string estado  = "Reprobado";
            promedio = notasSuma / alumnos.notas.Length; //2
            if (promedio > 5)
            {
                estado = "Aprobado";
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t**************************************************************\n");
            Console.Write($"\n\tAlumno: {alumnos.nombre} fue ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (estado == "Reprobado")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write($"{estado}\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"\n\tNota promedio de: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{Math.Round(promedio, 2)}\n\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t**************************************************************\n");
            string mess_exito_1, mess_exito_2;
            mess_exito_1 = mess_exito_2 = null;
            try
            {
                using (StreamWriter escribir = new StreamWriter("Datos.txt", true))
                {
                    string linea = $"{alumnos.carnet},{alumnos.nombre},{alumnos.carrera}";
                    escribir.WriteLine(linea);
                    mess_exito_1 = "Alumnos, agregado exitosamente";
                    
                }
                using (StreamWriter escribir = new StreamWriter("Notas.txt", true))
                {
                    string notasSeparadas = string.Join(", ", alumnos.notas);
                    string linea = $"{alumnos.carnet},{notasSeparadas}";
                        escribir.WriteLine(linea);
                    mess_exito_2 = "Notas, agregado exitosamente";
                }

               
            }
            catch (Exception messError)
            {
                Console.WriteLine($"Error: {messError.Message}");
                throw;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t**************************************************************\n\t");
            Console.WriteLine($"\t{ mess_exito_1}  y  {mess_exito_2}");
            Console.WriteLine("\tPresione Enter Para continuar. ");
            Console.WriteLine("\n\t**************************************************************\n");
        }

        private static void mostrarAlumnos()
        {
            try
            {
                string archivoDatos = "Datos.txt";
                string archivoNotas = "Notas.txt";
                string carnet = null, nombre = null, carrera = null;
                double nota1 = 0, nota2 = 0, promedio = 0;

                // Leer el archivo Datos.txt
                using (StreamReader leerDatos = new StreamReader(archivoDatos))
                {
                    string linea;
                    while ((linea = leerDatos.ReadLine()) != null)
                    {
                        char[] separador = { ',' };
                        string[] campos = linea.Split(separador);
                        carnet = campos[0].Trim();
                        nombre = campos[1].Trim();
                        carrera = campos[2].Trim();

                        // Leer el archivo Notas.txt
                        bool encontrado = false;
                        using (StreamReader lectura = new StreamReader(archivoNotas))
                        {
                            string cadena;
                            while ((cadena = lectura.ReadLine()) != null)
                            {
                                string[] camposNotas = cadena.Split(',');
                                if (camposNotas[0].Trim() == carnet)
                                {
                                    encontrado = true;
                                    nota1 = double.Parse(camposNotas[1].Trim());
                                    nota2 = double.Parse(camposNotas[2].Trim());

                                    promedio = nota1 + nota2;
                                    promedio = promedio / 2;
                                }
                            }
                        }

                        if (!encontrado)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\tEl Estudiante {nombre} No tiene Notas");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.WriteLine("\n ");
                            Console.WriteLine($"\tCarnet: {carnet}");
                            Console.WriteLine($"\tNombre: {nombre}");
                            Console.WriteLine($"\tCarrera: {carrera}");
                            Console.WriteLine($"\tNota 1: {Math.Round(nota1,2)}");
                            Console.WriteLine($"\tNota 2: {Math.Round(nota2,2)}");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"\tPromedio: {Math.Round(promedio, 2)}");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine();
                        }
                    }
                }




            }
            catch (Exception messError)
            {
                Console.WriteLine($"Error: {messError}");
                throw;
            }
        }

        private static void buscarAlumnos()
        {
            try
            {
                string archivoDatos = "Datos.txt";
                string archivoNotas = "Notas.txt";
                string carnet = null, nombre = null, carrera = null;
                double nota1 = 0, nota2 = 0, promedio = 0;

                // Leer el archivo Datos.txt

                Console.Write("Escriba el carnet del estudiante a buscar: ");
                carnet = Console.ReadLine();
                bool encontradoDato = false;
                using (StreamReader leerDatos = new StreamReader(archivoDatos))
                {
                    string linea;
                    while ((linea = leerDatos.ReadLine()) != null)
                    {
                        char[] separador = { ',' };
                        string[] campos = linea.Split(separador);
                        if (campos[0].Trim()==carnet.Trim())
                        {
                            encontradoDato = true;
                            carnet = campos[0].Trim();
                            nombre = campos[1].Trim();
                            carrera = campos[2].Trim();

                            // Leer el archivo Notas.txt
                            bool encontradoNotas = false;
                            using (StreamReader lectura = new StreamReader(archivoNotas))
                            {
                                string cadena;
                                while ((cadena = lectura.ReadLine()) != null)
                                {
                                    string[] camposNotas = cadena.Split(',');
                                    if (camposNotas[0].Trim() == carnet.Trim())
                                    {
                                        encontradoNotas = true;
                                        nota1 = double.Parse(camposNotas[1].Trim());
                                        nota2 = double.Parse(camposNotas[2].Trim());

                                        promedio = nota1 + nota2;
                                        promedio = promedio / 2;
                                    }
                                }
                            }
                            if (!encontradoNotas)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"\tEl Estudiante {nombre} No tiene Notas");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.WriteLine("\n ");
                                Console.WriteLine($"\tCarnet: {carnet}");
                                Console.WriteLine($"\tNombre: {nombre}");
                                Console.WriteLine($"\tCarrera: {carrera}");
                                Console.WriteLine($"\tNota 1: {Math.Round(nota1, 2)}");
                                Console.WriteLine($"\tNota 2: {Math.Round(nota2, 2)}");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine($"\tPromedio: {Math.Round(promedio, 2)}");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine();
                                Console.WriteLine("\n Enter Para continuar");
                            }
                        }

                        


                    }
                    if (!encontradoDato)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\tEl Estudiante {nombre} No Encontrado");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }




            }
            catch (Exception messError)
            {
                Console.WriteLine($"Error: {messError}");
                throw;
            }
        }

       
    }
}
