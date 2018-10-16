using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace program1
{
    class OrderService
    {
        private Dictionary<int, Order> orderDic;//用DICTIONARY可以方便根据ID对订单进行管理
        public OrderService()
        {
            orderDic = new Dictionary<int, Order>();
        }
        public void AddOrder(Order order)
        {
            if(orderDic.ContainsKey(order.Id))
            {
                throw new Exception("此订单已经存在！");
            }
            else
            {
                //orderDic.Add(order.Id, order);
                orderDic[order.Id] = order;
            }
        }
        public void RemoveOrder(int Id)
        {
            orderDic.Remove(Id);
        }
        //用LINQ语句按客户进行筛选
        public void SearchOrderByCustomer(Customer customer)
        {
            var aimOrder = from n in orderDic.Values where n.Customer == customer select n;
            foreach(var n in aimOrder)
            {
                Console.WriteLine(n.ToString());
            }
        }
        //按商品名称进行筛选
        public void SearchOrderByGoods(Goods goods)
        {
            //LINQ语句 注意equal和contain的区别
            //var aimOrder = from n in orderDic.Values where n.Details.Exists(a=>a.Goods.Equals(goods)) select n;
            List<Order> result = new List<Order>();
            foreach(Order order in orderDic.Values)
            {
                foreach(OrderDetails details in order.Details)
                {
                    if(details.Goods==goods)
                    {
                        result.Add(order);
                    }
                }
            }
            foreach(Order n in result)
            {
                Console.WriteLine(n.ToString());
            }
        }
        //对订单价格进行的筛选
        //把金额大于Money的进行筛选
        public void SearchOrderByMoney(int Money)
        {
            //LINQ语句
            //var aimOrder = from n in orderDic.Values where Order.MoneyOfOrder(n)>Money select n;
            List<Order> result = new List<Order>();
            foreach (Order order in orderDic.Values)
            {
                if(Order.MoneyOfOrder(order)>Money)
                {
                    result.Add(order);
                }
            }
            foreach (Order n in result)
            {
                Console.WriteLine(n.ToString());
            }
        }
    }
}
