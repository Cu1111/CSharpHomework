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
    public partial class Form4 : Form
    {
        Form3 f3;
        Goods[] goods =
        {
            new Goods(1, "apple", 2),
            new Goods(2, "banana", 3),
            new Goods(3, "pear", 4)
        };

        public Form4(Form3 f3)
        {
            InitializeComponent();
            this.f3 = f3;
            this.StartPosition = FormStartPosition.CenterScreen;
            orderDetailsBindingSource.DataSource = f3.order.Details;
        }

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Goods good = new Goods();
            OrderDetails orderDetails = new OrderDetails();
            if (comboBox1.Text == "")
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
                    f3.orderDetails.Add(orderDetails);
                    var b = from c in f3.orderDetails
                            select c;
                    orderDetailsBindingSource.DataSource = b;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var b = from c in f3.orderDetails
                    select c;
            f3.orderDetailsBindingSource.DataSource = b;
            this.Close();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1 != null && dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex != -1)
            {
                if (MessageBox.Show("确定删除此订单详情？", "确定窗口", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    f3.orderDetails.Remove((OrderDetails)orderDetailsBindingSource.Current);
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                }
            }
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
