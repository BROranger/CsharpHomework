using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderList
{
    class OrderDetails : Order
    {
        public OrderDetails(string orderNum, string orderName, string client) 
        {
            OrderName = orderName;
            Client = client;
            OrderNum = orderNum;
        }

    }
}
