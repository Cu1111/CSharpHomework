using System;
using System.Collections.Generic;
using System.Text;

namespace program1
{
    [Serializable]
    public class Goods
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public double Value { set; get; }
        public Goods(int Id, string Name, double Value)//此时value为单价
        {
            this.Id = Id;
            this.Name = Name;
            this.Value = Value;
        }
        public Goods() { }

        public override string ToString()
        {
            return $"GoodsId:{Id},GoodsName:{Name},GoodsValue{Value}";
        }
    }
}
