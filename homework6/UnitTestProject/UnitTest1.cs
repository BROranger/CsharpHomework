using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;


namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        static OrderList.Customer customer1 = new OrderList.Customer(1, "Customer1");
        static OrderList.Customer customer2 = new OrderList.Customer(2, "Customer2");

        static OrderList.Goods milk = new OrderList.Goods(1, "Milk", 69.9);
        static OrderList.Goods eggs = new OrderList.Goods(2, "eggs", 4.99);
        static OrderList.Goods apple = new OrderList.Goods(3, "apple", 5.59);
        static OrderList.Goods car = new OrderList.Goods(4, "car", 120000);

        static OrderList.OrderDetail orderDetails1 = new OrderList.OrderDetail(1, apple, 8);
        static OrderList.OrderDetail orderDetails2 = new OrderList.OrderDetail(2, eggs, 2);
        static OrderList.OrderDetail orderDetails3 = new OrderList.OrderDetail(3, milk, 1);
        static OrderList.OrderDetail orderDetails4 = new OrderList.OrderDetail(4, car, 10);

        OrderList.Order order1 = new OrderList.Order(1, customer1);
        OrderList.Order order2 = new OrderList.Order(2, customer2);
        OrderList.Order order3 = new OrderList.Order(3, customer2);

        OrderList.OrderService orderService = new OrderList.OrderService();

        [TestMethod]
        public void TestAddOrder()
        {
            orderService.AddOrder(order1);
            Assert.IsTrue(orderService.orderDict.ContainsValue(order1));

        }
        [TestMethod]
        public void TestRemoveOrder()
        {

            orderService.orderDict.Add(1,order1);
            orderService.RemoveOrder(1);
            Assert.IsFalse(orderService.orderDict.ContainsValue(order1));
        }

        [TestMethod]
        public void TestQueryByGoodsName()
        {
            order1.AddDetails(orderDetails1);
            order2.AddDetails(orderDetails2);
            orderService.orderDict.Add(1, order1);
            orderService.orderDict.Add(2, order2);
            Assert.IsTrue(orderService.QueryByGoodsName("apple").Contains(order1));
        }

        [TestMethod]
        public void TestGetMyOrders()
        {
            order3.AddDetails(orderDetails3);
            order3.AddDetails(orderDetails4);
            orderService.orderDict.Add(1, order1);
            orderService.orderDict.Add(2, order2);
            orderService.orderDict.Add(3, order3);
            Assert.IsTrue(orderService.GetMyOrders(1000).Contains(order3));
        }

        [TestMethod]
        public void TestExport()
        {
            List<OrderList.Order> orders = new List<OrderList.Order>() { order1, order2, order3 };
            orderService.Export(orders);
            DirectoryInfo directory = new DirectoryInfo(@"F:\");
            Assert.IsTrue(directory.Exists);

        }

        [TestMethod]
        public void TestImport1()
        {
            Assert.AreEqual(orderService.Import(@"F:\MyList.xml").Count,3);
        }
        [TestMethod]
        public void TestImport2()
        {
            Assert.AreEqual(orderService.Import(@"F:\MyList.xml").Count, 1);
        }
    }
}
