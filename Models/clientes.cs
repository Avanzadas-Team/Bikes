﻿using System.ComponentModel.DataAnnotations;

namespace Bikes.Models
{
    public class clientes
    {
        [Key]
        public int idCliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string calle { get; set; }
        public string ciudad { get; set; }
        public string estado { get; set; }
        public string codPostal { get; set; }
    }
}
