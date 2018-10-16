using System;
using System.Collections.Generic;
using System.Text;

namespace program1
{
    class Customer
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public Customer(int Id,string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
        //右键自动生成的重写
        public override string ToString()
        {
            return $"CustomerId:{Id},CustomerNamr:{Name}";
        }
    }
}
