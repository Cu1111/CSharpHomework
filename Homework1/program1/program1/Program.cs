using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            string d = "";
            Console.Write("请输入两个数:");
            s = Console.ReadLine();
            d = Console.ReadLine();
            int a = int.Parse(s);
            int b = int.Parse(d);
            int c = a * b;
            Console.WriteLine($"两数乘积为：{c}");
        }
    }
}
