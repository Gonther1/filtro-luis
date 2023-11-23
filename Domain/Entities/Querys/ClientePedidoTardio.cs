using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Querys
{
    public class ClientePedidoTardio
    {
        public string Nombre { get; set; }
        public DateOnly FechaEsperada { get; set; }
        public DateOnly? FechaEntrega { get; set; }
    }
}