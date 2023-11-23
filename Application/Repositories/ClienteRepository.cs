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
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        private readonly ApiFiltroContext _context;
    
        public ClienteRepository(ApiFiltroContext context) : base(context)
        {
            _context = context;
        }

        

        public async Task<IEnumerable<ClientePedidoTardio>> ClientsWithOrderLast()
        {
            return await (from cli in _context.Clientes
                         join ped in _context.Pedidos
                         on cli.CodigoCliente equals ped.CodigoCliente
                         where ped.FechaEntrega > ped.FechaEsperada
                         select new ClientePedidoTardio
                         {
                            Nombre = cli.NombreCliente,
                            FechaEntrega = ped.FechaEntrega,
                            FechaEsperada = ped.FechaEsperada
                         }
            ).ToListAsync();
        }

        public async Task<IEnumerable<ClientesYPedidos>> ClientsWithOrders()
        {
            return await (from cli in _context.Clientes
                         join ped in _context.Pedidos
                         on cli.CodigoCliente equals ped.CodigoCliente into pedGroup
                         select new ClientesYPedidos
                         {
                            CodigoCliente = cli.CodigoCliente,
                            NombreCliente = cli.NombreCliente,
                            CantPedidos = pedGroup.Count()
                         }
            ).ToListAsync();
        }
    }
}