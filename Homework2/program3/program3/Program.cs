using System;

namespace program3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[99];
            for(int j =0; j<99;j++)
            {
                arr[j] = j + 2;
            }
            Console.Write("2~100内的质数有： 2 3 5 7 ");
            foreach(int i in arr)
            {
                if(i%2!=0&&i%3!=0&&i%5!=0&&i%7!=0)
                {
                    Console.Write(i+ " ");
                }
            }
        }
    }
}
