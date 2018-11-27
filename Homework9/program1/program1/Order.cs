using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace program1
{
    [Serializable]
    public class Order
    {
        private List<OrderDetails> details = new List<OrderDetails>();
        public List<OrderDetails> Details
        {
            set { }
            get => this.details;
        }
        public string Id { set; get; }
        public string Customer { set; get; }
        public long phoneNumber { set; get; }
        public Order() { }

        public Order (string Id,string Customer,long phoneNumber)
        {
            this.Id = Id;
            this.Customer = Customer;
            this.phoneNumber = phoneNumber;
            //this.TheId = Guid.NewGuid().ToString();
        }

        public Order(Order order)
        {
            this.Id = order.Id;
            this.Customer = order.Customer;
            this.phoneNumber = order.phoneNumber;
            this.details = order.details;//不能省略
        }

        public void AddDetails(OrderDetails orderDetail)
        {
            //内容相同的订单通过改变订单号（orderdetail）而改变！
            //if (this.Details.Contains(orderDetail))
            //{
            //    throw new Exception("这个订单已存在！");
            //}
            //else
            //{
                details.Add(orderDetail);
            //}
        }
        //已更改ORDERDETAILS的属性
        public void RemoveDetails(int orderdetailId)
        {
            //details.RemoveAll(d => d.Id == orderDetailId);
        }

        public static double MoneyOfOrder(Order order)
        {
            double Money = 0;
            foreach(OrderDetails details in order.Details)
            {
                Money += details.Number * details.Goods.Value;
            }
            return Money;
        }

        public override string ToString()
        {
            string result = "\n=========================================\n";
            result += $"orderid:{Id},customer:{Customer}";
            Details.ForEach(od => result += "\n\t" + od.ToString());
            result += "\n=========================================";
            return result;
        }
    }
}
