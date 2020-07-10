using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinica.Entidades
{
    public class Medico : Empleado
    {
        public int IdMedico { get; set; }

        public Especialidad Especialidad { get; set; }

         public Medico()
             : base()
         {

        }

        public Medico(int IdMedico, Especialidad especialidad, bool estado)
           :base(0,new TipoEmpleado(), "", "", "", "", true, "", "", "")
        {
            this.IdMedico = IdMedico;
            this.Especialidad = especialidad;
            this.Estado = estado;
        }
    }
}
