using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_2._0
{
    class Virus : Medicamento
    {
        public Virus(Vacuna vacuna)
        {
            id = randy.Next(0,1500);
            codigo = vacuna.GetCodigo() + GenerarCodigoAleatorio(1);
            designacion = vacuna.GetDesignacion();
        }

        public override void Destruir()
        {
            codigo = "YYYY";
        }

        public override string ToString()
        {
            return "Virus: " + base.ToString();
        }
    }
}
