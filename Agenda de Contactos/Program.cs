using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_de_Contactos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> contactos = new List<string>(); 
            bool ejecutando = true;                    
            string opcion = "";                         
            string nuevoContacto = "";                 
            string contactoBuscar = "";                 
            bool nombreValido = false;                  
            bool encontrado = false;                    
            int i = 0;                                 


            while (ejecutando)
            {
                Console.WriteLine("=== AGENDA DE CONTACTOS ===");
                Console.WriteLine("1. Agregar contacto");
                Console.WriteLine("2. Mostrar todos los contactos");
                Console.WriteLine("3. Buscar contacto por nombre");
                Console.WriteLine("4. Eliminar contacto");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción (1-5): ");

                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        
                        Console.Clear();
                        Console.WriteLine("=== AGREGAR CONTACTO ===");

                        nombreValido = false;
                        while (!nombreValido)
                        {
                            Console.Write("Ingrese el nombre del nuevo contacto: ");
                            nuevoContacto = Console.ReadLine().Trim();

                            if (string.IsNullOrEmpty(nuevoContacto))
                            {
                                Console.WriteLine("Error: El nombre no puede estar vacío.\n");
                                continue;
                            }

                           
                            nombreValido = true;
                            for (i = 0; i < nuevoContacto.Length; i++)
                            {
                                if (!char.IsLetter(nuevoContacto[i]) && !char.IsWhiteSpace(nuevoContacto[i]))
                                {
                                    nombreValido = false;
                                    break;
                                }
                            }

                            if (!nombreValido)
                            {
                                Console.WriteLine("Error: El nombre solo debe contener letras.\n");
                            }
                        }

                        
                        contactos.Add(nuevoContacto);
                        Console.WriteLine($"\n¡'{nuevoContacto}' ha sido agregado con éxito!");
                        break;

                    case "2":
                        
                        Console.Clear();
                        Console.WriteLine("=== LISTA DE CONTACTOS ===");

                        if (contactos.Count == 0)
                        {
                            Console.WriteLine("La agenda está vacía.");
                        }
                        else
                        {
                            
                            contactos.Sort();
                            for (i = 0; i < contactos.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {contactos[i]}");
                            }
                        }
                        break;

                    case "3":
                       
                        Console.Clear();
                        Console.WriteLine("=== BUSCAR CONTACTO ===");
                        Console.Write("Ingrese el nombre que desea buscar: ");
                        contactoBuscar = Console.ReadLine().Trim();

                        encontrado = false;
                        for (i = 0; i < contactos.Count; i++)
                        {
                            
                            if (contactos[i].ToLower() == contactoBuscar.ToLower())
                            {
                                Console.WriteLine($"\n[Encontrado] Contacto registrado: {contactos[i]} (Posición {i + 1})");
                                encontrado = true;
                                break;
                            }
                        }

                        if (!encontrado)
                        {
                            Console.WriteLine($"\nNo se encontró ningún contacto con el nombre '{contactoBuscar}'.");
                        }
                        break;

                    case "4":
                       
                        Console.Clear();
                        Console.WriteLine("=== ELIMINAR CONTACTO ===");
                        Console.Write("Ingrese el nombre del contacto a eliminar: ");
                        contactoBuscar = Console.ReadLine().Trim();

                        encontrado = false;
                        for (i = 0; i < contactos.Count; i++)
                        {
                            if (contactos[i].ToLower() == contactoBuscar.ToLower())
                            {
                                Console.WriteLine($"\nContacto '{contactos[i]}' eliminado correctamente.");
                                contactos.RemoveAt(i); 
                                encontrado = true;
                                break;
                            }
                        }

                        if (!encontrado)
                        {
                            Console.WriteLine($"\nNo se pudo eliminar: '{contactoBuscar}' no existe en la agenda.");
                        }
                        break;

                    case "5":
                        
                        Console.Clear();
                        Console.WriteLine("SALISTE DE LA AGENDA");
                        ejecutando = false;
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
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
    

