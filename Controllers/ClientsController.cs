using System.Collections.Generic;
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
        private readonly AppDB _context;

        public ClientsController(ILogger<ClientsController> logger, AppDB context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<clientes> Get()
        {
            return _context.GetClients();
        }
    }
}
