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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderList.OrderService service = new OrderList.OrderService();
            uint i = Convert.ToUInt32(textBox1.Text);
            uint Id = Convert.ToUInt32(textBox3.Text);
            String name = textBox2.Text;
            OrderList.Customer customer = new OrderList.Customer(Id,name);
            service.UpdateCustomer(i,customer);
            DialogResult result = MessageBox.Show("订单修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
