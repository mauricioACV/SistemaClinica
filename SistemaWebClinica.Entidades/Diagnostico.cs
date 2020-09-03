using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinica.Entidades
{
    public class Diagnostico
    {
        public int IdDiagnostico { get; set; }
        public HistoriaClinica HistoriaClinica { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Observacion { get; set; }
        public string DiagnosticoText { get; set; }
        public bool Estado { get; set; }

        public Diagnostico()
        {
            this.HistoriaClinica = new HistoriaClinica();
        }
    }
}
