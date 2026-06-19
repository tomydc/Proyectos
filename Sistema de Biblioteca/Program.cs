using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Sistema de Biblioteca
//Funcionalidades
//Registrar libros.
//Buscar libro.
//Mostrar catálogo.
//Contar cantidad de libros.


namespace Sistema_de_Biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> catalogoLibros = new List<string>(); 
            bool ejecutando = true;                          
            string opcion = "";                             
            string nuevoLibro = "";                          
            bool tituloValido = false;                      
            bool encontrado = false;                         
            int i = 0;
            string libroBuscar = "";

            while (ejecutando)
            {
                Console.WriteLine("=== SISTEMA DE GESTIÓN DE BIBLIOTECA ===");
                Console.WriteLine("1. Registrar nuevo libro");
                Console.WriteLine("2. Buscar libro por título");
                Console.WriteLine("3. Mostrar catálogo completo");
                Console.WriteLine("4. Contar cantidad total de libros");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción (1-5): ");

                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        
                        Console.Clear();
                        Console.WriteLine("=== REGISTRAR NUEVO LIBRO ===");

                        tituloValido = false;
                        while (!tituloValido)
                        {
                            Console.Write("Ingrese el título del libro: ");
                            nuevoLibro = Console.ReadLine().Trim();

                            if (string.IsNullOrEmpty(nuevoLibro))
                            {
                                Console.WriteLine("Error: El título no puede estar vacío.\n");
                                continue;
                            }

                           
                            tituloValido = true;
                            for (i = 0; i < nuevoLibro.Length; i++)
                            {
                                if (!char.IsLetter(nuevoLibro[i]) && !char.IsWhiteSpace(nuevoLibro[i]))
                                {
                                    tituloValido = false;
                                    break;
                                }
                            }

                            if (!tituloValido)
                            {
                                Console.WriteLine("Error: El título solo debe contener letras (sin números ni símbolos).\n");
                            }
                        }

                        
                        catalogoLibros.Add(nuevoLibro);
                        Console.WriteLine($"\n¡El libro '{nuevoLibro}' ha sido registrado con éxito!");
                        break;

                    case "2":
                        
                        Console.Clear();
                        Console.WriteLine("=== BUSCAR LIBRO ===");

                        if (catalogoLibros.Count == 0)
                        {
                            Console.WriteLine("El catálogo está vacío. No hay libros para buscar.");
                        }
                        else
                        {
                            Console.Write("Ingrese el título del libro que desea buscar: ");
                            libroBuscar = Console.ReadLine().Trim();

                            encontrado = false;
                            for (i = 0; i < catalogoLibros.Count; i++)
                            {
                                
                                if (catalogoLibros[i].ToLower() == libroBuscar.ToLower())
                                {
                                    Console.WriteLine($"\n[Disponible] El libro '{catalogoLibros[i]}' se encuentra en la posición {i + 1}.");
                                    encontrado = true;
                                    break;
                                }
                            }

                            if (!encontrado)
                            {
                                Console.WriteLine($"\nNo se encontró ningún libro con el título '{libroBuscar}'.");
                            }
                        }
                        break;

                    case "3":
                        
                        Console.Clear();
                        Console.WriteLine("=== CATÁLOGO DE LIBROS ===");

                        if (catalogoLibros.Count == 0)
                        {
                            Console.WriteLine("La biblioteca no tiene libros registrados actualmente.");
                        }
                        else
                        {

                            catalogoLibros.Sort();
                            Console.WriteLine("Libros disponibles:");
                            for (i = 0; i < catalogoLibros.Count; i++)
                            {
                                Console.WriteLine($"- {catalogoLibros[i]}");
                            }
                        }
                        break;

                    case "4":

                        Console.Clear();
                        Console.WriteLine("=== CONTADOR DE LIBROS ===");
                        Console.WriteLine($"Actualmente hay un total de {catalogoLibros.Count} libro(s) registrado(s) en la biblioteca.");
                        break;

                    case "5":
               
                        Console.Clear();
                        Console.WriteLine("Cerrando el sistema de biblioteca. ¡Que tenga un buen día!");
                        ejecutando = false;
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Por favor, seleccione un número del 1 al 5.");
                        break;
                }

               
                if (ejecutando)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
    

