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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderList.OrderService service = new OrderList.OrderService();
            uint i = Convert.ToUInt32(textBox1.Text);
            service.RemoveOrder(i);
            DialogResult result = MessageBox.Show("订单删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
