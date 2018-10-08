using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderList
{


    class Program
    {
        static void Main(string[] args)
        {
            OrderService service = new OrderService();
            service.Add("123", "pizza", "Make");
            service.Add("124", "shoes", "Alien");
            service.Add("145", "shirt", "Leo");
            OrderDetails order1 = service.Find(1, "124");
            service.Delete(order1);
            service.Find(1, "12");//报错，找不到订单
    
        }
    }
}
