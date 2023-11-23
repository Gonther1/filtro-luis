using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Querys
{
    public class ProductDontSells
    {
        public string CodigoProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string ProCodDetPed { get; set; }
    }
}