using System;
using System.Collections.Generic;
using System.Text;


namespace program1
{
    [Serializable]
    public class Order
    {
        public List<OrderDetails> Details = new List<OrderDetails>();
        public int Id { set; get; }
        public string Customer { set; get; }
        public Order() { }
        public Order (int Id,string Customer)
        {
            this.Id = Id;
            this.Customer = Customer;
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
                Details.Add(orderDetail);
            //}
        }
        public void RemoveDetails(int orderdetailId)
        {
           //etails.RemoveAll(d => d.Id == orderdetailId);
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
