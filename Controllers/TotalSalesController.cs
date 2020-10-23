using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bikes.DTO;
using Bikes.Models;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bikes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TotalSalesController : ControllerBase
    {
        private ILogger<TotalSalesController> _logger;
        private Ventas _context;

        public TotalSalesController(ILogger<TotalSalesController> logger, Ventas context)
        {
            _logger = logger;
            _context = context;
        }

        // GET api/<TotalSalesController>/
        [HttpGet]
        public TotalSales Get()
        {

            Console.WriteLine(Environment.GetEnvironmentVariable("CITY"));

            switch (Environment.GetEnvironmentVariable("CITY"))
            {
                case "NY" :
                    return GetNY();

                case "CA":
                    return GetCal();

                case "TX":
                    return GetTX();

                default:
                    TotalSales total = new TotalSales();
                    total.totalSales = -1;
                    return total;

            }

        }

        private TotalSales GetNY()
        {
            decimal salesTotal = 0;

            var ordersNY = (from oNY in _context.OrdenesNewYork
                          join od in _context.DetalleOrden
                          on oNY.IdOrden equals od.IdOrden
                          where oNY.EstadoOrden == 4
                          select new
                          {
                              IdOrden = oNY.IdOrden,
                              EstadoOrden = oNY.EstadoOrden,
                              PrecioVenta = od.PrecioVenta
                          }).ToList();

            foreach (var orders in ordersNY)
            {
                salesTotal += orders.PrecioVenta;
            }

            TotalSales total = new TotalSales
            {
                totalSales = salesTotal
            };

            return total;

        }

        private TotalSales GetTX()
        {
            decimal salesTotal = 0;

            var ordersNY = (from oNY in _context.OrdenesTexas
                            join od in _context.DetalleOrden
                            on oNY.IdOrden equals od.IdOrden
                            where oNY.EstadoOrden == 4
                            select new
                            {
                                IdOrden = oNY.IdOrden,
                                EstadoOrden = oNY.EstadoOrden,
                                PrecioVenta = od.PrecioVenta
                            }).ToList();

            foreach (var orders in ordersNY)
            {
                salesTotal += orders.PrecioVenta;
            }

            TotalSales total = new TotalSales
            {
                totalSales = salesTotal
            };

            return total;

        }

        private TotalSales GetCal()
        {
            decimal salesTotal = 0;

            var ordersNY = (from oNY in _context.OrdenesCalifornia
                            join od in _context.DetalleOrden
                            on oNY.IdOrden equals od.IdOrden
                            where oNY.EstadoOrden == 4
                            select new
                            {
                                IdOrden = oNY.IdOrden,
                                EstadoOrden = oNY.EstadoOrden,
                                PrecioVenta = od.PrecioVenta
                            }).ToList();

            foreach (var orders in ordersNY)
            {
                salesTotal += orders.PrecioVenta;
            }

            TotalSales total = new TotalSales
            {
                totalSales = salesTotal
            };

            return total;

        }



        // POST api/<TotalSalesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TotalSalesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TotalSalesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
