using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Customer customer1 = new Customer(1, "Jack");
                Customer customer2 = new Customer(2, "rose");
                Customer customer3 = new Customer(3, "Bob");
                Goods apple = new Goods(1, "apple", 2);
                Goods banana = new Goods(2, "banana", 3);
                Goods pear = new Goods(3, "pear", 4);
                OrderDetails orderDetails1 = new OrderDetails(1, apple, 50);
                OrderDetails orderDetails2 = new OrderDetails(2, pear, 52);
                OrderDetails orderDetails3 = new OrderDetails(3, banana, 100);
                OrderDetails orderDetails4 = new OrderDetails(4, apple, 70);
                Order order1 = new Order(1, customer1);
                Order order2 = new Order(2, customer2);
                Order order3 = new Order(3, customer3);

                order1.AddDetails(orderDetails1);
                //order1.AddDetails(orderDetails1);
                order1.AddDetails(orderDetails2);
                order2.AddDetails(orderDetails3);
                order3.AddDetails(orderDetails4);
                //Console.WriteLine(order1.ToString());
                //order1.RemoveDetails(1);
                //Console.WriteLine(order1.ToString());

                OrderService orderService = new OrderService();
                orderService.AddOrder(order1);
                //orderService.AddOrder(order1);
                orderService.AddOrder(order2);
                orderService.AddOrder(order3);
                //orderService.SearchOrderByCustomer(customer1);
                //orderService.SearchOrderByCustomer(customer2);

                //orderService.SearchOrderByGoods(apple);
                //orderService.SearchOrderByMoney(299);
                orderService.ExportToXml();
                orderService.ImportTheXml();
    


            }
            catch(Exception e)//try和catch必须匹配！
            {
                Console.WriteLine(e.Message);//把错误信息输出~
            }
            
        }


    }
}
