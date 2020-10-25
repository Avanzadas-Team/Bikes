using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bikes.DTO
{
    public class Order
    {
        public Order(int idOrden, int idItem, int idProducto, int cantidad, decimal precioVenta, int? idCliente, byte estadoOrden, DateTime fechaOrden, DateTime requiredDate, DateTime? fechaEnvio, int idTienda, int idEmpleado, decimal descuento, string clienteNombre, string clienteApellido, string empleadoNombre, string empleadoApellido, string productName)
        {
            IdOrden = idOrden;
            IdItem = idItem;
            IdProducto = idProducto;
            Cantidad = cantidad;
            PrecioVenta = precioVenta;
            IdCliente = idCliente;
            EstadoOrden = estadoOrden;
            FechaOrden = fechaOrden;
            RequiredDate = requiredDate;
            FechaEnvio = fechaEnvio;
            IdTienda = idTienda;
            IdEmpleado = idEmpleado;
            Descuento = descuento;
            ClienteNombre = clienteNombre;
            ClienteApellido = clienteApellido;
            EmpleadoNombre = empleadoNombre;
            EmpleadoApellido = empleadoApellido;
            ProductName = productName;
        }

        public int IdOrden { get; set; }
        public int IdItem { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal Descuento { get; set; }
        public int? IdCliente { get; set; }
        public byte EstadoOrden { get; set; }
        public DateTime FechaOrden { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public int IdTienda { get; set; }
        public int IdEmpleado { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteApellido { get; set; }
        public string EmpleadoNombre { get; set; }
        public string EmpleadoApellido { get; set; }
        public string ProductName { get; set; }

    }
}
