//Creado por Ignacio Rivera
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Sucursal> sucursales = new List<Sucursal>();
            Sucursal sucursal = null;
            const int cantSucursales = 5;            
            string opcion = string.Empty;
            Random randy = new Random();

            CrearSucursales(cantSucursales);
            Console.WriteLine("Bienvenido a la corporación Paraguas");
            ListarSucursales();

            Console.WriteLine("Por favor seleccione una sucursal indicando su indice o codigo");
            AsignarSucursal(Console.ReadLine());
            while (sucursal == null)
            {
                Console.WriteLine("Por favor seleccione una sucursal indicando su indice o codigo");
                AsignarSucursal(Console.ReadLine());
            }           

            while (!opcion.Equals("SALIR"))
            {
                switch (opcion)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }

            }


            void CrearSucursales(int cantidad)
            {
                for (int i = 0; i < cantidad-1; i++)
                {
                    sucursales.Add(new Sucursal(GenerarCodigoAleatorio(3)));
                }
            }

            void ListarSucursales()
            {
                Console.WriteLine("Lista de sucursales");
                for (int i = 0; i < sucursales.Count; i++)
                {
                    Console.WriteLine($"Indice: {i} | Codigo: {sucursales[i].codigo}");
                }
                Console.WriteLine();
            }

            void AsignarSucursal(string dato)
            {
                if (!int.TryParse(dato, out int index))
                    index = sucursales.FindIndex(s => s.codigo.Equals(dato.ToUpper()));
                
                if(index > -1 && index < sucursales.Count)
                {
                    sucursal = sucursales[index];
                }                    
            }

            string GenerarCodigoAleatorio(int cantCaracteres)
            {
                string nombre = "";
                string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";

                for (int i = 0; i < cantCaracteres; i++)
                {
                    nombre += caracteres[randy.Next(0, caracteres.Length)];
                }

                return nombre;
            }
        }
    }
}
