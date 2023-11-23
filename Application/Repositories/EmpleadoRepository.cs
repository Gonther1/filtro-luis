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
    public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleadoRepository
    {
        private readonly ApiFiltroContext _context;
    
        public EmpleadoRepository(ApiFiltroContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmpleadosYOficina>> GetEmployessDontRepresentant()
        {
            return await (from emp in _context.Empleados
                          join cli in _context.Clientes
                          on emp.CodigoEmpleado equals cli.CodigoEmpleadoRepVentas into cligroup
                          from cli in cligroup.DefaultIfEmpty()
                          join of in _context.Oficinas
                          on emp.CodigoOficina equals of.CodigoOficina
                          where cli.CodigoEmpleadoRepVentas != emp.CodigoEmpleado 
                          select new EmpleadosYOficina
                          {
                            CodigoEmpleado = emp.CodigoEmpleado,
                            ClienteRepVentas = cli.CodigoEmpleadoRepVentas,
                            Nombre = emp.Nombre,
                            Apellido1 = emp.Apellido1,
                            Apellido2 = emp.Apellido2,
                            Puesto = emp.Puesto,
                            TelefonoOficina = of.Telefono               
                          }
            ).ToListAsync();

        }
  /*           public async Task<IEnumerable<ProductDontSells>> GetProductDontSells()
                {
                    return await (from pro in _context.Products
                                  join detord in _context.Orderdetails
                                  on pro.Code equals detord.IdProductFk into detordGroup
                                    from detord in detordGroup.DefaultIfEmpty()
                                where detord == null 
                                  select new ProductDontSells
                                  {
                                    Code = pro.Code,
                                    Name = pro.Name,
                                    IdProductFk = detord.IdProductFk
                                  }
                    ).ToListAsync();
                } */
    }
}