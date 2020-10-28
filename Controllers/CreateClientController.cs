using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bikes.DTO;
using Bikes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bikes.DTO
{
    [Route("[controller]")]
    [ApiController]
    public class CreateClientController : ControllerBase
    {
        private ILogger<CreateClientController> _logger;
        private Ventas _context;

        public CreateClientController(ILogger<CreateClientController> logger, Ventas context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public int PostNY(ClientIns client)
        {
            client.idClient = 1400;
            var clientID = (from oID in _context.Clientes
                           where oID.IdCliente >= 1400
                           select new
                           {
                               ClienteID = oID.IdCliente
                           }).ToList();

            foreach (var od in clientID)
            {
                client.idClient += 1;
            }
            Clientes Nclient = new Clientes();
            Nclient.IdCliente = client.idClient;
            Nclient.Nombre = client.nombre;
            Nclient.Apellido = client.apellido;
            Nclient.Email = client.email;
            Nclient.Ciudad = client.ciudad;
            Nclient.Estado = client.estado;
            Nclient.Calle = client.calle;
            Nclient.CodPostal = client.codPostal;
            Nclient.Telefono = "";
            _context.Add(Nclient);
            _context.SaveChanges();

            return 1;
        }

    }
}
