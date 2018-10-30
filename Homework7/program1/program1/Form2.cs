using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program1
{
    public partial class Form2 : Form
    {
        Form1 f1;
        public Form2(Form1 f1)
        {
            InitializeComponent();
            this.f1 = f1;
        }

        Order order = new Order();
        Goods[] goods =
        {
            new Goods(1, "apple", 2),
            new Goods(2, "banana", 3),
            new Goods(3, "pear", 4)
        };
        Goods good = new Goods();
        OrderDetails orderDetails = new OrderDetails();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void orderDetailsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            order.Id = Convert.ToInt32(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            order.Customer = textBox2.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = comboBox1.Text;
            var n = from x in goods where x.Name == a select x;
            foreach(var m in n)
            {
                good = goods[m.Id - 1];
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            orderDetails.Number = Convert.ToInt32(textBox3.Text);
            //如果将注释orderDetails放在这里的话会重复添加因为每change一下带一下这个函数
            //orderDetails.Goods = good;
            //order.AddDetails(orderDetails);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //这里可以添加判断订单编号是否已经存在

            orderDetails.Goods = good;
            order.AddDetails(orderDetails);
            f1.orders.Add(order);
            //this.Hide();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
