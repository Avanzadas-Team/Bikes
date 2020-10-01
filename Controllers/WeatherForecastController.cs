using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bikes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bikes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly AppDB _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, AppDB context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _context.GetSummaries();
        }
    }
}
