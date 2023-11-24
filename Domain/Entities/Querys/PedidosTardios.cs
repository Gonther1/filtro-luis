using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Querys
{
    public class PedidosTardios
    {
        public int CodigoPedido { get; set; }
        public int CodigoCliente { get; set; }
        public DateOnly FechaEsperada { get; set; }
        public DateOnly ?FechaEntrega { get; set; }
    }
}