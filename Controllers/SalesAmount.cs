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
            List<Order> orders =_context.OrdenesNewYork.Join(
                _context.DetalleOrden, 
                order => order.IdCliente, 
                detail => detail.IdOrden,
                (order, detail) => new Order(
                    order.IdOrden,detail.IdItem,
                    detail.IdProducto,detail.Cantidad,
                    detail.PrecioVenta,order.IdCliente,
                    order.EstadoOrden,order.FechaOrden,
                    order.RequiredDate,order.FechaEnvio,
                    order.IdTienda,order.IdEmpleado)
                ).ToList<Order>();
            return orders;
        }
        [HttpGet("CA")]
        public IEnumerable<Order> GetTotalSalesCA()
        {
            List<Order> orders = _context.OrdenesCalifornia.Join(
                _context.DetalleOrden,
                order => order.IdCliente,
                detail => detail.IdOrden,
                (order, detail) => new Order(
                    order.IdOrden, detail.IdItem,
                    detail.IdProducto, detail.Cantidad,
                    detail.PrecioVenta, order.IdCliente,
                    order.EstadoOrden, order.FechaOrden,
                    order.RequiredDate, order.FechaEnvio,
                    order.IdTienda, order.IdEmpleado)
                ).ToList<Order>();
            return orders;
        }
        [HttpGet("TX")]
        public IEnumerable<Order> GetTotalSalesTX()
        {
            List<Order> orders = _context.OrdenesTexas.Join(
                _context.DetalleOrden,
                order => order.IdCliente,
                detail => detail.IdOrden,
                (order, detail) => new Order(
                    order.IdOrden, detail.IdItem,
                    detail.IdProducto, detail.Cantidad,
                    detail.PrecioVenta, order.IdCliente,
                    order.EstadoOrden, order.FechaOrden,
                    order.RequiredDate, order.FechaEnvio,
                    order.IdTienda, order.IdEmpleado)
                ).ToList<Order>();
            return orders;
        }
    }
}
