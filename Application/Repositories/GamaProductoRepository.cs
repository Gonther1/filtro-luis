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
    public class GamaProductoRepository : GenericRepositoryStr<GamaProducto>, IGamaProductoRepository
    {
        private readonly ApiFiltroContext _context;
    
        public GamaProductoRepository(ApiFiltroContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Object>> GamasProductosAndHerClients()
        {
            return await (from gam in _context.GamaProductos
                         join pro in _context.Productos
                         on gam.Gama equals pro.Gama 
                         join detped in _context.DetallePedidos
                         on pro.CodigoProducto equals detped.CodigoProducto
                         join ped in _context.Pedidos
                         on detped.CodigoPedido equals ped.CodigoPedido
                        join cli in _context.Clientes
                        on ped.CodigoCliente equals cli.CodigoCliente into clientgroup
                         select new
                         {
                            NombreGama = gam.Gama,
                            Clientes = string.Join(", ", clientgroup.Select(x => x.NombreCliente).Distinct())
                         }
            ).ToListAsync();
        }

        public async Task<IEnumerable<Object>> CustomersGammas()
        {
            return await (
                from cli in _context.Clientes
                join ped in _context.Pedidos
                on cli.CodigoCliente equals ped.CodigoCliente
                join detped in _context.DetallePedidos
                on ped.CodigoPedido equals detped.CodigoPedido
                join pro in _context.Productos 
                on detped.CodigoProducto equals pro.CodigoProducto
                group new { cli, pro.Gama } 
                by new { cli.CodigoCliente, cli.NombreCliente } into grouped
                select new
                {
                    ClienteNombre = grouped.Key.NombreCliente,
                    GamasCompradas = string.Join(", ", grouped.Select(x => x.Gama).Distinct())
                }
            ).ToListAsync();
        }

    }
}