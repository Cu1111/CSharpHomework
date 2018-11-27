using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace program1
{
    [Serializable]
    public class Goods
    {
        [Key]
        public string Id { set; get; }
        public int GoodNum { set; get; }
        public string Name { set; get; }
        public double Value { set; get; }
        public Goods(int GoodNum, string Name, double Value)//此时value为单价
        {
            this.GoodNum = GoodNum;
            this.Name = Name;
            this.Value = Value;
            this.Id = Guid.NewGuid().ToString();
        }
        public Goods() { }

        public override string ToString()
        {
            return $"GoodsName:{Name},GoodsValue{Value}";
        }
    }
}
