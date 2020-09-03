using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinica.Entidades
{
    public class HistoriaClinica
    {
        public int IdHistoriaClinica { get; set; }
        public Paciente Paciente { get; set; }
        public DateTime FechaApertura { get; set; }
        public bool Estado { get; set; }

        public HistoriaClinica()
        {
            this.Paciente = new Paciente();
        }
    }
}
