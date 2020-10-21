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
            List<Clientes> clientes = _context.Clientes.ToList<Clientes>();

            foreach (Clientes cliente in clientes)
            {
                int ordersQuant = cliente.OrdenesCalifornia.Count + cliente.OrdenesNewYork.Count + cliente.OrdenesTexas.Count;
                quantitity.Add(cliente, ordersQuant);
            }

            return quantitity;
        }
    }
}
