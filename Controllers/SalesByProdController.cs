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
    [Route("sbpc")]
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

        // GET sbpc/NY/5/January/2016
        [HttpGet("NY/{id}/{month}/{year}")]
        public List<ProductSalesByCtg> GetProdNY(string id, string month, string year)
        {
            var result = GetNY(id, month, year);
            return result;
        }

        // GET sbpc/CA/5/January/2016
        [HttpGet("CA/{id}/{month}/{year}")]
        public List<ProductSalesByCtg> GetProdCA(string id, string month, string year)
        {
            var result = GetCA(id, month, year);
            return result;
        }

        // GET sbpc/TX/5/January/2016
        [HttpGet("TX/{id}/{month}/{year}")]
        public List<ProductSalesByCtg> GetProdTX(string id, string month, string year)
        {
            var result = GetTX(id, month, year);
            return result;
        }


        private int MonthSelector(string month)
        {
            switch (month)
            {
                case "January":
                    return 1;
                case "February":
                    return 2;
                case "March":
                    return 3;
                case "April":
                    return 4;
                case "May":
                    return 5;
                case "June":
                    return 6;
                case "July":
                    return 7;
                case "August":
                    return 8;
                case "September":
                    return 9;
                case "October":
                    return 10;
                case "November":
                    return 11;
                case "December":
                    return 12;
                default:
                    return 0;
            }
        }

        private List<string> DateMaker(string month,string year )
        {
            List<string> dateList= new List<string>();
            string sDate = year + "-" + MonthSelector(month) + "-01";
            string eDate;
            if (month == "December")
            {
                var newYear = (Int16.Parse(year) + 1).ToString();
                eDate = newYear + "-01-01";
            }
            else
            {
                eDate = year + "-" + (MonthSelector(month) + 1).ToString() + "-01";
            }

            dateList.Add(sDate);
            dateList.Add(eDate);
            return dateList;

        }

        private List<ProductSalesByCtg> GetNY(string id, string month, string year)
        {
            int catg = Int16.Parse(id);
            var dates = DateMaker(month, year);
            var iDate = DateTime.Parse(dates.ElementAt(0));
            var fDate = DateTime.Parse(dates.ElementAt(1));


            List<ProductSalesByCtg> prodList = new List<ProductSalesByCtg>();

            var productsByCat = (from prod in _pcontext.Productos
                                where prod.IdCategoria == catg
                                select new
                                {
                                    ID = prod.IdProducto,
                                    IDC = prod.IdCategoria,
                                    Name = prod.NomProducto
                                }).ToList();


            var ordersNY= (from oNY in _context.OrdenesNewYork
                          join oD in _context.DetalleOrden
                          on oNY.IdOrden equals oD.IdOrden
                          where (oNY.FechaOrden >= iDate && oNY.FechaOrden < fDate)
                          select new
                          {
                              IDP= oD.IdProducto,
                              Price = oD.PrecioVenta
                          }).ToList();



            var productsNY = (from p in productsByCat
                              join o in ordersNY
                              on p.ID equals o.IDP
                              select new 
                              {
                                  ID = p.ID,
                                  Name = p.Name,
                                  Price = o.Price
                              }).ToList();

            var products = productsNY.GroupBy(x => x.ID);

            foreach (var product in products)
            {
                ProductSalesByCtg p = new ProductSalesByCtg();
                p.pName = product.ElementAt(0).Name;
                p.salesSum = product.Sum(x => x.Price);
                prodList.Add(p);
            }

            return prodList;

        }


        private List<ProductSalesByCtg> GetCA(string id, string month, string year)
        {
            int catg = Int16.Parse(id);
            var dates = DateMaker(month, year);
            var iDate = DateTime.Parse(dates.ElementAt(0));
            var fDate = DateTime.Parse(dates.ElementAt(1));


            List<ProductSalesByCtg> prodList = new List<ProductSalesByCtg>();

            var productsByCat = (from prod in _pcontext.Productos
                                 where prod.IdCategoria == catg
                                 select new
                                 {
                                     ID = prod.IdProducto,
                                     IDC = prod.IdCategoria,
                                     Name = prod.NomProducto
                                 }).ToList();


            var ordersCA = (from oCA in _context.OrdenesCalifornia
                            join oD in _context.DetalleOrden
                            on oCA.IdOrden equals oD.IdOrden
                            where (oCA.FechaOrden >= iDate && oCA.FechaOrden < fDate)
                            select new
                            {
                                IDP = oD.IdProducto,
                                Price = oD.PrecioVenta
                            }).ToList();



            var productsNY = (from p in productsByCat
                              join o in ordersCA
                              on p.ID equals o.IDP
                              select new
                              {
                                  ID = p.ID,
                                  Name = p.Name,
                                  Price = o.Price
                              }).ToList();

            var products = productsNY.GroupBy(x => x.ID);

            foreach (var product in products)
            {
                ProductSalesByCtg p = new ProductSalesByCtg();
                p.pName = product.ElementAt(0).Name;
                p.salesSum = product.Sum(x => x.Price);
                prodList.Add(p);
            }

            return prodList;

        }

        private List<ProductSalesByCtg> GetTX(string id, string month, string year)
        {
            int catg = Int16.Parse(id);
            var dates = DateMaker(month, year);
            var iDate = DateTime.Parse(dates.ElementAt(0));
            var fDate = DateTime.Parse(dates.ElementAt(1));


            List<ProductSalesByCtg> prodList = new List<ProductSalesByCtg>();

            var productsByCat = (from prod in _pcontext.Productos
                                 where prod.IdCategoria == catg
                                 select new
                                 {
                                     ID = prod.IdProducto,
                                     IDC = prod.IdCategoria,
                                     Name = prod.NomProducto
                                 }).ToList();


            var ordersTX = (from oTX in _context.OrdenesTexas
                            join oD in _context.DetalleOrden
                            on oTX.IdOrden equals oD.IdOrden
                            where (oTX.FechaOrden >= iDate && oTX.FechaOrden < fDate)
                            select new
                            {
                                IDP = oD.IdProducto,
                                Price = oD.PrecioVenta
                            }).ToList();



            var productsNY = (from p in productsByCat
                              join o in ordersTX
                              on p.ID equals o.IDP
                              select new
                              {
                                  ID = p.ID,
                                  Name = p.Name,
                                  Price = o.Price
                              }).ToList();

            var products = productsNY.GroupBy(x => x.ID);

            foreach (var product in products)
            {
                ProductSalesByCtg p = new ProductSalesByCtg();
                p.pName = product.ElementAt(0).Name;
                p.salesSum = product.Sum(x => x.Price);
                prodList.Add(p);
            }

            return prodList;

        }

    }
}
