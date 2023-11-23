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
    public class ProductoRepository : GenericRepositoryStr<Producto>, IProductoRepository
    {
        private readonly ApiFiltroContext _context;
    
        public ProductoRepository(ApiFiltroContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDontSells>> GetProductsDontSell()
        {
            return await (from pro in _context.Productos
                         join detped in _context.DetallePedidos
                         on pro.CodigoProducto equals detped.CodigoProducto into detpedGroup
                         from detped in detpedGroup.DefaultIfEmpty()
                         where detped == null
                         select new ProductDontSells
                         {
                            CodigoProducto = pro.CodigoProducto,
                            Nombre = pro.Nombre,
                            Descripcion = pro.Descripcion,
                            ProCodDetPed = detped.CodigoProducto
                         }
                        
            ).ToListAsync();
        }
    }
}