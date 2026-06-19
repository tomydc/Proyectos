using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Gestion_de_Notas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] notas = new double[5]; 
            double sumaNotas = 0;           
            double promedio = 0;            
            double notaMasAlta = 0;         
            double notaMasBaja = 0;        
            int aprobados = 0;             
            int i = 0;                      
            double notaIngresada = 0;

            Console.WriteLine("===========================");
            Console.WriteLine("SISTEMA DE GESTIÓN DE NOTAS");
            Console.WriteLine("===========================");

            Console.WriteLine("Ingrese las notas de 5 alumnos (entre 0 y 10):");
         
            while (i < notas.Length)
            {
                Console.Write($"Alumno {i + 1}: ");
                if (double.TryParse(Console.ReadLine(), out notaIngresada) && notaIngresada >= 0 && notaIngresada <= 10)
                {
                    notas[i] = notaIngresada;
                    sumaNotas += notaIngresada;
                    if (i == 0 || notaIngresada > notaMasAlta)
                        notaMasAlta = notaIngresada;
                    if (i == 0 || notaIngresada < notaMasBaja)
                        notaMasBaja = notaIngresada;
                    if (notaIngresada >= 6)
                        aprobados++;
                    i++;
                }
                else
                {
                    Console.WriteLine("Nota no válida. Por favor, ingrese una nota entre 0 y 10.");
                }
                


            }
            promedio = sumaNotas / notas.Length;

            Console.Clear();

            Console.WriteLine("===========");
            Console.WriteLine("RESULTADOS:");
            Console.WriteLine("===========");

            Console.WriteLine("Promedio general: {0:F2}", promedio);
            Console.WriteLine("Nota más alta: {0:F2}", notaMasAlta);
            Console.WriteLine("Nota más baja: {0:F2}", notaMasBaja);
            Console.WriteLine("Cantidad de alumnos aprobados: {0}", aprobados);
        }
    }
}

