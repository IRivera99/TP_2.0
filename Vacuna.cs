using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_2._0
{
    class Vacuna : Medicamento
    {
        public Vacuna(int id, string codigo, Designaciones designacion) : base(id, codigo, designacion) { }

        public override void Destruir()
        {
            codigo = "XXX";
        }

        public override string ToString()
        {
            return "Vacuna: " + base.ToString();
        }
    }
}
