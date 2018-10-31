﻿using System;
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
    public partial class Form3 : Form
    {
        
        public Order order = new Order();
        Form1 f1;
        uint id;
        public Form3(Form1 f1)
        {
            InitializeComponent();
            this.f1 = f1;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.order = GetOrder();
            id = Convert.ToUInt32(f1.dataGridView1.CurrentRow.Cells[0].Value.ToString());
            orderBindingSource.DataSource = order;
            orderDetailsBindingSource.DataSource = order.Details;
        }
        
        public void showForm4()
        {
            Form4 f4 = new Form4(this);
            f4.Show();
        }

        public Order GetOrder()
        {

            Order order = new Order();
            var n = from x in f1.orders
                    where x.Id == Convert.ToUInt32(f1.dataGridView1.CurrentRow.Cells[0].Value.ToString())
                    select x;
            foreach(var m in n)
            {
                order = m;
            }
            return order;
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
            if(textBox1.Text=="")
            {
                MessageBox.Show("订单编号不能为空！", "错误");
            }
            else
            {
                if (textBox2.Text=="")
                {
                    MessageBox.Show("客户姓名不能为空！", "错误");
                }
                else
                {
                    if (f1.orders.Exists(a => a.Id.Equals(order.Id)))
                    {
                        if (order.Id == Convert.ToInt32(textBox1.Text))
                        {
                            order.Id = Convert.ToInt32(textBox1.Text);
                            order.Customer = textBox2.Text;
                            var orders1 = from n in f1.orders
                                          orderby n.Id
                                          select n;
                            f1.bindingSource1.DataSource = orders1;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("此订单编号已存在！", "错误");
                        }
                    }
                    else
                    {
                        order.Id = Convert.ToInt32(textBox1.Text);
                        order.Customer = textBox2.Text;
                        var orders1 = from n in f1.orders
                                      orderby n.Id
                                      select n;
                        f1.bindingSource1.DataSource = orders1;
                        this.Close();
                    }
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
