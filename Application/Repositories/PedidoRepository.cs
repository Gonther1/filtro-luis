using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
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
    }
}