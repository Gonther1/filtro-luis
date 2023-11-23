using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class PagoRepository : GenericRepository<Pago>, IPagoRepository
    {
        private readonly ApiFiltroContext _context;
    
        public PagoRepository(ApiFiltroContext context) : base(context)
        {
            _context = context;
        }
    }
}