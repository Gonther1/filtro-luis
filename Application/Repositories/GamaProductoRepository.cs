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
            return await (from gam in _context.GamaProductos
                         join pro in _context.Productos
                         on gam.Gama equals pro.Gama 
                         join detped in _context.DetallePedidos
                         on pro.CodigoProducto equals detped.CodigoProducto
                         join ped in _context.Pedidos
                         on detped.CodigoPedido equals ped.CodigoPedido
                        join cli in _context.Clientes
                        on ped.CodigoCliente equals cli.CodigoCliente into clientgroup
                         select new ClientesGamasProductos
                         {
                            NombreGama = gam.Gama,
                            Clientes = clientgroup
                         }
            ).ToListAsync();
        }
    }
}