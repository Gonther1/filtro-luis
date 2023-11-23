using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IClienteRepository Clientes { get; }
        IDetallePedidoRepository DetallesPedidos { get; }
        IEmpleadoRepository Empleados { get; }
        IGamaProductoRepository GamasProductos { get; }
        IOficinaRepository Oficinas { get; }
        IPagoRepository Pagos { get; }
        IPedidoRepository Pedidos { get; }
        IProductoRepository Productos { get; }
        Task<int> SaveAsync();
    }
}