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
    public partial class Form1 : Form
    {
        static public Dictionary<uint, OrderList.Order> orderDict = new Dictionary<uint, OrderList.Order>();
        
        public Form1()
        {
            InitializeComponent();
        }


    //创建订单
    private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            
            
        }
        //删除订单
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();

        }
        //修改订单
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }
        //查询订单
        private void button4_Click(object sender, EventArgs e)
        {
            OrderList.OrderService service = new OrderList.OrderService();
            if (comboBox1.Text == "按订单号查找")
            {
                uint i = Convert.ToUInt32(textBox2.Text);
                string j = "";
                foreach (OrderList.Order order in service.QueryByOrderId(i))
                {
                    j += order.ToString();
                }
                textBox1.Text = j;
            }
            else if (comboBox1.Text == "按货物名查找")
            {
                string i = textBox2.Text;
                string j = "";
                foreach (OrderList.Order order in service.QueryByGoodsName(i))
                {
                    j += order.ToString();
                }
                textBox1.Text = j;
                
               
            }
            else if (comboBox1.Text == "按客户名查找")
            {
                string i = textBox2.Text;
                string j = "";
                foreach (OrderList.Order order in service.QueryByCustomerName(i))
                {
                    j += order.ToString();
                }
                textBox1.Text = j;
                
            }
            else if (comboBox1.Text == "按货物价格查找")
            {
                double p = Convert.ToDouble(textBox2.Text);
                string j = "";
                foreach (OrderList.Order order in service.GetMyOrders(p))
                {
                    j += order.ToString();
                }
                textBox1.Text = j;
                
              
            }
            else
                service.QueryAllOrders();
        }

        private void button5_Click(object sender, EventArgs e)
        {
          
        }


    }
}
