     using System;
using System.Collections.Generic;

namespace program2
{
    class OrderDetails
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Client { set; get; }
    }
    class Order
    {
        public List<OrderDetails> TheOrder;
        public Order()
        {
            TheOrder = new List<OrderDetails>();
        }

    }
    class OrderService
    {
        List<OrderDetails> TheOrder = new List<OrderDetails>();
        public static void AddOrder( List<OrderDetails> MyOrder,int ID, string Name, string Client)//增加订单
        {
            OrderDetails NewOrder = new OrderDetails();
            NewOrder.Client = Client;
            NewOrder.ID = ID;
            NewOrder.Name = Name;
            MyOrder.Add(NewOrder);
        }
        public static void DeleteOrder(List<OrderDetails> MyOrder, int ID)//删除
        {
            if(MyOrder.Find(s => s.ID== ID)==null)
            {
                throw new Exception("不存在此订单");
            }
            else
            {
                MyOrder.RemoveAt(ID);//继续思考
            }
        }
        public static void SearchOrder(List<OrderDetails> MyOrder, int ID)//查找
        {
            if (MyOrder.Find(s => s.ID == ID) == null)
            {
                throw new Exception("不存在此订单");
            }
            else
            {
                List<OrderDetails> TheSearch = MyOrder.FindAll(s => s.ID == ID);
                foreach(OrderDetails X in TheSearch)
                {
                    Console.WriteLine(X.ID + X.Name + X.Client);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Order MyOrder = new Order();
            int ID;
            String Name, Client;
            try
            {
                Console.WriteLine("1、2、3分别为添加删除和查询，请选择：");
                string A = Console.ReadLine();
                switch (A)
                {
                    case "1":
                        Console.WriteLine("请输入添加订单的编号：");
                        ID = int.Parse(Console.ReadLine());
                        Console.WriteLine("请输入添加订单的名称：");
                        Name = Console.ReadLine();
                        Console.WriteLine("请输入添加订单的客户名称：");
                        Client = Console.ReadLine();
                        OrderService.AddOrder(MyOrder.TheOrder, ID, Name, Client);
                        break;
                    case "2":
                        Console.WriteLine("请输入要删除的订单编号：");
                        ID = int.Parse(Console.ReadLine());
                        OrderService.DeleteOrder(MyOrder.TheOrder, ID);
                        break;
                    case "3":
                        Console.WriteLine("请输入要查看的订单编号：");
                        ID = int.Parse(Console.ReadLine());
                        OrderService.SearchOrder(MyOrder.TheOrder, ID);
                        break;
                    default:
                        Console.WriteLine("！未输入有效字符！");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("gg");
            }
        }
    }
}
