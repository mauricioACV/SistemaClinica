using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebClinica.Entidades
{
    public class Empleado
    {
        public int Id { get; set; }

        public TipoEmpleado TipoEmpleado { get; set; }

        public string Nombre { get; set; }

        public string ApPaterno { get; set; }

        public string ApMaterno { get; set; }

        public string NroDocumento { get; set; }

        public bool Estado { get; set; }

        public string Imagen { get; set; }

        public string Usuario { get; set; }

        public string Clave { get; set; }

        public Empleado()
        {

        }

        public Empleado(int Id, TipoEmpleado TipoEmpleado, String Nombre, string ApPaterno, string ApMaterno, string NroDocumento, bool Estado, string Imagen, string Usuario, string Clave)
        {
            this.Id = Id;
            this.TipoEmpleado = TipoEmpleado;
            this.Nombre = Nombre;
            this.ApPaterno = ApPaterno;
            this.ApMaterno = ApMaterno;
            this.NroDocumento = NroDocumento;
            this.Estado = Estado;
            this.Imagen = Imagen;
            this.Usuario = Usuario;
            this.Clave = Clave;
        }
    }
}
