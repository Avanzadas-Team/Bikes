using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bikes.DTO;
using Bikes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Bikes.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ILogger<SellerController> _logger;
        private ProduccionContext _context;

        public ProductController(ILogger<SellerController> logger, ProduccionContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public List<ProductID> Get()
        {
            List<ProductID> productsList = new List<ProductID>();

            foreach (Productos product in _context.Productos.ToList())
            {
                ProductID dummy = new ProductID();
                dummy.name = product.NomProducto;
                dummy.idProduct = product.IdProducto;
                dummy.price = product.PrecioVenta;
                productsList.Add(dummy);
            }

            return productsList;
        }
    }
}
