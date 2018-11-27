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
        public OrderService orderService = new OrderService();
        public string KeyWord { get; set; }
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
            Goods apple1 = new Goods(1, "apple", 2);

            OrderDetails orderDetails1 = new OrderDetails( apple, 50);
            OrderDetails orderDetails2 = new OrderDetails(pear, 52);
            OrderDetails orderDetails3 = new OrderDetails( banana, 100);
            OrderDetails orderDetails4 = new OrderDetails( apple1, 70);

            Order order1 = new Order("20180101001", "Jack",15230821523);
            Order order2 = new Order("20180101003", "rose",13072759305);
            Order order3 = new Order("20180101005", "Bob", 13090290111);

            order1.AddDetails(orderDetails1);
            order1.AddDetails(orderDetails2);
            order2.AddDetails(orderDetails3);
            order3.AddDetails(orderDetails4);

            orderService.Add(order1);
            orderService.Add(order2);
            orderService.Add(order3);

            bindingSource1.DataSource = orderService.GetAllOrders().OrderBy(a=>a.Id).ToList<Order>();
            textBox1.DataBindings.Add("Text", this, "KeyWord");
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        public void ExportToXml(string fileName)
        {
            List<Order> orders = orderService.GetAllOrders().OrderBy(a => a.Id).ToList<Order>();
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xml.Serialize(fs, orders);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = orderService.GetAllOrders().Where(s => s.Id == KeyWord);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1 != null && dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex != -1)
            {
                if(MessageBox.Show("确定删除此订单？", "确定窗口", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string SelectId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    orderService.Delete(SelectId);
                    bindingSource1.DataSource = orderService.GetAllOrders();
                }
            }
        }

        private void 查看全部订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = orderService.GetAllOrders().OrderBy(a => a.Id).ToList<Order>();
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
                    doc.Load(@"ForToHtml.xml");

                    XPathNavigator nav = doc.CreateNavigator();
                    nav.MoveToRoot();

                    XslCompiledTransform xt = new XslCompiledTransform();
                    xt.Load(@"../debug/order.xslt");

                    FileStream outFileStream = File.OpenWrite(saveFileDialog2.FileName);
                    XmlTextWriter writer =
                        new XmlTextWriter(outFileStream, System.Text.Encoding.UTF8);
                    xt.Transform(nav, null, writer);

                    System.IO.File.Delete(@"../debug/ForToHtml.xml");
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
