using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s1 = "";
            s1 = textBox1.Text;
            int a = Int32.Parse(s1);
            string s2 = "";
            s2 = textBox2.Text;
            int b = Int32.Parse(s2);
            int c = a * b;
            textBox3.Text = a + "和" + b + "的积是： " + c;

        }
   
     
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
