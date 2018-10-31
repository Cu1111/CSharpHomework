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
            if(textBox1.Text=="")
            {
                MessageBox.Show("请输入订单号", "错误");
            }
            else
            {
                order.Id = Convert.ToInt32(textBox1.Text);
            }
            if(f1.orders.Exists(a =>a.Id.Equals(order.Id)))
            {
                MessageBox.Show("此订单编号已存在！","错误");
            }
            else
            {
                if(textBox2.Text=="")
                {
                    MessageBox.Show("请输入顾客名", "错误");
                }
                else
                {
                    order.Customer = textBox2.Text;
                    f1.orders.Add(order);
                    var orders1 = from n in f1.orders
                                  orderby n.Id
                                  select n;
                    f1.bindingSource1.DataSource = orders1;//对主界面订单列表的刷新
                    this.Close();
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
    }
}
