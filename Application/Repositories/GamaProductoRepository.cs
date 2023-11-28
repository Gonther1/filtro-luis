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
        

        public async Task<IEnumerable<ClientesGamasProductos>> GamasProductosAndHerClients()
        {
            return await (
                from cli in _context.Clientes
                join ped in _context.Pedidos
                on cli.CodigoCliente equals ped.CodigoCliente
                join detped in _context.DetallePedidos
                on ped.CodigoPedido equals detped.CodigoPedido
                join pro in _context.Productos 
                on detped.CodigoProducto equals pro.CodigoProducto
                group pro.Gama by new { cli.CodigoCliente, cli.NombreCliente } into grouped

                // Agrupa las Gamas del producto por el codigo de cliente y el nombre en grouped

                select new ClientesGamasProductos
                {
                    ClienteNombre = grouped.Key.NombreCliente,
                    GamasCompradas = grouped.Distinct().ToList()
                }
            ).ToListAsync();
        }

    }
}