using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Querys;

public class OficinasSinEmpleados
{
    public int CodigoOficina { get; set; }
    public string Pais { get; set; }
    public string Region { get; set; }
    public string Ciudad { get; set; }
    public int CodigoEmpleado { get; set; }
    public int CodigoEmpRepVentas { get; set; }
    public int CodigoCliente { get; set; }
    public int PedCodigoCliente { get; set; }
    public int Codigo { get; set; }
}
