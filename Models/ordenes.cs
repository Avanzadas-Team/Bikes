using System;
using System.ComponentModel.DataAnnotations;

namespace Bikes.Models
{
    public class ordenes
    {
        [Key]
        public int idOrden { get; set; }
        public int idCliente { get; set; }
        public byte estadoOrden { get; set; }
        public DateTime fechaOrden { get; set; }
        public DateTime require_date { get; set; }
        public DateTime fechaEnvio { get; set; }
        public int idTienda { get; set; }
        public int idEmpleado { get; set; }
    }
}
