using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bikes.Models
{
    public class OrderIns
    {
        public int idOrden;
        public int idCliente;
        public byte estadoOrden;
        public DateTime fechaOrden;
        public DateTime required_date;
        public DateTime fechaEnvio;
        public int idTienda;
        public int idEmpleado;
        public int idProducto;
        public int idItem;
        public int cantidad;
        public decimal precioVenta;
        public decimal descuento;
    }
}
