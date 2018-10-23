using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;

namespace OrderList
{
    public class OrderService
    {

        public Dictionary<uint, Order> orderDict;
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

            var query = orderDict.Values.Where(order => order.Details.Where(d => d.Goods.Name == goodsName).Count()>0);
            return query.ToList();
        }

        //按订单号查询
        public List<Order> QueryByOrderId(uint OrderId)
        {
            var query = orderDict.Values.Where(order => order.Id == OrderId);
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
            var query = orderDict.Values.Where(order => order.Details.Where(d => d.Goods.Price > x).Count() >0);
            return query.ToList();
        }

        //XML序列化
        public void Export(List<Order> MyList)
        {
            FileStream fs = new FileStream(@"F:\MyList.xml", FileMode.Create);

            XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
            xmlser.Serialize(fs, MyList);
            fs.Close();
        }
        //xml反序列化
        public List<Order> Import(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
            List<Order> result = xmlser.Deserialize(fs) as List<Order>;
            return result;
        }
        


    }
}
