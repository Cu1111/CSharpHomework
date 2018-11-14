using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace program1
{
    public partial class Form1 : Form
    {
        public List<Order> orders = new List<Order>();
        public long KeyWord { get; set; }
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

            Goods apple = new Goods(1, "apple", 2);
            Goods banana = new Goods(2, "banana", 3);
            Goods pear = new Goods(3, "pear", 4);

            OrderDetails orderDetails1 = new OrderDetails( apple, 50);
            OrderDetails orderDetails2 = new OrderDetails(pear, 52);
            OrderDetails orderDetails3 = new OrderDetails( banana, 100);
            OrderDetails orderDetails4 = new OrderDetails( apple, 70);

            Order order1 = new Order(20180101001, "Jack",15230821523);
            Order order2 = new Order(20180101003, "rose",13072759305);
            Order order3 = new Order(20180101005, "Bob", 13090290111);

            order1.AddDetails(orderDetails1);
            order1.AddDetails(orderDetails2);
            order2.AddDetails(orderDetails3);
            order3.AddDetails(orderDetails2);

            orders.Add(order1);
            orders.Add(order2);
            orders.Add(order3);

            orders = orders.OrderBy(a => a.Id).ToList<Order>();

            bindingSource1.DataSource = orders;
            textBox1.DataBindings.Add("Text", this, "KeyWord");
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        public void ExportToXml(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xml.Serialize(fs, orders);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = orders.Where(s => s.Id == KeyWord);
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
        
        private void 修改此订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1 != null && dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex != -1)
            {
                showForm3();
            }
        }

        private void 导出为XMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if(result.Equals(DialogResult.OK))
            {
                string fileName = saveFileDialog1.FileName;
                ExportToXml(fileName);
            }
        }

        private void 导出为HTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = saveFileDialog2.ShowDialog();
                if (result.Equals(DialogResult.OK))
                {
                    ExportToXml("ForToHtml.xml");

                    XmlDocument doc = new XmlDocument();
                    doc.Load(@"D:\CSharpHomework1\Homework7\program1\program1\bin\Debug\ForToHtml.xml");

                    XPathNavigator nav = doc.CreateNavigator();
                    nav.MoveToRoot();

                    XslCompiledTransform xt = new XslCompiledTransform();
                    xt.Load(@"D:\CSharpHomework1\Homework7\program1\program1\bin\Debug\order.xslt");

                    FileStream outFileStream = File.OpenWrite(saveFileDialog2.FileName);
                    XmlTextWriter writer =
                        new XmlTextWriter(outFileStream, System.Text.Encoding.UTF8);
                    xt.Transform(nav, null, writer);

                    System.IO.File.Delete(@"D:\CSharpHomework1\Homework7\program1\program1\bin\Debug\ForToHtml.xml");
                }
            }
            catch (XmlException exception)
            {
                Console.WriteLine("XML Exception:" + exception.ToString());
            }
            catch (XsltException exception)
            {
                Console.WriteLine("XSLT Exception:" + exception.ToString());
            }
        }
    }
}
