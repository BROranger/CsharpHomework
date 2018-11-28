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

namespace homework7
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderService service = new OrderService();
            string i =  textBox1.Text;
            string Id = textBox3.Text;
            String name = textBox2.Text;
            Customer customer = new Customer(Id,name);
            service.UpdateCustomer(i,customer);
            DialogResult result = MessageBox.Show("订单修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
