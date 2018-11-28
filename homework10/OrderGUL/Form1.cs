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

namespace OrderGUI
{
    public partial class Form1 : Form
    {
        OrderService orderService = new OrderService();
        public Form1()
        {
            InitializeComponent();
            orderBindingSource.DataSource = orderService.GetAllOrders();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            queryOrder();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form2 editForm = new Form2(null);
            editForm.ShowDialog();
            queryOrder();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (orderBindingSource.Current != null)
            {
                Form2 editForm = new Form2((Order)orderBindingSource.Current);
                editForm.ShowDialog();
                queryOrder();
            }
            else
            {
                MessageBox.Show("No Order is selected!");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (orderBindingSource.Current != null)
            {
                Order order = (Order)orderBindingSource.Current;
                orderService.RemoveOrder(order.Id);
                queryOrder();
            }
            else
            {
                MessageBox.Show("No Order is selected!");
            }
        }

        private void queryOrder()
        {
            switch (comboBox1.SelectedIndex)
            {

                case 1:
                    orderBindingSource.DataSource =
                      orderService.GetOrder(textBox1.Text);
                    break;
                case 2:
                    orderBindingSource.DataSource =
                      orderService.QueryByCustomerName(textBox1.Text);
                    break;
                case 3:
                    orderBindingSource.DataSource =
                      orderService.QueryByGoodsName(textBox1.Text);
                    break;
                default:
                    orderBindingSource.DataSource = orderService.GetAllOrders();
                    break;
            }
            orderBindingSource.ResetBindings(false);
            DetailsBindingSource.ResetBindings(false);
        }


    }
}

