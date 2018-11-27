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
    public partial class Form5 : Form
    {
        Form2 f2;

        public Form5(Form2 f2)
        {
            InitializeComponent();
            this.f2 = f2;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        Goods[] goods =
       {
            new Goods(1, "apple", 2),
            new Goods(2, "banana", 3),
            new Goods(3, "pear", 4)
        };

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Goods good = new Goods();
            OrderDetails orderDetails = new OrderDetails();
            if(comboBox1.Text=="")
            {
                MessageBox.Show("请选择货物种类", "错误");
            }
            else
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("请输入货物数量", "错误");
                }
                else
                {
                    string a = comboBox1.Text;
                    var n = from x in goods where x.Name == a select x;
                    foreach (var m in n)
                    {
                        good = goods[m.GoodNum - 1];
                    }
                    int Number = Convert.ToInt32(textBox1.Text);
                    orderDetails = new OrderDetails(good, Number);
                    f2.orderDetails.Add(orderDetails);
                    //f2.order.AddDetails(orderDetails);
                    var b = from c in f2.orderDetails
                            select c;
                    orderDetailsBindingSource.DataSource = b;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var b = from c in f2.orderDetails
                    select c;
            f2.orderDetailsBindingSource.DataSource = b;
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                if (e.KeyChar == '.')
                {
                    if (((TextBox)sender).Text.LastIndexOf('.') != -1)
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
    }
}
