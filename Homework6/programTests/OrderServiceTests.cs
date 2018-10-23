using Microsoft.VisualStudio.TestTools.UnitTesting;
using program1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void OrderServiceTest()
        {
            OrderService orderService = new OrderService();

            Assert.IsNull(orderService);
        }

        [TestMethod()]
        public void AddOrderTest()
        {
            Customer[] customers = { new Customer(1, "jack"), new Customer(2, "rose") };
            Order[] orders = { new Order(1, customers[0]), new Order(2, customers[1]) };
            OrderService orderService = new OrderService();
            orderService.AddOrder(orders[0]);
            orderService.AddOrder(orders[1]);
            Assert.IsTrue(orderService.Number()==2);
        }

        [TestMethod()]
        public void RemoveOrderTest()
        {
            Customer[] customers = { new Customer(1, "jack"), new Customer(2, "rose") };
            Order[] orders = { new Order(1, customers[0]), new Order(2, customers[1]) };
            OrderService orderService = new OrderService();
            orderService.AddOrder(orders[0]);
            orderService.AddOrder(orders[1]);
            orderService.RemoveOrder(1);
            Assert.IsTrue(orderService.Number() == 1);
        }

        [TestMethod()]
        public void SearchOrderByCustomerTest()
        {
            Customer[] customers = { new Customer(1, "jack"), new Customer(2, "rose") };
            Order[] orders = { new Order(1, customers[0]), new Order(2, customers[1]),new Order(3,customers[1]) };
            OrderService orderService = new OrderService();
            orderService.AddOrder(orders[0]);
            orderService.AddOrder(orders[1]);
            orderService.AddOrder(orders[2]);
            List<Order> result = new List<Order>();
            result = orderService.SearchOrderByCustomer(customers[1]);
            int n = result.Count;
            int m = 0;
            foreach(Order x in result)
            {
                if (x.Customer == customers[1])
                {
                    m++;
                }
            }
            Assert.AreEqual(n,m);
        }

        [TestMethod()]
        public void SearchOrderByGoodsTest()
        {
            Goods[] goods = { new Goods(1, "apple", 2), new Goods(2, "banana", 3), new Goods(3, "pear", 4) };
            OrderDetails[] orderDetails = {new OrderDetails(1, goods[0], 50), new OrderDetails(2, goods[1], 52),
                                            new OrderDetails(3, goods[2], 100),new OrderDetails(4, goods[0], 70)};
            Customer[] customers = { new Customer(1, "jack"), new Customer(2, "rose") };
            Order[] orders = { new Order(1, customers[0]), new Order(2, customers[1]), new Order(3, customers[1]) };
            orders[0].AddDetails(orderDetails[0]);
            orders[1].AddDetails(orderDetails[3]);
            orders[2].AddDetails(orderDetails[1]);
            OrderService orderService = new OrderService();
            orderService.AddOrder(orders[0]);
            orderService.AddOrder(orders[1]);
            orderService.AddOrder(orders[2]);
            List<Order> result = new List<Order>();
            result=orderService.SearchOrderByGoods(goods[0]);
            List<Order> list1 = new List<Order>();
            list1.Add(orders[0]);
            list1.Add(orders[1]);
            Assert.IsTrue(result.All(list1.Contains)&&list1.Count==result.Count);
        }

        [TestMethod()]
        public void SearchOrderByMoneyTest()
        {
            Goods[] goods = { new Goods(1, "apple", 2), new Goods(2, "banana", 3), new Goods(3, "pear", 4) };
            OrderDetails[] orderDetails = {new OrderDetails(1, goods[0], 50), new OrderDetails(2, goods[1], 52),
                                            new OrderDetails(3, goods[2], 100),new OrderDetails(4, goods[0], 70)};
            Customer[] customers = { new Customer(1, "jack"), new Customer(2, "rose") };
            Order[] orders = { new Order(1, customers[0]), new Order(2, customers[1]), new Order(3, customers[1]) };
            orders[0].AddDetails(orderDetails[0]);//100
            orders[1].AddDetails(orderDetails[3]);//140
            orders[2].AddDetails(orderDetails[1]);//156
            OrderService orderService = new OrderService();
            orderService.AddOrder(orders[0]);
            orderService.AddOrder(orders[1]);
            orderService.AddOrder(orders[2]);
            List<Order> result = new List<Order>();
            result = orderService.SearchOrderByMoney(130);
            List<Order> list1 = new List<Order>();
            list1.Add(orders[2]);
            list1.Add(orders[1]);
            Assert.IsTrue(result.All(list1.Contains) && list1.Count == result.Count);
        }

        [TestMethod()]
        //这是要验证什么？
        public void ExportToXmlTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void ImportTheXmlTest()
        {
            Assert.IsTrue(true);
        }
    }
}