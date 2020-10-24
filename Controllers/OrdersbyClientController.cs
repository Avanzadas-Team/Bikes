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
    public class OrdersbyClientController : ControllerBase
    {
        private ILogger<OrdersbyClientController> _logger;
        private Ventas _context;

        public OrdersbyClientController(ILogger<OrdersbyClientController> logger, Ventas context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: api/<OrdersbyClientController>
        [HttpGet]
        public List<ClientsID> Get()
        {

            List<ClientsID> clientList = new List<ClientsID>();

            foreach(Clientes client in _context.Clientes.ToList())
            {
                ClientsID dummy = new ClientsID();
                dummy.name = client.Nombre + " " + client.Apellido;
                dummy.idClient = client.IdCliente;
                clientList.Add(dummy);
            }

            return clientList;
        }

        // GET api/<OrdersbyClientController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersbyClientController>
        [HttpPost]
        public ClientDates Post(ClientDates clientD)
        {
            switch (Environment.GetEnvironmentVariable("CITY"))
            {
                case "NY":
                    return PostNY(clientD);

                case "CA":
                    return PostCal(clientD);

                case "TX":
                    return PostTX(clientD);

                default:
                    return clientD;

            }
        }

        private ClientDates PostNY(ClientDates clientD)
        {

            Console.WriteLine(clientD.dateS);

            var ordersNY = (from c in _context.Clientes
                            join oNY in _context.OrdenesNewYork
                            on c.IdCliente equals oNY.IdCliente
                            where c.IdCliente == clientD.idClient
                            select new
                            {
                                IdCliente = c.IdCliente,
                                FechasOrden = oNY.FechaOrden
                            }).ToList();
            int totalO = 0;

            foreach (var orders in ordersNY)
            {
                if(orders.FechasOrden >= clientD.dateS.Date && orders.FechasOrden <= clientD.dateE.Date)
                {
                    totalO += 1;
                }
            }

            clientD.totalOrders = totalO;

            return clientD;
        }

        private ClientDates PostCal(ClientDates clientD)
        {
            var ordersNY = (from c in _context.Clientes
                            join oNY in _context.OrdenesCalifornia
                            on c.IdCliente equals oNY.IdCliente
                            where c.IdCliente == clientD.idClient &&
                            (oNY.FechaOrden >= clientD.dateS && clientD.dateS <= clientD.dateE)
                            select new
                            {
                                IdCliente = c.IdCliente,
                            }).ToList();
            int totalO = 0;

            foreach (var orders in ordersNY)
            {
                totalO += 1;
            }

            clientD.totalOrders = totalO;

            return clientD;
        }

        private ClientDates PostTX(ClientDates clientD)
        {
            var ordersNY = (from c in _context.Clientes
                            join oNY in _context.OrdenesTexas
                            on c.IdCliente equals oNY.IdCliente
                            where c.IdCliente == clientD.idClient &&
                            (oNY.FechaOrden >= clientD.dateS && clientD.dateS <= clientD.dateE)
                            select new
                            {
                                IdCliente = c.IdCliente,
                            }).ToList();
            int totalO = 0;

            foreach (var orders in ordersNY)
            {
                totalO += 1;
            }

            clientD.totalOrders = totalO;

            return clientD;
        }

        // PUT api/<OrdersbyClientController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersbyClientController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
