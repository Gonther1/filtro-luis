using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Querys;

namespace Domain.Interfaces
{
    public interface IProductoRepository : IGenericRepositoryStr<Producto>
    {   
        Task<IEnumerable<ProductDontSells>> GetProductsDontSell();
        Task<IEnumerable<ProductosMasVendidos20>> GetTwentyProducts();
    }

}