using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();//建立图层
            graphics.Clear(Color.SeaShell);//每次点击时刷新图层
            drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
        }
        
        private Graphics graphics;
        //double th1 = 30 * Math.PI / 180;
        //double th2 = 20 * Math.PI / 180;
        //double per1 = 0.6;
        //double per2 = 0.7;
        void drawCayleyTree(int n, double x0, double y0,double leng,double th)
        {
            if(n==0)
            {
                return;
            }
            else
            {
                //其中一个分支
                double x1 = x0 + leng * Math.Cos(th);
                double y1 = y0 + leng * Math.Sin(th);
                //另一分支
                //如果是加x0一起改变的话容易出现起始点和终点位置交错
                double x2 = x0 + leng * Math.Cos(th)/3;
                double y2 = y0 + leng * Math.Sin(th)/3;
                //写到函数体内才能调用
                double th1 = Convert.ToSingle(textBox1.Text) * Math.PI / 180;
                double th2 = Convert.ToSingle(textBox2.Text) * Math.PI / 180;
                double per1 = Convert.ToSingle(textBox3.Text);
                double per2 = Convert.ToSingle(textBox4.Text);
                drawLine(x0, y0, x1, y1);

                drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
                drawCayleyTree(n - 1, x2, y2, per2 * leng, th - th2);
            }
        }

        private void drawLine(double x0, double y0,double x1,double y1)
        {
            Brush b = new SolidBrush(Color.Blue);
            Pen pen = new Pen(b,11);
            pen.Width = Convert.ToInt32(textBox5.Text);
            graphics.DrawLine(
                pen, (float)x0, (float)y0, (float)x1, (float)y1
            );
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
