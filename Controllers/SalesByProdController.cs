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
    public class SalesByProdController : ControllerBase
    {

        private ILogger<SalesByProdController> _logger;
        private Ventas _context;
        private ProduccionContext _pcontext;

        public SalesByProdController(ILogger<SalesByProdController> logger, Ventas context, ProduccionContext pcontext)
        {
            _logger = logger;
            _context = context;
            _pcontext = pcontext;
        }

        // GET: api/<SalesByProdController>
        [HttpGet]
        public List<Categories> Get()
        {
            List<Categories> catgList = new List<Categories>();

            foreach (Categorias catg in _pcontext.Categorias.ToList())
            {
                Categories temp = new Categories();
                temp.name = catg.Descripcion;
                temp.idCategory = catg.IdCategoria;
                catgList.Add(temp);
            }

            return catgList;
        }

        // GET api/<SalesByProdController>/5
        [HttpGet("{id}/{month}/{year}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SalesByProdController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SalesByProdController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SalesByProdController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}
