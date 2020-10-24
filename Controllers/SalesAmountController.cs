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
        private readonly Ventas _context;

        public SalesAmountController(ILogger<SalesAmountController> logger, Ventas context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Order> GetTotalSales()
        {
            return this.GetTotalSalesCA().Concat(this.GetTotalSalesNY()).Concat(this.GetTotalSalesTX());
        }
        [HttpGet("NY")]
        public IEnumerable<Order> GetTotalSalesNY()
        {
            List<Order> orders = _context.OrdenesNewYork.Join(
                _context.DetalleOrden,
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
                ).Join(_context.Clientes,
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
                }).Join(_context.EmpleadosNewYork, 
                order => order.IdEmpleado,
                employee => employee.IdEmpleado,
                (order, employee) => new Order(
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
                    employee.Nombre,
                    employee.Apellido
                )).ToList<Order>();
            return orders;
        }
        [HttpGet("CA")]
        public IEnumerable<Order> GetTotalSalesCA()
        {
            List<Order> orders = _context.OrdenesCalifornia.Join(
                _context.DetalleOrden,
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
                ).Join(_context.Clientes,
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
                }).Join(_context.EmpleadosCalifornia,
                order => order.IdEmpleado,
                employee => employee.IdEmpleado,
                (order, employee) => new Order(
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
                    employee.Nombre,
                    employee.Apellido
                )).ToList<Order>();
            return orders;
        }
        [HttpGet("TX")]
        public IEnumerable<Order> GetTotalSalesTX()
        {
            List<Order> orders = _context.OrdenesTexas.Join(
                _context.DetalleOrden,
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
                ).Join(_context.Clientes,
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
                }).Join(_context.EmpleadosTexas,
                order => order.IdEmpleado,
                employee => employee.IdEmpleado,
                (order, employee) => new Order(
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
                    employee.Nombre,
                    employee.Apellido
                )).ToList<Order>();
            return orders;
        }
    }
}
