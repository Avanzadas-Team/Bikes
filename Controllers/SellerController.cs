using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bikes.DTO;
using Bikes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bikes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private ILogger<SellerController> _logger;
        private Ventas _context;

        public SellerController(ILogger<SellerController> logger, Ventas context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: api/<OrdersbyClientController>
        [HttpGet("NY")]
        public List<SellersID> GetNY()
        {
            List<SellersID> sellersList = new List<SellersID>();

            foreach (EmpleadosNewYork employee in _context.EmpleadosNewYork.ToList())
            {
                SellersID dummy = new SellersID();
                dummy.name = employee.Nombre + " " + employee.Apellido;
                dummy.idEmployee = employee.IdEmpleado;
                sellersList.Add(dummy);
            }

            return sellersList;
        }
        [HttpGet("Cal")]
        public List<SellersID> GetCal()
        {
            List<SellersID> sellersList = new List<SellersID>();

            foreach (EmpleadosCalifornia employee in _context.EmpleadosCalifornia.ToList())
            {
                SellersID dummy = new SellersID();
                dummy.name = employee.Nombre + " " + employee.Apellido;
                dummy.idEmployee = employee.IdEmpleado;
                sellersList.Add(dummy);
            }

            return sellersList;
        }
        [HttpGet("TX")]
        public List<SellersID> GetTX()
        {
            List<SellersID> sellersList = new List<SellersID>();

            foreach (EmpleadosTexas employee in _context.EmpleadosTexas.ToList())
            {
                SellersID dummy = new SellersID();
                dummy.name = employee.Nombre + " " + employee.Apellido;
                dummy.idEmployee = employee.IdEmpleado;
                sellersList.Add(dummy);
            }

            return sellersList;
        }

        [HttpPost("NY")]
        public int PostNY(OrderIns order)
        {
            order.idOrden = 1615;
            order.estadoOrden = 2;
            order.fechaEnvio = Convert.ToDateTime(order.fechaEnvio.ToString("yyyy/MM/dd"));
            order.fechaOrden = Convert.ToDateTime(DateTime.Today.ToString("yyyy/MM/dd"));
            order.required_date = Convert.ToDateTime(order.fechaEnvio.ToString("yyyy/MM/dd"));
            order.idItem = 2;

            var orderID = (from oID in _context.Ordenes
                            where oID.IdOrden >= 1615 
                            select new
                            {
                                IdOrden = oID.IdOrden
                            }).ToList();

            foreach (var od in orderID)
            {
                order.idOrden += 1; 
            }
            OrdenesNewYork newOrderNY = new OrdenesNewYork();
            newOrderNY.IdOrden = order.idOrden;
            newOrderNY.EstadoOrden = order.estadoOrden;
            newOrderNY.FechaEnvio = order.fechaEnvio;
            newOrderNY.FechaOrden = order.fechaOrden;
            newOrderNY.IdCliente = order.idCliente;
            newOrderNY.IdEmpleado = order.idEmpleado;
            newOrderNY.IdTienda = order.idTienda;
            newOrderNY.RequiredDate = order.required_date;
            _context.Add(newOrderNY);
            DetalleOrden detOrderNY = new DetalleOrden();
            detOrderNY.Cantidad = order.cantidad;
            detOrderNY.Descuento = order.descuento;
            detOrderNY.IdItem = order.idItem;
            detOrderNY.IdOrden = order.idOrden;
            detOrderNY.IdProducto = order.idProducto;
            detOrderNY.PrecioVenta = order.precioVenta;
            _context.Add(detOrderNY);

            Ordenes orderInsNY = new Ordenes();
            orderInsNY.IdOrden = order.idOrden;
            _context.Ordenes.Add(orderInsNY);
            _context.SaveChanges();
            return 1;
        }
        [HttpPost("Cal")]
        public int PostCal(OrderIns order)
        {
            order.idOrden = 1615;
            order.estadoOrden = 2;
            order.fechaEnvio = Convert.ToDateTime(order.fechaEnvio.ToString("yyyy/MM/dd"));
            order.fechaOrden = Convert.ToDateTime(DateTime.Today.ToString("yyyy/MM/dd"));
            order.required_date = Convert.ToDateTime(order.fechaEnvio.ToString("yyyy/MM/dd"));
            order.idItem = 2;

            var orderID = (from oID in _context.Ordenes
                           where oID.IdOrden >= 1615
                           select new
                           {
                               IdOrden = oID.IdOrden
                           }).ToList();

            foreach (var od in orderID)
            {
                order.idOrden += 1;
            }
            OrdenesCalifornia newOrderCal = new OrdenesCalifornia();
            newOrderCal.IdOrden = order.idOrden;
            newOrderCal.EstadoOrden = order.estadoOrden;
            newOrderCal.FechaEnvio = order.fechaEnvio;
            newOrderCal.FechaOrden = order.fechaOrden;
            newOrderCal.IdCliente = order.idCliente;
            newOrderCal.IdEmpleado = order.idEmpleado;
            newOrderCal.IdTienda = order.idTienda;
            newOrderCal.RequiredDate = order.required_date;
            _context.Add(newOrderCal);
            DetalleOrden detOrderCal = new DetalleOrden();
            detOrderCal.Cantidad = order.cantidad;
            detOrderCal.Descuento = order.descuento;
            detOrderCal.IdItem = order.idItem;
            detOrderCal.IdOrden = order.idOrden;
            detOrderCal.IdProducto = order.idProducto;
            detOrderCal.PrecioVenta = order.precioVenta;
            _context.Add(detOrderCal);

            Ordenes orderInsCal = new Ordenes();
            orderInsCal.IdOrden = order.idOrden;
            _context.Ordenes.Add(orderInsCal);
            _context.SaveChanges();
            return 1;
        }
        [HttpPost("TX")]
        public int PostTX(OrderIns order)
        {
            order.idOrden = 1615;
            order.estadoOrden = 2;
            order.fechaEnvio = Convert.ToDateTime(order.fechaEnvio.ToString("yyyy/MM/dd"));
            order.fechaOrden = Convert.ToDateTime(DateTime.Today.ToString("yyyy/MM/dd"));
            order.required_date = Convert.ToDateTime(order.fechaEnvio.ToString("yyyy/MM/dd"));
            order.idItem = 2;

            var orderID = (from oID in _context.Ordenes
                           where oID.IdOrden >= 1615
                           select new
                           {
                               IdOrden = oID.IdOrden
                           }).ToList();

            foreach (var od in orderID)
            {
                order.idOrden += 1;
            }
            OrdenesTexas newOrderTX = new OrdenesTexas();
            newOrderTX.IdOrden = order.idOrden;
            newOrderTX.EstadoOrden = order.estadoOrden;
            newOrderTX.FechaEnvio = order.fechaEnvio;
            newOrderTX.FechaOrden = order.fechaOrden;
            newOrderTX.IdCliente = order.idCliente;
            newOrderTX.IdEmpleado = order.idEmpleado;
            newOrderTX.IdTienda = order.idTienda;
            newOrderTX.RequiredDate = order.required_date;
            _context.Add(newOrderTX);
            DetalleOrden detOrderTX = new DetalleOrden();
            detOrderTX.Cantidad = order.cantidad;
            detOrderTX.Descuento = order.descuento;
            detOrderTX.IdItem = order.idItem;
            detOrderTX.IdOrden = order.idOrden;
            detOrderTX.IdProducto = order.idProducto;
            detOrderTX.PrecioVenta = order.precioVenta;
            _context.Add(detOrderTX);

            Ordenes orderInsTX = new Ordenes();
            orderInsTX.IdOrden = order.idOrden;
            _context.Ordenes.Add(orderInsTX);
            _context.SaveChanges();
            return 1;
        }
    }
}
