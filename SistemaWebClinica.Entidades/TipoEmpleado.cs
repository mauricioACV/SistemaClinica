using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinica.Entidades
{
    public class TipoEmpleado
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public bool Estado { get; set; }

        public TipoEmpleado()
        {

        }

        public TipoEmpleado(int Id, string Descripcion, bool Estado)
        {
            this.Id = Id;
            this.Descripcion = Descripcion;
            this.Estado = Estado;
        }
    }
}
