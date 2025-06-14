using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
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
    }
}