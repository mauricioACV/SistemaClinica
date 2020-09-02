using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinica.Entidades
{
    public class Cita
    {
        public int IdCita { get; set; }

        public Medico Medico { get; set; }

        public Paciente Paciente { get; set; }

        public DateTime FechaReserva { get; set; }

        public string Observacion { get; set; }

        public char Estado { get; set; }

        public string Hora { get; set; }

        public Cita()
        {
            Paciente = new Paciente();
            Medico = new Medico();
        }
    }
}
