# filtro-luis

## By Luis Andrés Alvarez Silva J2

## Requisitos

-Tener Netcore 8.0 instalado.

-Instalar el EntityFramework en terminal con el siguiente codigo:

```
dotnet tool install --global dotnet-ef
```

## Guia de uso

1- Cree la base de datos, copie y pegue por completo el archivo Database.sql

2- Use la base de datos jardineria y copie y pegue el archivo Data.sql.

3- Ejecute para la visualizacion de las consultas, ubiquese en la carpeta 
filtro-luis y escriba:

```
dotnet watch run -p ApiFiltro/
```

## Consultas

### Enunciado:

1-Devuelve el listado de clientes indicando el nombre del cliente y cuántos
pedidos ha realizado. Tenga en cuenta que pueden existir clientes que no
han realizado ningún pedido.

### Endpoint:

```c#
[HttpGet("ClientesConPedidos-1")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<ClientesYPedidos>>> ClientesConPedidos()
{
    var entity = await _unitOfWork.Clientes.ClientsWithOrders();
    return _mapper.Map<List<ClientesYPedidos>>(entity);
}
```

### Codigo:

```c#
public async Task<IEnumerable<ClientesYPedidos>> ClientsWithOrders()
{
    return await (from cli in _context.Clientes
                 join ped in _context.Pedidos
                 on cli.CodigoCliente equals ped.CodigoCliente into pedGroup
                 select new ClientesYPedidos
                 {
                    CodigoCliente = cli.CodigoCliente,
                    NombreCliente = cli.NombreCliente,
                    CantPedidos = pedGroup.Count()
                 }
    ).ToListAsync();
}
```


### Enunciado:

2-Devuelve un listado con el código de pedido, código de cliente, fecha
esperada y fecha de entrega de los pedidos que no han sido entregados a
tiempo.


### Endpoint:

```c#
[HttpGet("PedidosTardios-2")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<PedidosTardios>>> PedidosTardios()
{
    var entity = await _unitOfWork.Pedidos.GetOrderLate();
    return _mapper.Map<List<PedidosTardios>>(entity);
}
```

### Codigo:

```c#
public async Task<IEnumerable<PedidosTardios>> GetOrderLate()
{
    return await (from ped in _context.Pedidos
                    join cli in _context.Clientes
                    on ped.CodigoCliente equals cli.CodigoCliente
                    where ped.FechaEntrega > ped.FechaEsperada
                    select new PedidosTardios
                    {
                    CodigoPedido = ped.CodigoPedido,
                    CodigoCliente = ped.CodigoCliente,
                    FechaEsperada = ped.FechaEsperada,
                    FechaEntrega = ped.FechaEntrega
                    }
    ).ToListAsync();
}
```






### Enunciado:


3-Devuelve un listado de los productos que nunca han aparecido en un
pedido. El resultado debe mostrar el nombre, la descripción y la imagen del
producto.


### Endpoint:

```c#
[HttpGet("ProductosSinVender-3")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<ProductDontSells>>> ProductosSinVender()
{
    var entity = await _unitOfWork.Productos.GetProductsDontSell();
    return _mapper.Map<List<ProductDontSells>>(entity);
}        
```

### Codigo:

```c#
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
```
****

### Enunciado:


6-Devuelve el nombre, apellidos, puesto y teléfono de la oficina de aquellos
empleados que no sean representante de ventas de ningún cliente.


### Endpoint:

```c#
[HttpGet("ClientesAndOficinas-6")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<EmpleadosYOficina>>> ClientesAndOficinas()
{
    var entity = await _unitOfWork.Empleados.GetEmployessDontRepresentant();
    return _mapper.Map<List<EmpleadosYOficina>>(entity);
}
```

### Codigo:

```c#
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
```
****


### Enunciado:


8-Devuelve un listado de los 20 productos más vendidos y el número total de
unidades que se han vendido de cada uno. El listado deberá estar ordenado
por el número total de unidades vendidas.


### Endpoint:

```c#
[HttpGet("ProductosMasVendidos20-8")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<ProductosMasVendidos20>>> ProductosMasVendidos20()
{
    var entity = await _unitOfWork.Productos.GetTwentyProducts();
    return _mapper.Map<List<ProductosMasVendidos20>>(entity);
}
```

### Codigo:

```c#
public async Task<IEnumerable<ProductosMasVendidos20>> GetTwentyProducts()
{
    return await (from pro in _context.Productos
                    join detped in _context.DetallePedidos
                    on pro.CodigoProducto equals detped.CodigoProducto 
                    orderby detped.Cantidad 
                    descending
                    select new ProductosMasVendidos20
                    {
                    CodigoProducto = pro.CodigoProducto,
                    NombreProducto = pro.Nombre,
                    UnidadesVendidas = detped.Cantidad
                    }
    ).Take(20).ToListAsync();
}
```
****


### Enunciado:


9-Devuelve el nombre de los clientes a los que no se les ha entregado a
tiempo un pedido.


### Endpoint:

```c#
[HttpGet("ClientePedidoTardio-9")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<ClientePedidoTardio>>> ClientePedidoTardio()
{
    var entity = await _unitOfWork.Clientes.ClientsWithOrderLast();
    return _mapper.Map<List<ClientePedidoTardio>>(entity);
}
```

### Codigo:

```c#
public async Task<IEnumerable<ClientePedidoTardio>> ClientsWithOrderLast()
{
    return await (from cli in _context.Clientes
                    join ped in _context.Pedidos
                    on cli.CodigoCliente equals ped.CodigoCliente
                    where ped.FechaEntrega > ped.FechaEsperada
                    select new ClientePedidoTardio
                    {
                    Nombre = cli.NombreCliente,
                    FechaEntrega = ped.FechaEntrega,
                    FechaEsperada = ped.FechaEsperada
                    }
    ).ToListAsync();
}
```
****

### Enunciado:


10-Devuelve un listado de las diferentes gamas de producto que ha comprado
cada cliente.


### Endpoint:

```c#
[HttpGet("GamasProductosCompradas-10")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<IEnumerable<ClientesGamasProductos>>> GamasProductosCompradas()
{
    var entity = await _unitOfWork.GamasProductos.GamasProductosAndHerClients();
    return _mapper.Map<List<ClientesGamasProductos>>(entity);
}
```

### Codigo:

```c#
Task<IEnumerable<ClientesGamasProductos>> GamasProductosAndHerClients()
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
```
****
