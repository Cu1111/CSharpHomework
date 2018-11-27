using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace program1
{
    public class OrderService
    {
        public void Add(Order order)
        {
            using (var db = new orderDB())
            {
                db.Order.Add(order);
                db.SaveChanges();
            }
        }

        public void Delete(String orderId)
        {
            using (var db = new orderDB())
            {
                var order = db.Order.Include("Details").SingleOrDefault(o => o.Id.ToString() == orderId);
                db.OrderDetails.RemoveRange(order.Details);
                db.Order.Remove(order);
                db.SaveChanges();
            }
        }

        public void Update(Order order)
        {
            using (var db = new orderDB())
            {
                db.Order.Attach(order);
                db.Entry(order).State = EntityState.Modified;
                order.Details.ForEach(
                    Details => db.Entry(Details).State = EntityState.Modified);
                db.SaveChanges();
            }
        }

        public Order GetOrder(String Id)
        {
            using (var db = new orderDB())
            {
                return db.Order.Include("Details").
                  SingleOrDefault(o => o.Id.ToString() == Id);
            }
        }

        public List<Order> GetAllOrders()
        {
            using (var db = new orderDB())
            {
                return db.Order.Include("Details").ToList<Order>();
            }
        }

    }
}
