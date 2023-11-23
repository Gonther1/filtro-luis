using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Querys
{
    public class ClientesGamasProductos
    {
        public string NombreGama { get; set; }
        public IEnumerable<Cliente> Clientes { get; set; }
    }
}