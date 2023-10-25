using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_2._0
{
    abstract class Medicamento
    {
        protected int id;
        protected string codigo;
        protected Designaciones designacion;

        protected readonly Random randy = new Random();
        protected readonly Array listaDesignaciones = Enum.GetValues(typeof(Designaciones));

        protected Medicamento()
        {
            id = 0;
            codigo = string.Empty;
            designacion = 0;
        }

        protected Medicamento(int id, string codigo, Designaciones designacion)
        {
            this.id = id;
            this.codigo = codigo.ToUpper();
            this.designacion = designacion;
        }

        protected string GenerarCodigoAleatorio(int cantCaracteres)
        {
            string nombre = "";
            string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789";

            for (int i = 0; i < cantCaracteres; i++)
            {
                nombre += caracteres[randy.Next(0, caracteres.Length)];
            }

            return nombre;
        }

        public string GetCodigo()
        {
            return codigo;
        }

        public int GetId()
        {
            return id;
        }

        public Designaciones GetDesignacion()
        {
            return designacion;
        }

        public override string ToString()
        {
            return "Id: " + id + " | Código: " + codigo + " | Designación: " + designacion;
        }

        public abstract void Destruir();
    }
}
