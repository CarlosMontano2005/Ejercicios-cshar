using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace PRET_I_Rockola

{

    internal class Program

    {

        static void Main(string[] args)

        {

            //variable de tipo int para ecojer la cacnion 
            Console.Title = "Rockola";
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WindowHeight = 20; // alto de la ventana
            Console.WindowWidth = 65; //ancho de la ventana
            int generoCancion;

            // estructura repetitiva do 

            do
            {
                Console.Clear();

                //escojer que tipo de cancion 
                Console.WriteLine("Selecciona un género de música:");

                Console.WriteLine("1. Cumbias");

                Console.WriteLine("2. Salsa");

                Console.WriteLine("3. Rock Ingles");

                Console.WriteLine("4. Rock Español");

                Console.WriteLine("5. Románticas");

                Console.WriteLine("6. POP");

                Console.WriteLine("7. Salir");

                generoCancion = int.Parse(Console.ReadLine());



                switch (generoCancion)

                {

                    case 1:

                        //mandamos a llamar el metodo y le mandamos el numero del genero y como se llama el genero 

                        MostrarCanciones(generoCancion, "Cumbia");

                        break;

                    case 2:

                        MostrarCanciones(generoCancion, "Salsa");

                        break;

                    case 3:

                        MostrarCanciones(generoCancion, "Rock Ingles");

                        break;

                    case 4:

                        MostrarCanciones(generoCancion, "Rock Español");

                        break;

                    case 5:

                        MostrarCanciones(generoCancion, "Romantica");

                        break;

                    case 6:

                        MostrarCanciones(generoCancion, "POP");

                        break;

                    case 7:

                        Console.WriteLine("¡Fin de la Rockola!");

                        break;

                    default:

                        Console.WriteLine("Opción no válida. Por favor, selecciona un número del 1 al 7.");

                        break;

                }



                //parte de la estructura repetitiva si es diferente aciente esta dentro pero si es igual sale 

            } while (generoCancion != 7);





            Console.ReadKey();

        }

        //metodo statico que resive dos dato tipo int y string que se manda a llamar para mostrar 5 cumbias, salsas, rock open ingles, rock esnol 

        static void MostrarCanciones(int genero, string nombreGenero)

        {

            //mostrar el genero que seleccion el numero 

            Console.WriteLine("\tGénero: " + nombreGenero);

            //mostrar la canciones 

            Console.WriteLine("\tCanciones disponibles:");

            //utilizar el mismo numero para ver las canciones que estan disponibles solo ver 

            switch (genero)

            {

                case 1:

                    Console.WriteLine("\t1. Cumbia El Listón De Tu Pelo (Los Angeles Azules)");

                    Console.WriteLine("\t2. Cumbia El Afilador (Grupo Carabo) ");

                    Console.WriteLine("\t3. Cumbia Te Digo Vete (Los Askis) ");

                    Console.WriteLine("\t4. Cumbia Conga y timbal (Yaguaru)");

                    Console.WriteLine("\t5. Cumbia Amor Carnal (Chon Arauza y La Furia Colombiana)");

                    Console.WriteLine("\n\tPresione Enter para Continuar");
                    Console.ReadLine();
                    break;

                case 2:

                    Console.WriteLine("\t1. Salsa Eddie Palmieri-“Vamonos Pal Monte”");

                    Console.WriteLine("\t2. Salsa Willie Colon/Hector Lavoe- “Che Che Cole”");

                    Console.WriteLine("\t3. Salsa Ray Barretto- “Indestructible”");

                    Console.WriteLine("\t4. Salsa Eddie Palmieri- “Puerto Rico”");

                    Console.WriteLine("\t5. Salsa Fajardo y sus Estrellas- “Tocala”");
                    Console.WriteLine("\n\tPresione Enter para Continuar");
                    Console.ReadLine();
                    break;

                case 3:

                    Console.WriteLine("\t1. Rock Ingles Hotel California – The Eagles.");

                    Console.WriteLine("\t2. Rock Ingles We are the champions – Queen. ");

                    Console.WriteLine("\t3. Rock Ingles Wind of change – Scorpions. ");

                    Console.WriteLine("\t4. Rock Ingles Have you ever seen the rain");

                    Console.WriteLine("\t5. Rock Ingles Heroes – David Bowie.");
                    Console.WriteLine("\n\tPresione Enter para Continuar");
                    Console.ReadLine();
                    break;

                case 4:

                    Console.WriteLine("\t1. Rock Español Por la boca vive el pez. Fito y Fitipaldis.");

                    Console.WriteLine("\t2. Rock Español So payaso. Extremoduro.");

                    Console.WriteLine("\t3. Rock Español Rock & Roll Star (feat. Sabino Méndez) - Bec 05. ");

                    Console.WriteLine("\t4. Rock Español Agradecido - Directo 99. Rosendo.");

                    Console.WriteLine("\t5. Rock Español El roce de tu cuerpo. Platero Y Tu.");
                    Console.WriteLine("\n\tPresione Enter para Continuar");
                    Console.ReadLine();
                    break;

                case 5:

                    Console.WriteLine("\t1. Romantica Río Roma y Fonseca – Caminar de tu mano");

                    Console.WriteLine("\t2. Camilo – Favorito. ");

                    Console.WriteLine("\t3. Romantica La Quinta Estación – Algo Más. ");

                    Console.WriteLine("\t4. Romantica SShakira – Antología. ");

                    Console.WriteLine("\t5. Romantica Sebastián Yatra – No hay Nadie Más.");
                    Console.WriteLine("\n\tPresione Enter para Continuar");
                    Console.ReadLine();
                    break;

                case 6:

                    Console.WriteLine("\t1. POT Olivia Rodrigo - deja vu ");

                    Console.WriteLine("\t2. POT Ariana Grande - yes, and?");

                    Console.WriteLine("\t3. POT The Weeknd - Save Your Tears ");

                    Console.WriteLine("\t4. POT Die For You");

                    Console.WriteLine("\t5. POT Joji - Die For You\r\n");
                    Console.WriteLine("\n\tPresione Enter para Continuar");
                    Console.ReadLine();
                    break;

                default:

                    Console.WriteLine("\tMusica no Encontrada o Reconocidad.");

                    break;



            }

        }

    }

}



