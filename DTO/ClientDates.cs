using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bikes.DTO
{
    public class ClientDates
    {
        public DateTime dateS;

        public DateTime dateE;

        public int idClient;

        public int totalOrders;

        public List<OrderDet> orders;
    }
}
