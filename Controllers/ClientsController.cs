using System.Collections.Generic;
using System.Linq;
using Bikes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bikes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly Ventas _context;

        public ClientsController(ILogger<ClientsController> logger, Ventas context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<Clientes,int>> Get()
        {
            Dictionary<Clientes, int> quantitity = new Dictionary<Clientes, int>();
            List<Clientes> clients = _context.Clientes.ToList<Clientes>();

            foreach (Clientes client in clients)
            {
                int ordersCA = _context.OrdenesCalifornia.Where(val => val.IdCliente == client.IdCliente).ToList().Count;
                int ordersNY = _context.OrdenesNewYork.Where(val => val.IdCliente == client.IdCliente).ToList().Count;
                int ordersTX = _context.OrdenesTexas.Where(val => val.IdCliente == client.IdCliente).ToList().Count;
                int ordersQuant = ordersCA + ordersNY + ordersTX;
                quantitity.Add(client, ordersQuant);
            }

            return quantitity.OrderByDescending(k => k.Value).ToList<KeyValuePair<Clientes,int>>();
        }
    }
}
