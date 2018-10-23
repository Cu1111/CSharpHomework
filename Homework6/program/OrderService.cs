﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace program1
{
    public class OrderService
    {
        //private List<Order> orders = new List<Order>();
        public Dictionary<int, Order> orderDic;//用DICTIONARY可以方便根据ID对订单进行管理
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
        public int Number()
        {
            int n=0;
            foreach(Order x in orderDic.Values)
            {
                n++;
            }
            return n;
        }
        //用LINQ语句按客户进行筛选
        public List<Order> SearchOrderByCustomer(Customer customer)
        {
            List<Order> result = new List<Order>();
            var aimOrder = from n in orderDic.Values where n.Customer == customer select n;
            foreach(var n in aimOrder)
            {
                result.Add(n);
                Console.WriteLine(n.ToString());
            }
            return result;
        }
        //按商品名称进行筛选
        public List<Order> SearchOrderByGoods(Goods goods)
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
            return result;
        }
        //对订单价格进行的筛选
        //把金额大于Money的进行筛选
        public List<Order> SearchOrderByMoney(int Money)
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
            return result;
        }
        //注意每一个用到的都得加上无参的构造函数
        public void ExportToXml()
        {
            List<Order> result = new List<Order>();
            foreach (Order n in orderDic.Values)
            {
                result.Add(n);
            }
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("fs.xml", FileMode.Create))
            {
                xml.Serialize(fs, result);
            }
        }
        public void ImportTheXml()
        {
            List<Order> result = new List<Order>();
            foreach (Order n in orderDic.Values)
            {
                result.Add(n);
            }
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("fs.xml", FileMode.Open))
            {
                List<Order> result2 = (List<Order>)xml.Deserialize(fs);
                foreach(Order n in result2)
                {
                    Console.WriteLine(n.ToString());
                }
            }
        }
    }
}
