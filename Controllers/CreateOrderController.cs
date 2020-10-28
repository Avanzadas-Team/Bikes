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
    public class CreateOrderController : ControllerBase
    {

        private readonly ILogger<ClientsController> _logger;
        private readonly Ventas _context;

        public CreateOrderController(ILogger<ClientsController> logger, Ventas context)
        {
            _logger = logger;
            _context = context;
        }


        // GET: api/<CreateOrderComponent>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<CreateOrderComponent>
        [HttpPost]
        public int Post(OrderIns order)
        {
            Ordenes last = _context.Ordenes.ToList().Last();

            order.idOrden = last.IdOrden + 1;

            switch (order.idTienda)
            {
                case 1:
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
                    break;

                case 2:
                    OrdenesCalifornia newOrderCA = new OrdenesCalifornia();
                    newOrderCA.IdOrden = order.idOrden;
                    newOrderCA.EstadoOrden = order.estadoOrden;
                    newOrderCA.FechaEnvio = order.fechaEnvio;
                    newOrderCA.FechaOrden = order.fechaOrden;
                    newOrderCA.IdCliente = order.idCliente;
                    newOrderCA.IdEmpleado = order.idEmpleado;
                    newOrderCA.IdTienda = order.idTienda;
                    newOrderCA.RequiredDate = order.required_date;
                    _context.Add(newOrderCA);

                    DetalleOrden detOrderCA = new DetalleOrden();
                    detOrderCA.Cantidad = order.cantidad;
                    detOrderCA.Descuento = order.descuento;
                    detOrderCA.IdItem = order.idItem;
                    detOrderCA.IdOrden = order.idOrden;
                    detOrderCA.IdProducto = order.idProducto;
                    detOrderCA.PrecioVenta = order.precioVenta;
                    _context.Add(detOrderCA);

                    Ordenes orderInsCA = new Ordenes();
                    orderInsCA.IdOrden = order.idOrden;
                    _context.Ordenes.Add(orderInsCA);

                    _context.SaveChanges();
                    break;


                case 3:
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
                    break;

                default:
                    break;
            }

            return order.idOrden;
        }
    }
}
