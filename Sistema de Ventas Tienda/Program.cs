using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sistema_de_Ventas_Tienda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<(string nombre, decimal precio)> productosVendidos = new List<(string, decimal)>();
            decimal totalVentas = 0;
            decimal precioMasCaro = 0;
            string productoMasCaro = "";
            decimal descuento = 0.1m; 
            decimal montoDescuento = 1000m; 

            Console.WriteLine("===============================");
            Console.WriteLine("SISTEMA DE VENTAS DE UNA TIENDA");
            Console.WriteLine("===============================");

            while (true)
            {
                Console.Write("Ingrese el nombre del producto (o 'salir' para terminar): ");
                string nombreProducto = Console.ReadLine();
                if (nombreProducto.ToLower() == "salir")
                    break;

                Console.Write("Ingrese el precio del producto: $");
                if (decimal.TryParse(Console.ReadLine(), out decimal precioProducto) && precioProducto > 0)
                {
                    productosVendidos.Add((nombreProducto, precioProducto));
                    totalVentas += precioProducto;

                    if (precioProducto > precioMasCaro)
                    {
                        precioMasCaro = precioProducto;
                        productoMasCaro = nombreProducto;
                    }
                }
                else
                {
                    Console.WriteLine("Precio no válido. Por favor, ingrese un número positivo.");
                }
            }

            Console.Clear ();

            Console.WriteLine("=================");
            Console.WriteLine("RESUMEN DE VENTAS");
            Console.WriteLine("================="); 

            if (totalVentas > montoDescuento)
            {
                totalVentas -= totalVentas * descuento;
                Console.WriteLine($"Se aplicó un descuento del {descuento * 100}% por superar ${montoDescuento}.");
            }

            Console.WriteLine($"\nTotal de ventas: ${totalVentas:F2}");
            if (!string.IsNullOrEmpty(productoMasCaro))
            {
                Console.WriteLine($"Producto más caro: {productoMasCaro} con un precio de ${precioMasCaro:F2}");
            }
        }
    }
}
