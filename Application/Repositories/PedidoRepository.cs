using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Querys;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repositories
{
    public class PedidoRepository : GenericRepository<Pedido>, IPedidoRepository
    {
        private readonly ApiFiltroContext _context;
    
        public PedidoRepository(ApiFiltroContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PedidosTardios>> GetOrderLate()
        {
            return await (from ped in _context.Pedidos
                         join cli in _context.Clientes
                         on ped.CodigoCliente equals cli.CodigoCliente
                         where ped.FechaEntrega > ped.FechaEsperada
                         select new PedidosTardios
                         {
                            CodigoPedido = ped.CodigoPedido,
                            CodigoCliente = ped.CodigoCliente,
                            FechaEsperada = ped.FechaEsperada,
                            FechaEntrega = ped.FechaEntrega
                         }
            ).ToListAsync();
        }
    }
}