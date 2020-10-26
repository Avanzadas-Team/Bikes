using System.Collections.Generic;
using System.Linq;
using Bikes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Bikes.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SellersController:ControllerBase
    {
        private readonly ILogger<SellersController> _logger;
        private readonly Ventas _context;

        public SellersController(ILogger<SellersController> logger, Ventas context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public List<EmpleadosCalifornia> Get()
        {
            Dictionary<EmpleadosCalifornia, int> quantitity = new Dictionary<EmpleadosCalifornia, int>();
            List<EmpleadosCalifornia> employees = _context.EmpleadosCalifornia.ToList<EmpleadosCalifornia>();
            List<KeyValuePair<EmpleadosCalifornia, int>> vals = new List<KeyValuePair<EmpleadosCalifornia, int>>();

            vals = quantitity.OrderByDescending(k => k.Value).ToList<KeyValuePair<EmpleadosCalifornia, int>>();

            return employees;
        }
    }
}