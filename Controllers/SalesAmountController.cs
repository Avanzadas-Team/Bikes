using System;
using System.Collections.Generic;
using System.Linq;
using Bikes.DTO;
using Bikes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bikes.Controllers
{
    [Route("sa")]
    [ApiController]
    public class SalesAmountController : ControllerBase
    {
        private readonly ILogger<SalesAmountController> _logger;
        private readonly Ventas _ventasContext;
        private readonly ProduccionContext _producctionContext;

        public SalesAmountController(ILogger<SalesAmountController> logger, Ventas vContext, ProduccionContext pContext)
        {
            _logger = logger;
            _ventasContext = vContext;
            _producctionContext = pContext;

        }
        [HttpGet("All")]
        public IEnumerable<Order> GetTotalSales()
        {
            return this.GetTotalSalesCA().Concat(this.GetTotalSalesNY()).Concat(this.GetTotalSalesTX());
        }
        [HttpGet("NY")]
        public IEnumerable<Order> GetTotalSalesNY()
        {
            var incOrders = _ventasContext.OrdenesNewYork.Join(
                _ventasContext.DetalleOrden,
                order => order.IdOrden,
                detail => detail.IdOrden,
                (order, detail) => new
                {
                    order.IdOrden,
                    detail.IdItem,
                    detail.IdProducto,
                    detail.Cantidad,
                    detail.PrecioVenta,
                    order.IdCliente,
                    order.EstadoOrden,
                    order.FechaOrden,
                    order.RequiredDate,
                    order.FechaEnvio,
                    order.IdTienda,
                    order.IdEmpleado,
                    detail.Descuento
                }
                ).Join(_ventasContext.Clientes,
                order => order.IdCliente,
                client => client.IdCliente,
                (order, client) => new
                {
                    order.IdOrden,
                    order.IdItem,
                    order.IdProducto,
                    order.Cantidad,
                    order.PrecioVenta,
                    order.IdCliente,
                    order.EstadoOrden,
                    order.FechaOrden,
                    order.RequiredDate,
                    order.FechaEnvio,
                    order.IdTienda,
                    order.IdEmpleado,
                    order.Descuento,
                    client.Nombre,
                    client.Apellido
                }).Join(_ventasContext.EmpleadosNewYork,
                order => order.IdEmpleado,
                employee => employee.IdEmpleado,
                (order, employee) => new
                {
                    order.IdOrden,
                    order.IdItem,
                    order.IdProducto,
                    order.Cantidad,
                    order.PrecioVenta,
                    order.IdCliente,
                    order.EstadoOrden,
                    order.FechaOrden,
                    order.RequiredDate,
                    order.FechaEnvio,
                    order.IdTienda,
                    order.IdEmpleado,
                    order.Descuento,
                    order.Nombre,
                    order.Apellido,
                    eNombre = employee.Nombre,
                    eApellido = employee.Apellido
                }).ToList();

            List<Order> orders = new List<Order>(); 
            foreach (var order in incOrders)
            {
                Productos product = _producctionContext.Productos.Find(order.IdProducto);
                        orders.Add(new Order(
                        order.IdOrden,
                        order.IdItem,
                        order.IdProducto,
                        order.Cantidad,
                        order.PrecioVenta,
                        order.IdCliente,
                        order.EstadoOrden,
                        order.FechaOrden,
                        order.RequiredDate,
                        order.FechaEnvio,
                        order.IdTienda,
                        order.IdEmpleado,
                        order.Descuento,
                        order.Nombre,
                        order.Apellido,
                        order.eNombre,
                        order.eApellido,
                        product.NomProducto
                        )
                    );
            }
            return orders;
        }
        [HttpGet("CA")]
        public IEnumerable<Order> GetTotalSalesCA()
        {
            var incOrders = _ventasContext.OrdenesCalifornia.Join(
                _ventasContext.DetalleOrden,
                order => order.IdOrden,
                detail => detail.IdOrden,
                (order, detail) => new
                {
                    order.IdOrden,
                    detail.IdItem,
                    detail.IdProducto,
                    detail.Cantidad,
                    detail.PrecioVenta,
                    order.IdCliente,
                    order.EstadoOrden,
                    order.FechaOrden,
                    order.RequiredDate,
                    order.FechaEnvio,
                    order.IdTienda,
                    order.IdEmpleado,
                    detail.Descuento
                }
                ).Join(_ventasContext.Clientes,
                order => order.IdCliente,
                client => client.IdCliente,
                (order, client) => new {
                    order.IdOrden,
                    order.IdItem,
                    order.IdProducto,
                    order.Cantidad,
                    order.PrecioVenta,
                    order.IdCliente,
                    order.EstadoOrden,
                    order.FechaOrden,
                    order.RequiredDate,
                    order.FechaEnvio,
                    order.IdTienda,
                    order.IdEmpleado,
                    order.Descuento,
                    client.Nombre,
                    client.Apellido
                }).Join(_ventasContext.EmpleadosCalifornia,
                order => order.IdEmpleado,
                employee => employee.IdEmpleado,
                (order, employee) => new
                {
                    order.IdOrden,
                    order.IdItem,
                    order.IdProducto,
                    order.Cantidad,
                    order.PrecioVenta,
                    order.IdCliente,
                    order.EstadoOrden,
                    order.FechaOrden,
                    order.RequiredDate,
                    order.FechaEnvio,
                    order.IdTienda,
                    order.IdEmpleado,
                    order.Descuento,
                    order.Nombre,
                    order.Apellido,
                    eNombre = employee.Nombre,
                    eApellido = employee.Apellido
                }).ToList();
            List<Order> orders = new List<Order>();
            foreach (var order in incOrders)
            {
                Productos product = _producctionContext.Productos.Find(order.IdProducto);
                orders.Add(new Order(
                order.IdOrden,
                order.IdItem,
                order.IdProducto,
                order.Cantidad,
                order.PrecioVenta,
                order.IdCliente,
                order.EstadoOrden,
                order.FechaOrden,
                order.RequiredDate,
                order.FechaEnvio,
                order.IdTienda,
                order.IdEmpleado,
                order.Descuento,
                order.Nombre,
                order.Apellido,
                order.eNombre,
                order.eApellido,
                product.NomProducto
                )
            );
            }
            return orders;
        }
        [HttpGet("TX")]
        public IEnumerable<Order> GetTotalSalesTX()
        {
            var incOrders = _ventasContext.OrdenesTexas.Join(
                _ventasContext.DetalleOrden,
                order => order.IdOrden,
                detail => detail.IdOrden,
                (order, detail) => new
                {
                    order.IdOrden,
                    detail.IdItem,
                    detail.IdProducto,
                    detail.Cantidad,
                    detail.PrecioVenta,
                    order.IdCliente,
                    order.EstadoOrden,
                    order.FechaOrden,
                    order.RequiredDate,
                    order.FechaEnvio,
                    order.IdTienda,
                    order.IdEmpleado,
                    detail.Descuento
                }
                ).Join(_ventasContext.Clientes,
                order => order.IdCliente,
                client => client.IdCliente,
                (order, client) => new {
                    order.IdOrden,
                    order.IdItem,
                    order.IdProducto,
                    order.Cantidad,
                    order.PrecioVenta,
                    order.IdCliente,
                    order.EstadoOrden,
                    order.FechaOrden,
                    order.RequiredDate,
                    order.FechaEnvio,
                    order.IdTienda,
                    order.IdEmpleado,
                    order.Descuento,
                    client.Nombre,
                    client.Apellido
                }).Join(_ventasContext.EmpleadosTexas,
                order => order.IdEmpleado,
                employee => employee.IdEmpleado,
                (order, employee) => new
                {
                    order.IdOrden,
                    order.IdItem,
                    order.IdProducto,
                    order.Cantidad,
                    order.PrecioVenta,
                    order.IdCliente,
                    order.EstadoOrden,
                    order.FechaOrden,
                    order.RequiredDate,
                    order.FechaEnvio,
                    order.IdTienda,
                    order.IdEmpleado,
                    order.Descuento,
                    order.Nombre,
                    order.Apellido,
                    eNombre = employee.Nombre,
                    eApellido = employee.Apellido
                }).ToList();
            List<Order> orders = new List<Order>();
            foreach (var order in incOrders)
            {
                Productos product = _producctionContext.Productos.Find(order.IdProducto);
                orders.Add(new Order(
                order.IdOrden,
                order.IdItem,
                order.IdProducto,
                order.Cantidad,
                order.PrecioVenta,
                order.IdCliente,
                order.EstadoOrden,
                order.FechaOrden,
                order.RequiredDate,
                order.FechaEnvio,
                order.IdTienda,
                order.IdEmpleado,
                order.Descuento,
                order.Nombre,
                order.Apellido,
                order.eNombre,
                order.eApellido,
                product.NomProducto
                )
            );
            }
            return orders;
        }


        [HttpGet("prods")]
        public List<Products> GetProducts()
        {
            List<Products> prodList = new List<Products>();
            
            foreach (Productos prod in _producctionContext.Productos.ToList())
            {
                Products temp = new Products();
                temp.name = prod.NomProducto;
                temp.id = prod.IdProducto;
                prodList.Add(temp);
            }

            return prodList;
        }

        [HttpGet("NY/{id}/{dateS}/{dateE}")]
        public List<SalesAmountByProd> GetSalesNY(string id, string dateS, string dateE)
        {
            var result = GetProdNY(id,dateS, dateE);
            return result;
        }

        [HttpGet("CA/{id}/{dateS}/{dateE}")]
        public List<SalesAmountByProd> GetSalesCA(string id, string dateS, string dateE)
        {
            var result = GetProdCA(id, dateS, dateE);
            return result;
        }

        [HttpGet("TX/{id}/{dateS}/{dateE}")]
        public List<SalesAmountByProd> GetSalesTX(string id, string dateS, string dateE)
        {
            var result = GetProdTX(id, dateS, dateE);
            return result;
        }


        private List<SalesAmountByProd> GetProdNY(string id, string dateS, string dateE)
        {
            int prod = Int16.Parse(id);
            var iDate = DateTime.Parse(dateS).Date;
            var fDate = DateTime.Parse(dateE).Date;
            List<SalesAmountByProd> salesList = new List<SalesAmountByProd>();

            var ordersNY = (from oNY in _ventasContext.OrdenesNewYork
                            join oD in _ventasContext.DetalleOrden
                            on oNY.IdOrden equals oD.IdOrden
                            where ((oD.IdProducto == prod) && (oNY.FechaOrden >= iDate && oNY.FechaOrden <= fDate))
                            select new
                            {
                                IDO = oNY.IdOrden,
                                Price = oD.PrecioVenta,
                                Cant = oD.Cantidad,
                                CID = oNY.IdCliente,
                                Date = oNY.RequiredDate,
                                Discount=oD.Descuento

                            }).ToList();


            foreach (var order in ordersNY)
            {
                SalesAmountByProd s = new SalesAmountByProd();
                s.idOrder = order.IDO;
                s.price = order.Price;
                s.cant = order.Cant;
                s.idClient = (int)order.CID;
                s.date = order.Date.Date;
                s.discount = order.Discount;
                salesList.Add(s);
            } 

            return salesList;

        }

        private List<SalesAmountByProd> GetProdCA(string id, string dateS, string dateE)
        {
            int prod = Int16.Parse(id);
            var iDate = DateTime.Parse(dateS).Date;
            var fDate = DateTime.Parse(dateE).Date;
            List<SalesAmountByProd> salesList = new List<SalesAmountByProd>();

            var ordersCA = (from oCA in _ventasContext.OrdenesCalifornia
                            join oD in _ventasContext.DetalleOrden
                            on oCA.IdOrden equals oD.IdOrden
                            where ((oD.IdProducto == prod) && (oCA.FechaOrden >= iDate && oCA.FechaOrden <= fDate))
                            select new
                            {
                                IDO = oCA.IdOrden,
                                Price = oD.PrecioVenta,
                                Cant = oD.Cantidad,
                                CID = oCA.IdCliente,
                                Date = oCA.RequiredDate,
                                Discount = oD.Descuento

                            }).ToList();


            foreach (var order in ordersCA)
            {
                SalesAmountByProd s = new SalesAmountByProd();
                s.idOrder = order.IDO;
                s.price = order.Price;
                s.cant = order.Cant;
                s.idClient = (int)order.CID;
                s.date = order.Date.Date;
                s.discount = order.Discount;
                salesList.Add(s);
            }

            return salesList;

        }

        private List<SalesAmountByProd> GetProdTX(string id, string dateS, string dateE)
        {
            int prod = Int16.Parse(id);
            var iDate = DateTime.Parse(dateS).Date;
            var fDate = DateTime.Parse(dateE).Date;
            List<SalesAmountByProd> salesList = new List<SalesAmountByProd>();

            var ordersTX = (from oTX in _ventasContext.OrdenesTexas
                            join oD in _ventasContext.DetalleOrden
                            on oTX.IdOrden equals oD.IdOrden
                            where ((oD.IdProducto == prod) && (oTX.FechaOrden >= iDate && oTX.FechaOrden <= fDate))
                            select new
                            {
                                IDO = oTX.IdOrden,
                                Price = oD.PrecioVenta,
                                Cant = oD.Cantidad,
                                CID = oTX.IdCliente,
                                Date = oTX.RequiredDate,
                                Discount = oD.Descuento

                            }).ToList();


            foreach (var order in ordersTX)
            {
                SalesAmountByProd s = new SalesAmountByProd();
                s.idOrder = order.IDO;
                s.price = order.Price;
                s.cant = order.Cant;
                s.idClient = (int)order.CID;
                s.date = order.Date.Date;
                s.discount = order.Discount;
                salesList.Add(s);
            }

            return salesList;

        }
    }
}
