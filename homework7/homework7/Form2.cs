using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework7
{
    public partial class Form2 : Form
    {
        private static uint i = 1;
        public uint customerId { get; set; }
        public string customerName { get; set; }
        public string goodsName { get; set; }
        public uint goodsId { get; set; }
        public uint quantity { get; set; }
        public double price { get; set; }


        public Form2()
        {
            InitializeComponent();
            //绑定
            textBox1.DataBindings.Add("Text", this, "customerName");
            textBox2.DataBindings.Add("Text", this, "customerId");
            textBox3.DataBindings.Add("Text", this, "goodsName");
            textBox4.DataBindings.Add("Text", this, "goodsId");
            textBox5.DataBindings.Add("Text", this, "price");
            textBox6.DataBindings.Add("Text", this, "quantity");

        }


        private void button1_Click(object sender, EventArgs e)
        {
            OrderList.Order order = new OrderList.Order();
            OrderList.Goods good = new OrderList.Goods();
            OrderList.OrderDetail detail = new OrderList.OrderDetail();
            OrderList.Customer customer = new OrderList.Customer();
            customer.Name = customerName;
            customer.Id = customerId;
            good.Name = goodsName;
            good.Id = goodsId;
            good.Price = price;
            detail.Quantity = quantity;
            detail.Goods = good;
            order.AddDetails(detail);
            order.Customer = customer;
            order.Id = i;
            OrderList.OrderService service = new OrderList.OrderService();
            service.AddOrder(order);
            i++;
            DialogResult result = MessageBox.Show("订单添加成功","提示",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            
        }
    }
}
