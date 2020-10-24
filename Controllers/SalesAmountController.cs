using System.Collections.Generic;
using System.Linq;
using Bikes.DTO;
using Bikes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bikes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SalesAmountController : ControllerBase
    {
        private readonly ILogger<SalesAmountController> _logger;
        private readonly Ventas _ventasContext;
        private readonly ProduccionContext _producctionContext;

        public SalesAmountController(ILogger<SalesAmountController> logger, Ventas vContext, ProduccionContext pContext)
        {
            _logger = logger;
            _ventasContext = vContext;
            _producctionContext = pContext;

        }
        [HttpGet]
        public IEnumerable<Order> GetTotalSales()
        {
            return this.GetTotalSalesCA().Concat(this.GetTotalSalesNY()).Concat(this.GetTotalSalesTX());
        }
        [HttpGet("NY")]
        public IEnumerable<Order> GetTotalSalesNY()
        {
            var incOrders = _ventasContext.OrdenesNewYork.Join(
                _ventasContext.DetalleOrden,
                order => order.IdOrden,
                detail => detail.IdOrden,
                (order, detail) => new
                {
                    order.IdOrden,
                    detail.IdItem,
                    detail.IdProducto,
                    detail.Cantidad,
                    detail.PrecioVenta,
                    order.IdCliente,
                    order.EstadoOrden,
                    order.FechaOrden,
                    order.RequiredDate,
                    order.FechaEnvio,
                    order.IdTienda,
                    order.IdEmpleado,
                    detail.Descuento
                }
                ).Join(_ventasContext.Clientes,
                order => order.IdCliente,
                client => client.IdCliente,
                (order, client) => new
                {
                    order.IdOrden,
                    order.IdItem,
                    order.IdProducto,
                    order.Cantidad,
                    order.PrecioVenta,
                    order.IdCliente,
                    order.EstadoOrden,
                    order.FechaOrden,
                    order.RequiredDate,
                    order.FechaEnvio,
                    order.IdTienda,
                    order.IdEmpleado,
                    order.Descuento,
                    client.Nombre,
                    client.Apellido
                }).Join(_ventasContext.EmpleadosNewYork,
                order => order.IdEmpleado,
                employee => employee.IdEmpleado,
                (order, employee) => new
                {
                    order.IdOrden,
                    order.IdItem,
                    order.IdProducto,
                    order.Cantidad,
                    order.PrecioVenta,
                    order.IdCliente,
                    order.EstadoOrden,
                    order.FechaOrden,
                    order.RequiredDate,
                    order.FechaEnvio,
                    order.IdTienda,
                    order.IdEmpleado,
                    order.Descuento,
                    order.Nombre,
                    order.Apellido,
                    eNombre = employee.Nombre,
                    eApellido = employee.Apellido
                }).ToList();

            List<Order> orders = new List<Order>(); 
            foreach (var order in incOrders)
            {
                Productos product = _producctionContext.Productos.Find(order.IdProducto);
                        orders.Add(new Order(
                        order.IdOrden,
                        order.IdItem,
                        order.IdProducto,
                        order.Cantidad,
                        order.PrecioVenta,
                        order.IdCliente,
                        order.EstadoOrden,
                        order.FechaOrden,
                        order.RequiredDate,
                        order.FechaEnvio,
                        order.IdTienda,
                        order.IdEmpleado,
                        order.Descuento,
                        order.Nombre,
                        order.Apellido,
                        order.eNombre,
                        order.eApellido,
                        product.NomProducto
                        )
                    );
            }
            return orders;
        }
        [HttpGet("CA")]
        public IEnumerable<Order> GetTotalSalesCA()
        {
            var incOrders = _ventasContext.OrdenesCalifornia.Join(
                _ventasContext.DetalleOrden,
                order => order.IdOrden,
                detail => detail.IdOrden,
                (order, detail) => new
                {
                    order.IdOrden,
                    detail.IdItem,
                    detail.IdProducto,
                    detail.Cantidad,
                    detail.PrecioVenta,
                    order.IdCliente,
                    order.EstadoOrden,
                    order.FechaOrden,
                    order.RequiredDate,
                    order.FechaEnvio,
                    order.IdTienda,
                    order.IdEmpleado,
                    detail.Descuento
                }
                ).Join(_ventasContext.Clientes,
                order => order.IdCliente,
                client => client.IdCliente,
                (order, client) => new {
                    order.IdOrden,
                    order.IdItem,
                    order.IdProducto,
                    order.Cantidad,
                    order.PrecioVenta,
                    order.IdCliente,
                    order.EstadoOrden,
                    order.FechaOrden,
                    order.RequiredDate,
                    order.FechaEnvio,
                    order.IdTienda,
                    order.IdEmpleado,
                    order.Descuento,
                    client.Nombre,
                    client.Apellido
                }).Join(_ventasContext.EmpleadosCalifornia,
                order => order.IdEmpleado,
                employee => employee.IdEmpleado,
                (order, employee) => new
                {
                    order.IdOrden,
                    order.IdItem,
                    order.IdProducto,
                    order.Cantidad,
                    order.PrecioVenta,
                    order.IdCliente,
                    order.EstadoOrden,
                    order.FechaOrden,
                    order.RequiredDate,
                    order.FechaEnvio,
                    order.IdTienda,
                    order.IdEmpleado,
                    order.Descuento,
                    order.Nombre,
                    order.Apellido,
                    eNombre = employee.Nombre,
                    eApellido = employee.Apellido
                }).ToList();
            List<Order> orders = new List<Order>();
            foreach (var order in incOrders)
            {
                Productos product = _producctionContext.Productos.Find(order.IdProducto);
                orders.Add(new Order(
                order.IdOrden,
                order.IdItem,
                order.IdProducto,
                order.Cantidad,
                order.PrecioVenta,
                order.IdCliente,
                order.EstadoOrden,
                order.FechaOrden,
                order.RequiredDate,
                order.FechaEnvio,
                order.IdTienda,
                order.IdEmpleado,
                order.Descuento,
                order.Nombre,
                order.Apellido,
                order.eNombre,
                order.eApellido,
                product.NomProducto
                )
            );
            }
            return orders;
        }
        [HttpGet("TX")]
        public IEnumerable<Order> GetTotalSalesTX()
        {
            var incOrders = _ventasContext.OrdenesTexas.Join(
                _ventasContext.DetalleOrden,
                order => order.IdOrden,
                detail => detail.IdOrden,
                (order, detail) => new
                {
                    order.IdOrden,
                    detail.IdItem,
                    detail.IdProducto,
                    detail.Cantidad,
                    detail.PrecioVenta,
                    order.IdCliente,
                    order.EstadoOrden,
                    order.FechaOrden,
                    order.RequiredDate,
                    order.FechaEnvio,
                    order.IdTienda,
                    order.IdEmpleado,
                    detail.Descuento
                }
                ).Join(_ventasContext.Clientes,
                order => order.IdCliente,
                client => client.IdCliente,
                (order, client) => new {
                    order.IdOrden,
                    order.IdItem,
                    order.IdProducto,
                    order.Cantidad,
                    order.PrecioVenta,
                    order.IdCliente,
                    order.EstadoOrden,
                    order.FechaOrden,
                    order.RequiredDate,
                    order.FechaEnvio,
                    order.IdTienda,
                    order.IdEmpleado,
                    order.Descuento,
                    client.Nombre,
                    client.Apellido
                }).Join(_ventasContext.EmpleadosTexas,
                order => order.IdEmpleado,
                employee => employee.IdEmpleado,
                (order, employee) => new
                {
                    order.IdOrden,
                    order.IdItem,
                    order.IdProducto,
                    order.Cantidad,
                    order.PrecioVenta,
                    order.IdCliente,
                    order.EstadoOrden,
                    order.FechaOrden,
                    order.RequiredDate,
                    order.FechaEnvio,
                    order.IdTienda,
                    order.IdEmpleado,
                    order.Descuento,
                    order.Nombre,
                    order.Apellido,
                    eNombre = employee.Nombre,
                    eApellido = employee.Apellido
                }).ToList();
            List<Order> orders = new List<Order>();
            foreach (var order in incOrders)
            {
                Productos product = _producctionContext.Productos.Find(order.IdProducto);
                orders.Add(new Order(
                order.IdOrden,
                order.IdItem,
                order.IdProducto,
                order.Cantidad,
                order.PrecioVenta,
                order.IdCliente,
                order.EstadoOrden,
                order.FechaOrden,
                order.RequiredDate,
                order.FechaEnvio,
                order.IdTienda,
                order.IdEmpleado,
                order.Descuento,
                order.Nombre,
                order.Apellido,
                order.eNombre,
                order.eApellido,
                product.NomProducto
                )
            );
            }
            return orders;
        }
    }
}
