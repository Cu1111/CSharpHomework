using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace program1
{
    public partial class Form2 : Form
    {
        //为了实现两个表格数据互通
        Form1 f1;
        public Form2(Form1 f1)
        {
            InitializeComponent();
            this.f1 = f1;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void showForm5()
        {
            Form5 f5 = new Form5(this);
            f5.Show();
        }

        public Order order = new Order();
        public List<OrderDetails> orderDetails = new List<OrderDetails>();

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

        private void button1_Click(object sender, EventArgs e)
        {
            long NewPhoneNum;
            string NewCustomer;
            string pattern1 = "[0-9]{11}";
            string NewId = comboBox1.Text + comboBox2.Text + comboBox3.Text + textBox1.Text;
            if (Regex.IsMatch(NewId, pattern1)) { }
            else
            {
                MessageBox.Show("请输入正确格式订单号", "错误");
            }
            if(f1.orderService.GetAllOrders().Exists(b =>b.Id.Equals(order.Id)))
            {
                MessageBox.Show("此订单编号已存在！","错误");
            }
            else
            {
                if(textBox2.Text=="")
                {
                    MessageBox.Show("顾客名不允许为空！", "错误");
                }
                else
                {
                    if(Regex.IsMatch(textBox3.Text,pattern1))
                    {
                        NewCustomer = textBox2.Text;
                        NewPhoneNum = Convert.ToInt64(textBox3.Text);
                        order = new Order(NewId, NewCustomer, NewPhoneNum);
                        foreach(var m in orderDetails)
                        {
                            order.AddDetails(m);
                        }
                        f1.orderService.Add(order);
                        //f1.orders.Add(order);
                        //var orders1 = from n in f1.orders
                        //              orderby n.Id
                        //              select n;
                        f1.bindingSource1.DataSource = f1.orderService.GetAllOrders().OrderBy(x=>x.Id).ToList<Order>();//对主界面订单列表的刷新
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("请输入正确格式中国大陆电话号码！", "错误");
                    }
                }
            }
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            showForm5();
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
