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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(graphics==null)
            {
                graphics = this.CreateGraphics();
            }
            else
            {
                graphics.Clear(BackColor);
            }
            Pen pencolor = new Pen(Color.Blue);
            switch(comboBox1.SelectedItem)
            {
                case "蓝色":
                    pencolor.Color = Color.Blue;
                    break;
                case "绿色":
                    pencolor.Color = Color.Green;
                    break;
                case "黑色":
                    pencolor.Color = Color.Black;
                    break;

            }
            //drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
            drawCayleyTree(Convert.ToInt32(n.Text), Convert.ToDouble(leng.Text), Convert.ToDouble(per1.Text), Convert.ToDouble(per2.Text), Convert.ToDouble(th1.Text) * Math.PI / 180, Convert.ToDouble(th2.Text) * Math.PI / 180, 400, 810, -Math.PI / 2, pencolor);
        }

        private Graphics graphics;
        //double th1 = 30 * Math.PI / 180;
        //double th2 = 20 * Math.PI / 180;
        //double per1 = 0.6;
        //double per2 = 0.7;

        void drawCayleyTree(int n,double leng,double per1,double per2,double th1,double th2,double x0,double y0,double th,Pen pen)
        {
            if(n==0)
            {
                return;
            }
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1, pen);

            drawCayleyTree(n - 1, per1 * leng, per1, per2, th1, th2, x1, y1, th + th1, pen);
            drawCayleyTree(n - 1, per2 * leng, per1, per2, th1, th2, x1, y1, th - th2, pen);
        }
        void drawLine(double x0,double y0,double x1,double y1, Pen pen)
        {
            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
        }










        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
