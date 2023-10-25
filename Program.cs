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
            
            while (!opcion.Equals("SALIR"))
            {                
                while (sucursal == null && !opcion.Equals("SALIR"))
                {
                    Console.Clear();
                    Console.WriteLine("Bienvenido a la corporación Paraguas\n");
                    ListarSucursales();
                    Console.WriteLine("Por favor seleccione una sucursal indicando su indice o codigo (Para salir del programa escriba 'SALIR')");
                    opcion = Console.ReadLine().ToUpper();
                    AsignarSucursal(opcion);
                }

                while (!opcion.Equals("7") && sucursal != null)
                {                    
                    MostrarMenu();
                    opcion = Console.ReadLine();
                    switch (opcion)
                    {
                        case "1":
                            CatalogarNuevaVacuna();
                            break;
                        case "2":
                            SintetizarVirus();
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
                            sucursal = null;
                            break;
                        default:
                            Console.WriteLine("Opción no válida");
                            break;
                    }
                }
            }              

            void MostrarMenu()
            {
                Console.Clear();
                Console.WriteLine($"Sucursal: {sucursal.GetCodigo()}\n\n" +
                    "1- Catalogar nueva vacuna\n" +
                    "2- Sintetizar virus\n" +
                    "3- Destruir vacuna o virus\n" +
                    "4- Destruir por tipo\n" +
                    "5- Activar sistema de autodestrucción\n" +
                    "6- Activar sistema de autodestrucción global\n" +
                    "7- Salir\n\n" +
                    "Seleccione una opción");
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
                    Console.WriteLine($"Indice: {i} | Codigo: {sucursales[i].GetCodigo()}");
                }
                Console.WriteLine();
            }

            void AsignarSucursal(string dato)
            {
                if (!int.TryParse(dato, out int index))
                    index = sucursales.FindIndex(s => s.GetCodigo().Equals(dato.ToUpper()));
                
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

            void CatalogarNuevaVacuna()
            {
                string codigo;
                int designacion;
                int id;

                Console.Clear();
                Console.WriteLine("Catalogar nueva vacuna\n");

                do
                {
                    Console.WriteLine("Ingrese id de vacuna");
                } while (!int.TryParse(Console.ReadLine(), out id) && !sucursal.BuscarIdVacuna(id));

                do
                {
                    Console.WriteLine("Ingrese codigo de vacuna");
                    codigo = Console.ReadLine();
                } while (codigo.Length != 3);
                

                Console.WriteLine("Tipo de designaciones");
                ListarDesignaciones();
                Console.WriteLine("\nElija la designación a travéz de un número"); 
                do
                {
                    int.TryParse(Console.ReadLine(), out designacion);
                } while (designacion < 0 || designacion > Enum.GetValues(typeof(Designaciones)).Length-1);
                  
                
                Vacuna vacuna = new Vacuna(id, codigo, (Designaciones)designacion);
                sucursal.CatalogarNuevaVacuna(vacuna);
                Console.WriteLine($"\nVacuna catalogada con éxito\n{vacuna.ToString()}");
                Console.ReadLine();
            }

            void ListarDesignaciones()
            {
                Array designaciones = Enum.GetValues(typeof(Designaciones));
                for (int i = 0; i < designaciones.Length; i++)
                {
                    Console.WriteLine($"{i} = {designaciones.GetValue(i)}");
                }
            }

            void SintetizarVirus()
            {
                Virus virus = sucursal.SintetizarVirus();
                if (virus == null)
                    Console.WriteLine("\nNo se pudo sintetizar un virus, verifique primero de crear una vacuna...");
                else
                    Console.WriteLine($"\nVirus sintetizado con éxito\n{virus.ToString()}");
                Console.ReadLine();
            }
        }
    }
}
