using System;
using System.Collections.Generic;
using System.Text;

namespace program1
{
    class OrderDetails
    {
        public int Id { set; get; }
        public Goods Goods { set; get; }
        public int Number { set; get; }
        public OrderDetails(int Id,Goods Goods,int Number)
        {
            this.Id = Id;
            this.Goods = Goods;
            this.Number = Number;
        }

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
