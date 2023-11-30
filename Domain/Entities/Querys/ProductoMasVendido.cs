using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Querys
{
    public class ProductoMasVendido
    {
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public int UnidadesVendidas { get; set; }
    }
}