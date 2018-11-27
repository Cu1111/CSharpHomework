using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace program1
{
    [Serializable]
    public class OrderDetails
    {
        public Goods Goods { set; get; }
        public string Id { set; get; }
        public int Number { set; get; }
        public string GoodsName { set; get; }
        public double GoodsValue { set; get; }
        public OrderDetails(Goods Goods,int Number)
        {
            this.Goods = Goods;
            this.Number = Number;
            this.GoodsName = Goods.Name;
            this.GoodsValue = Goods.Value;
            this.Id = Guid.NewGuid().ToString();
        }
        public OrderDetails() { }

        public override string ToString()
        {
            return $"GOODS:{Goods.Name},NUMBERS:{Number}";
        }
        //后面没有用到
        public double DetailsMoney(OrderDetails details)
        {
            double Money = 0;
            Money = details.Number * details.Goods.Value;
            return Money;
        }

    }
}
