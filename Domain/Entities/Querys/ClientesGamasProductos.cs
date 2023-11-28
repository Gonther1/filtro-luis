using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Querys
{
    public class ClientesGamasProductos
    {
        public string ClienteNombre { get; set; }
        public IEnumerable<object> GamasCompradas { get; set; }
    }
}