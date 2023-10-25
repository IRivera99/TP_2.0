using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_2._0
{
    class Sucursal
    {
        string codigo;
        List<Medicamento> medicamentos;

        readonly Random randy = new Random();

        public Sucursal()
        {
            codigo = GenerarCodigoAleatorio(3);
            medicamentos = new List<Medicamento>();
        }

        public Sucursal(string codigo)
        {
            if(codigo.Length > 3) 
            {
                this.codigo = codigo.Remove(3).ToUpper();
            }
            else
            {
                this.codigo = codigo.ToUpper();
            }
            
            medicamentos = new List<Medicamento>();
        }

        public string GetCodigo()
        {
            return codigo;
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

        public void ListarMedicamentos()
        {
            if (medicamentos.Count > 0) 
            {
                for (int i = 0; i < medicamentos.Count; i++)
                {
                    Console.WriteLine($"Indice: {i} | {medicamentos[i].ToString()}");
                }
            }
            else
            {
                Console.WriteLine("No hay medicamentos listados...");
            }
            
        }

        public void CatalogarNuevaVacuna(Vacuna vacuna)
        {
            medicamentos.Add(vacuna);
        }

        public Virus SintetizarVirus()
        {
            Virus virus = null;
            Vacuna vacuna = (Vacuna)medicamentos.FindLast(m => m is Vacuna);

            if(vacuna != null)
            {
                virus = new Virus(vacuna);
                medicamentos.Add(virus);                
            }

            return virus;
        }

        public bool DestruirMedicamento(Medicamento medicamento)
        {
            bool destruido = false;
            int index = medicamentos.FindIndex(m => m.Equals(medicamento));

            if (index > -1)
            {
                medicamentos[index].Destruir();
                destruido = true;
            }           

            return destruido;
        }

        public bool DestruirPorTipo(Designaciones designacion)
        {
            bool destruidos = false;

            foreach (Medicamento medicamento in medicamentos)
            {
                if (medicamento.GetDesignacion().Equals(designacion))
                {
                    medicamento.Destruir();
                    destruidos = true;
                }                    
            }

            return destruidos;
        }

        public void Autodestruccion()
        {
            foreach (Medicamento medicamento in medicamentos)
            {
                medicamento.Destruir();
            }
        }

        public bool BuscarIdVacuna(int id)
        {     
            return medicamentos.Exists(m => m.GetId() == id && m is Vacuna);
        }


    }
}
