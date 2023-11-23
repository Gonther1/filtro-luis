using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Querys
{
    public class EmpleadosYOficina
    {
        public int? ClienteRepVentas { get; set; }
        public int CodigoEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Puesto { get; set; }
        public string TelefonoOficina { get; set; }
    }
}