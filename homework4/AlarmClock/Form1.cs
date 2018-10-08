using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmClock
{
    public partial class Form1 : Form
    {
        int settedHour, settedMinute;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime currTime = DateTime.Now;

            if (settedMinute - 1 < currTime.Minute)
            {
                setM.Text = (settedMinute + 60 - currTime.Minute).ToString();
            }
            else
            {
                setM.Text = (settedMinute - 1 - currTime.Minute).ToString();
            }
            setH.Text = (settedHour - currTime.Hour).ToString();
            setS.Text = (60 - currTime.Second).ToString();


            if (currTime.Hour == settedHour && currTime.Minute == settedMinute)
            {
                timer1.Enabled = false;
               
                MessageBox.Show("时间到了！！！");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            settedHour = Convert.ToInt32(textBox1.Text);
            settedMinute = Convert.ToInt32(textBox2.Text);
            timer1.Enabled = true;

        }
    }

        
}


