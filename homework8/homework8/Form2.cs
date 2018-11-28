using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderList;
using System.Text.RegularExpressions;
namespace homework7
{
    public partial class Form2 : Form
    {
        
        public string PhoneNumber { get; set; }
        public string customerName { get; set; }
        public string goodsName { get; set; }
        public string orderId { get; set; }
        public uint quantity { get; set; }
        public double price { get; set; }
        

        public Form2()
        {
            InitializeComponent();
            //绑定
            textBox1.DataBindings.Add("Text", this, "customerName");
            textBox2.DataBindings.Add("Text", this, "PhoneNumber");
            textBox3.DataBindings.Add("Text", this, "goodsName");
            textBox4.DataBindings.Add("Text", this, "orderId");
            textBox5.DataBindings.Add("Text", this, "price");
            textBox6.DataBindings.Add("Text", this, "quantity");

        }

        string patten1 = "^20[0-9]{2}-(01|03|05|07|08|10|12)-([0][1-9]|[1][1-9]|[2][1-9]|[3][01])-[0-9]{3}$";
        string patten2 = "^20[0-9]{2}-(02)-([0][1-9]|[1][1-9]|[2][1-9])-[0-9]{3}$";
        string patten3 = "^20[0-9]{2}-(04|06|09|11)-([0][1-9]|[1][1-9]|[2][1-9]|[3]0)-[0-9]{3}$";
        string pattrn4 = "^1[0-9]{10}$";

        private void button1_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            Customer customer = new Customer();
            Goods good = new Goods();
            OrderDetail detail = new OrderDetail();
            customer.Name = customerName;
            customer.PhoneNumber = PhoneNumber;
            good.Name = goodsName;
            order.Id = orderId;
            good.Price = price;
            detail.Quantity = quantity;
            detail.Goods = good;
            order.AddDetails(detail);
            order.Customer = customer;
            OrderService service = new OrderService();
            if ((Regex.IsMatch(order.Id, patten1) || Regex.IsMatch(order.Id, patten2) || Regex.IsMatch(order.Id, patten3))&& Regex.IsMatch(customer.PhoneNumber, pattrn4))
                service.AddOrder(order);
            else throw new Exception("Input the worry orderId");
            DialogResult result = MessageBox.Show("订单添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
    }
}