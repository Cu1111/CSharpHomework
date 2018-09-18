using System;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("数组内容为1，2，3，4，5的混乱排序。输入0查看最大值，输入1查看最小值，输入2查看平均值，输入3查看和");
            int[] Array = { 3, 5, 1, 2, 4 };
            string s = Console.ReadLine();
            int a = int.Parse(s);
            int i = Array[0];
            switch (a)
            {
                case 0:
                    for(int j=0;j<5;j++)
                    {
                        if(i<=Array[j])
                        {
                            i = Array[j];
                        }
                    }
                    Console.WriteLine(i);
                    break;
                case 1:
                    for (int j = 0; j < 5; j++)
                    {
                        if (i >= Array[j])
                        {
                            i = Array[j];
                        }
                    }
                    Console.WriteLine(i);
                    break;
                case 2:
                    int m = 0;
                    for (int j = 0;j<5;j++)
                    {
                        m += Array[j];
                    }
                    Console.WriteLine(m / 5.0);
                    break;
                case 3:
                    int n = 0;
                    for (int j = 0; j < 5; j++)
                    {
                        n += Array[j];
                    }
                    Console.WriteLine(n);
                    break;
            }

        }
    }
}
