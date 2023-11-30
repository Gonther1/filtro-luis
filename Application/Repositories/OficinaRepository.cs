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
    public class OficinaRepository : GenericRepositoryStr<Oficina>, IOficinaRepository 
    {
        private readonly ApiFiltroContext _context;
    
        public OficinaRepository(ApiFiltroContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OficinasSinEmpleados>> OfficeWithoutRepresentantOfSales()
        {
            return await (from of in _context.Oficinas
                         join emp in _context.Empleados
                         on of.CodigoOficina equals emp.CodigoOficina
                         join cli in _context.Clientes
                         on emp.CodigoEmpleado equals cli.CodigoEmpleadoRepVentas
                         join ped in _context.Pedidos
                         on cli.CodigoCliente equals ped.CodigoCliente
                         join detped in _context.DetallePedidos
                         on ped.CodigoPedido equals detped.CodigoPedido
                         join pro in _context.Productos
                         on detped.CodigoProducto equals pro.CodigoProducto
                         where pro.Gama == "Frutales"
                         select new OficinasSinEmpleados
                         {
                            
                         }
            ).ToListAsync();
        }
    }
}