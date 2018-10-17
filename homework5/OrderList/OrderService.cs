using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderList
{
    class OrderService
    {
        
        private Dictionary<uint, Order> orderDict;
        /// <summary>
        /// OrderService constructor
        /// </summary>
        public OrderService()
        {
            orderDict = new Dictionary<uint, Order>();
        }

        public void AddOrder(Order order)
        {
            if (orderDict.ContainsKey(order.Id))
                throw new Exception($"order-{order.Id} is already existed!");
            orderDict[order.Id] = order;
        }

        public void RemoveOrder(uint orderId)
        {
            if (!orderDict.ContainsKey(orderId))
                throw new Exception($"order-{orderId} isn't existed!");
            orderDict.Remove(orderId);
        }

        public List<Order> QueryAllOrders()
        {
            return orderDict.Values.ToList();
        }

        public Order GetById(uint orderId)
        {
            return orderDict[orderId];
        }
        //按照货物名称查询
        public List<Order> QueryByGoodsName(string goodsName)
        {
            List<Order> result = new List<Order>();
            foreach (Order order in orderDict.Values)
            {
                var query = from i in order.Details
                            where (i.Goods.Name == goodsName)
                            select order;
                foreach(var n in query)
                {
                    result.Add(n);
                }
            }
            return result;
        }
        //按订单号查询
        public List<Order> QueryByOrderId(uint OrderId)
        {
            var query = orderDict.Values.Where(order => order.Id == OrderId );
            return query.ToList();
        }
        
        //按照客户名查询
        public List<Order> QueryByCustomerName(string customerName)
        {
            var query = orderDict.Values
                .Where(order => order.Customer.Name == customerName);
            return query.ToList();
        }

        //修改定单
        public void UpdateCustomer(uint orderId, Customer newCustomer)
        {
            if (orderDict.ContainsKey(orderId))
            {
                orderDict[orderId].Customer = newCustomer;
            }
            else
            {
                throw new Exception($"order-{orderId} is not existed!");
            }
        }
        //查询订单金额大于x万元的订单
        public List<Order> GetMyOrders(double x)
        {
            List<Order> results = new List<Order>();
            foreach(Order order in orderDict.Values)
            {
                var query = from item in order.Details where (item.Goods.Price > x) select order;
                foreach(var n in query)
                {
                    results.Add(n);
                }
            }
            return results;   
        }

    }
}