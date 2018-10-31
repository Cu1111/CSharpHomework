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
    public partial class Form1 : Form
    {
        public List<Order> orders = new List<Order>();
        //public BindingList<Order> orderss = new BindingList<Order>(orders);
        public int KeyWord { get; set; }
        //为了实现两个表格的数据互通
        public void showForm2()
        {
            Form2 f2 = new Form2(this);
            f2.Show();
        }

        public void showForm3()
        {
            Form3 f3 = new Form3(this);
            f3.Show();
        }

        public Form1()
        {
            InitializeComponent();//初始化控件
            //Customer customer1 = new Customer(1, "Jack");
            //Customer customer2 = new Customer(2, "rose");
            //Customer customer3 = new Customer(3, "Bob");

            Goods apple = new Goods(1, "apple", 2);
            Goods banana = new Goods(2, "banana", 3);
            Goods pear = new Goods(3, "pear", 4);

            OrderDetails orderDetails1 = new OrderDetails( apple, 50);
            OrderDetails orderDetails2 = new OrderDetails(pear, 52);
            OrderDetails orderDetails3 = new OrderDetails( banana, 100);
            OrderDetails orderDetails4 = new OrderDetails( apple, 70);

            Order order1 = new Order(1, "Jack");
            Order order2 = new Order(10, "rose");
            Order order3 = new Order(3, "Bob");

            order1.AddDetails(orderDetails1);
            order1.AddDetails(orderDetails2);
            order2.AddDetails(orderDetails3);
            order3.AddDetails(orderDetails4);

            orders.Add(order1);
            orders.Add(order2);
            orders.Add(order3);

            orders = orders.OrderBy(a => a.Id).ToList<Order>();

            bindingSource1.DataSource = orders;
            textBox1.DataBindings.Add("Text", this, "KeyWord");
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = orders.Where(s => s.Id == KeyWord);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridView1 != null && dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex != -1)
            //{
            //    List<OrderDetails> orderDetails = new List<OrderDetails>();
            //    BindingList<OrderDetails> orderDetailss = new BindingList<OrderDetails>(orderDetails);
            //    if (dataGridView1.CurrentRow.Cells[0].Value != null)
            //    {
            //        var a = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //        int b = Convert.ToInt32(a);
            //        var selectedOrder = from n in orders where n.Id == b select n;//var
            //        foreach (var n in selectedOrder)
            //        {
            //            foreach (var m in n.Details)
            //            {
            //                orderDetails.Add(m);
            //            }
            //        }
            //        bindingSource2.DataSource = orderDetailss;
            //    }
            //    else
            //    {
            //        List<OrderDetails> orderDetails1 = new List<OrderDetails>();
            //        bindingSource2.DataSource = orderDetails1;
            //    }
            //}
        }

        private void 订单_Click(object sender, EventArgs e)
        {

        }

        private void orderbindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void 查找订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1 != null && dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex != -1)
            {
                if(MessageBox.Show("确定删除此订单？", "确定窗口", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                }
                
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void 查看明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1 != null && dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex != -1)
            {
                //Form2 form = new Form2();
                //form.ShowDialog();
                //Form detials = new Form();
                //detials.Show();
                //DataGridView dataGridView2 = new DataGridView();
                List<OrderDetails> orderDetails = new List<OrderDetails>();
                //var c = dataGridView1.SelectedRows.
                if (dataGridView1.CurrentRow.Cells[0].Value != null)
                {
                    var a = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    int b = Convert.ToInt32(a);
                    var selectedOrder = from n in orders where n.Id == b select n;//var
                    foreach (var n in selectedOrder)
                    {
                        foreach (var m in n.Details)
                        {
                            orderDetails.Add(m);
                        }
                    }
                    bindingSource2.DataSource = orderDetails;
                }
                else
                {
                    List<OrderDetails> orderDetails1 = new List<OrderDetails>();
                    bindingSource2.DataSource = orderDetails1;
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void 查看全部订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //BindingList<Order> orderss = new BindingList<Order>(orders);
            var orders1 = from n in orders
                          orderby n.Id
                          select n;
            bindingSource1.DataSource = orders1;
        }

        private void 添加订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm2();
        }
        
        private void 刷新订单详情ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1 != null && dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex != -1)
            {
                List<OrderDetails> orderDetails = new List<OrderDetails>();
                if(dataGridView1.CurrentRow.Cells[0].Value != null)
                {
                    var a = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    int b = Convert.ToInt32(a);
                    var selectedOrder = from n in orders where n.Id == b select n;//var
                    foreach (var n in selectedOrder)
                    {
                        foreach (var m in n.Details)
                        {
                            orderDetails.Add(m);
                        }
                    }
                    bindingSource2.DataSource = orderDetails;
                }
                else
                {
                    List<OrderDetails> orderDetails1 = new List<OrderDetails>();
                    bindingSource2.DataSource = orderDetails1;
                }

            }
            else
            {
                List<OrderDetails> orderDetails = new List<OrderDetails>();
                bindingSource2.DataSource = orderDetails;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void 修改此订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1 != null && dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex != -1)
            {
                showForm3();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
