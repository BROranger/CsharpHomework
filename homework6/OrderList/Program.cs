﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderList
{
     public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Customer customer1 = new Customer(1, "Customer1");
                Customer customer2 = new Customer(2, "Customer2");

                Goods milk = new Goods(1, "Milk", 69.9);
                Goods eggs = new Goods(2, "eggs", 4.99);
                Goods apple = new Goods(3, "apple", 5.59);
                Goods car = new Goods(4, "car", 120000);

                OrderDetail orderDetails1 = new OrderDetail(1, apple, 8);
                OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
                OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);
                OrderDetail orderDetails4 = new OrderDetail(4, car, 10);

                Order order1 = new Order(1, customer1);
                Order order2 = new Order(2, customer2);
                Order order3 = new Order(3, customer2);
                order1.AddDetails(orderDetails1);
                order1.AddDetails(orderDetails2);
                order1.AddDetails(orderDetails3);
                order2.AddDetails(orderDetails2);
                order2.AddDetails(orderDetails3);
                order3.AddDetails(orderDetails3);
                order3.AddDetails(orderDetails4);

                
                OrderService os = new OrderService();
                os.AddOrder(order1);
                os.AddOrder(order2);
                os.AddOrder(order3);
                


                List<Order> orders = os.QueryAllOrders();
                
                //序列化成xml文件
                os.Export(orders);
                //反序列化
                List<Order> Orders =  os.Import(@"F:\MyList.xml");
                foreach (Order order in Orders)
                    Console.WriteLine(order.ToString());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
