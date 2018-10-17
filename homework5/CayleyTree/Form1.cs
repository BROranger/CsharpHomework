using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTree
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(10, 200, 310, 10,100, -Math.PI / 2,1.2);
        }
        private Graphics graphics;
        double th1;
        double th2;
        double per1;
        double per2;

        void drawCayleyTree(int n, double x0,double y0,double a, double leng,double th,double k)
        {
            if (n == 0) return;

            double Xb = x0 - a * Math.Cos(th);
            double Yb = y0 + a * Math.Sin(th);
            double x1 = Xb + leng * Math.Cos(th);
            double y1 = Yb + leng * Math.Sin(th);
            double Xa = x0 + a * Math.Cos(th);
            double Ya = y0 + a * Math.Sin(th);
            double x2 = Xa + leng * Math.Cos(th) * k;
            double y2 = Ya + leng * Math.Sin(th) * k;

            drawLine(Xb, Yb, x1, y1);
            drawLine(Xa, Ya, x2, y2);

            drawCayleyTree(n - 1, x1, y1,a * per1, per1 * leng, th + th1,1.2);
            drawCayleyTree(n - 1, x2, y2, a * per2, per2 * leng, th - th2,1.2);

        }
        void drawLine(double x0,double y0, double x1,double y1)
        {
            if (comboBox1.Text == "red")
                graphics.DrawLine(Pens.Red, (int)x0, (int)y0, (int)x1, (int)y1);
            else if (comboBox1.Text == "green")
                graphics.DrawLine(Pens.Green, (int)x0, (int)y0, (int)x1, (int)y1);
            else if (comboBox1.Text == "blue")
                graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
            else if (comboBox1.Text == "black")
                graphics.DrawLine(Pens.Black, (int)x0, (int)y0, (int)x1, (int)y1);
            else
                throw new Exception("can't find the right color!");
        }

        private  void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
            th1 = Convert.ToDouble(label2.Text) * Math.PI / 180;  
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label4.Text = trackBar2.Value.ToString();
            th2 = Convert.ToDouble(label4.Text) * Math.PI / 180;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            per1 = Convert.ToDouble(textBox1.Text);

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            per2 = Convert.ToDouble(textBox2.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
