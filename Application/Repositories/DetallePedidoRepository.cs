using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class DetallePedidoRepository : GenericRepository<DetallePedido>, IDetallePedidoRepository
    {
        private readonly ApiFiltroContext _context;
    
        public DetallePedidoRepository(ApiFiltroContext context) : base(context)
        {
            _context = context;
        }
    }
}