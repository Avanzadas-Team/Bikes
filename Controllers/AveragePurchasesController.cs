using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Bikes.DTO;
using Bikes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Security.Certificates;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bikes.Controllers
{
    [Route("avgp")]
    [ApiController]
    public class AveragePurchasesController : ControllerBase
    {
        private ILogger<AveragePurchasesController> _logger;
        private Ventas _context;

        public AveragePurchasesController(ILogger<AveragePurchasesController> logger, Ventas context)
        {
            _logger = logger;
            _context = context;
        }

        // GET api/<AveragePurchasesController>/11-11-11/11-11-11
        [HttpGet("NY/{dateS}/{dateE}")]
        public List<AveragePurchaseByClient> GetAverageNY(string dateS, string dateE)
        {
            var result = GetNY(dateS, dateE);
            return result;
        }

        // GET api/<AveragePurchasesController>/5
        [HttpGet("CA/{dateS}/{dateE}")]
        public List<AveragePurchaseByClient> GetAverageCA(string dateS, string dateE)
        {
            var result = GetCA(dateS, dateE);
            return result;
        }

        // GET api/<AveragePurchasesController>/5
        [HttpGet("TX/{dateS}/{dateE}")]
        public List<AveragePurchaseByClient> GetAverageTX(string dateS, string dateE)
        {
            var result = GetTX(dateS, dateE);
            return result;
        }


        private List<AveragePurchaseByClient> GetNY(string dateS, string dateE)
        {
            var iDate = DateTime.Parse(dateS).Date;
            var fDate = DateTime.Parse(dateE).Date;
            List<AveragePurchaseByClient> clientList = new List<AveragePurchaseByClient>();

            var ordersNY = (from c in _context.Clientes
                            join oNY in _context.OrdenesNewYork
                            on c.IdCliente equals oNY.IdCliente
                            join oD in _context.DetalleOrden
                            on oNY.IdOrden equals oD.IdOrden
                            where (oNY.FechaOrden >= iDate && oNY.FechaOrden <= fDate)
                            select new
                            {
                                ID = c.IdCliente,
                                Name = c.Nombre,
                                LName= c.Apellido,
                                Amount = oD.PrecioVenta * oD.Cantidad

                            }).ToList();

            var clients = ordersNY.GroupBy(x => x.ID);

            foreach( var client in clients)
            {
                AveragePurchaseByClient c = new AveragePurchaseByClient();
                c.clientName = client.ElementAt(0).Name;
                c.clientLastName = client.ElementAt(0).LName;
                c.averagePurchases= client.Average(x => x.Amount);
                clientList.Add(c);
            }

            return clientList;

        }

        private List<AveragePurchaseByClient> GetCA(string dateS, string dateE)
        {
            var iDate = DateTime.Parse(dateS).Date;
            var fDate = DateTime.Parse(dateE).Date;
            List<AveragePurchaseByClient> clientList = new List<AveragePurchaseByClient>();

            var ordersCA = (from c in _context.Clientes
                            join oCA in _context.OrdenesCalifornia
                            on c.IdCliente equals oCA.IdCliente
                            join oD in _context.DetalleOrden
                            on oCA.IdOrden equals oD.IdOrden
                            where (oCA.FechaOrden >= iDate && oCA.FechaOrden <= fDate)
                            select new
                            {
                                ID = c.IdCliente,
                                Name = c.Nombre,
                                LName = c.Apellido,
                                Amount = oD.PrecioVenta * oD.Cantidad
                            }).ToList();

            var clients = ordersCA.GroupBy(x => x.ID);

            foreach (var client in clients)
            {
                AveragePurchaseByClient c = new AveragePurchaseByClient();
                c.clientName = client.ElementAt(0).Name;
                c.clientLastName = client.ElementAt(0).LName;
                c.averagePurchases = client.Average(x => x.Amount);
                clientList.Add(c);
            }

            return clientList;

        }

        private List<AveragePurchaseByClient> GetTX(string dateS, string dateE)
        {
            var iDate = DateTime.Parse(dateS).Date;
            var fDate = DateTime.Parse(dateE).Date;
            List<AveragePurchaseByClient> clientList = new List<AveragePurchaseByClient>();

            var ordersTX = (from c in _context.Clientes
                            join oTX in _context.OrdenesTexas
                            on c.IdCliente equals oTX.IdCliente
                            join oD in _context.DetalleOrden
                            on oTX.IdOrden equals oD.IdOrden
                            where (oTX.FechaOrden >= iDate && oTX.FechaOrden <= fDate)
                            select new
                            {
                                ID = c.IdCliente,
                                Name = c.Nombre,
                                LName = c.Apellido,
                                Amount = oD.PrecioVenta * oD.Cantidad
                            }).ToList();

            var clients = ordersTX.GroupBy(x => x.ID);

            foreach (var client in clients)
            {
                AveragePurchaseByClient c = new AveragePurchaseByClient();
                c.clientName = client.ElementAt(0).Name;
                c.clientLastName = client.ElementAt(0).LName;
                c.averagePurchases = client.Average(x => x.Amount);
                clientList.Add(c);
            }

            return clientList;

        }


        
    }
}
