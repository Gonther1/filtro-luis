using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities.Querys
{
    public class ClientesYPedidos
    {
        public int CodigoCliente { get; set; }
        public string NombreCliente { get; set; }
        public int CantPedidos { get; set; }
    }
}