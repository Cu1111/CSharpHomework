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
    public partial class Form3 : Form
    {
        public Order order = new Order();
        public List<OrderDetails> orderDetails = new List<OrderDetails>();
        Form1 f1;
        string selectId;
        public Form3(Form1 f1)
        {
            InitializeComponent();
            this.f1 = f1;
            this.StartPosition = FormStartPosition.CenterScreen;
            string TheId = f1.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.order = f1.orderService.GetOrder(TheId);
            foreach(var a in order.Details)
            {
                orderDetails.Add(a);
            }
            selectId = order.Id;
            orderBindingSource.DataSource =order;
            orderDetailsBindingSource.DataSource = orderDetails;
        }
        
        public void showForm4()
        {
            Form4 f4 = new Form4(this);
            f4.Show();
        }
        
        public Form3()
        {
            InitializeComponent();
        }
        
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void orderBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            long NewPhoneNum;
            string NewId, NewCustomer;
            string pattern1 = "[0-9]{4}(0[1-9]|11|12)([012][1-9]|30|31)[0-9]{3}";
            string pattern2 = "[0-9]{11}";
            if(textBox1.Text=="")
            {
                MessageBox.Show("订单编号不能为空！", "错误");
            }
            else
            {
                if(Regex.IsMatch(textBox1.Text,pattern1))
                {
                    if (textBox2.Text=="")
                    {
                        MessageBox.Show("客户姓名不能为空！", "错误");
                    }
                    else
                    {
                        if(Regex.IsMatch(textBox3.Text,pattern2))
                        {
                            string thisId = textBox1.Text;
                            if (f1.orderService.GetAllOrders().Exists(a => a.Id.Equals(thisId)))
                            {
                                if (selectId == thisId)
                                {
                                    NewId = textBox1.Text ;
                                    NewPhoneNum = Convert.ToInt64(textBox3.Text);
                                    NewCustomer = textBox2.Text;
                                    order = new Order(textBox1.Text, NewCustomer, NewPhoneNum);
                                    f1.orderService.Delete(selectId.ToString());
                                    foreach(var a in orderDetails)
                                    {
                                        order.AddDetails(a);
                                    }
                                    f1.orderService.Add(order);
                                    f1.bindingSource1.DataSource = f1.orderService.GetAllOrders().OrderBy(a => a.Id).ToList<Order>();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("此订单编号已存在！", "错误");
                                }
                            }
                            else
                            {
                                NewId = textBox1.Text;
                                NewPhoneNum = Convert.ToInt64(textBox3.Text);
                                NewCustomer = textBox2.Text;
                                order = new Order(textBox1.Text, NewCustomer, NewPhoneNum);
                                f1.orderService.Delete(selectId.ToString());
                                foreach (var a in orderDetails)
                                {
                                    order.AddDetails(a);
                                }
                                f1.orderService.Add(order);
                                f1.bindingSource1.DataSource = f1.orderService.GetAllOrders().OrderBy(a => a.Id).ToList<Order>();
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("请输入正确格式中国大陆电话号码！", "错误");
                        }
                        
                    }
                }
                else
                {
                    MessageBox.Show("请输入正确的订单号！", "错误");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showForm4();
        }

        private void orderDetailsBindingSource_CurrentChanged(object sender, EventArgs e)
        {

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
