using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderList
{

    class OrderService
    {
        List<Order> list;

        public OrderService()
        {
            this.list = new List<Order>();
        }

        public void Add(string orderNum, string orderName, string client) {
             list.Add(new OrderDetails(orderNum,orderName,client));
            
        }

        public void Delete(Order order) {
            if (list.Contains(order))
            {
                list.Remove(order);
            }
            else
            {
                throw new Exception("找不到删除订单");
            }
        }

        public void Modify(Order order, Order newOrder) {
            if (list.Contains(order))
            {
                list.Remove(order);
                list.Add(newOrder);
            } else
            {
                throw new Exception("找不到修改订单");
            }
        }

        public OrderDetails Find(int type, string data) {
            switch (type)
            {
                case 1:
                    foreach(OrderDetails detail in list) {
                        if (detail.OrderNum.Equals(data)){
                            return detail;
                        }
                    }
                    break;
                case 2:
                    foreach (OrderDetails detail in list)
                    {
                        if (detail.OrderName.Equals(data))
                        {
                            return detail;
                        }
                    }
                    break;
                case 3:
                    foreach (OrderDetails detail in list)
                    {
                        if (detail.Client.Equals(data))
                        {
                            return detail;
                        }
                    }
                    break;
                default:
                    throw new Exception("找不到查询订单");
            }
            throw new Exception("找不到查询订单");
        }
    }
}
