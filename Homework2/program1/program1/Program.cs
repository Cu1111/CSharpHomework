using System;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个想要进行质因数分解的数字：");
            string s = Console.ReadLine();
            int a = int.Parse(s);
            if(1==a)
            {
                Console.WriteLine("1不存在质数因子");
            }
            else
            {
                Console.Write("它的质因子：");
                for(int i =2;i<=a;i++)
                {
                    if(a%i==0)
                    {
                        a = a / i;
                        Console.Write(i+"  ");
                        i = 1;
                    }
                }
            }
        }
    }
}
