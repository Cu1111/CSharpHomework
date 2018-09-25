using System;

namespace program1
{
    public abstract class Graph
    {
        public abstract string GraphShow();
    }
    class circle : Graph
    {
        public double r { set; get; }
        public override string GraphShow()
        {
            Console.WriteLine("面积为：" + 3.14 * r * r);
            return null;
        }
    }
    class triangle :Graph
    {
        public int a { set; get; }
        public int b { set; get; }
        public int c { set; get; }
        public override string GraphShow()
        {
            if(a>0&&b>0&&c>0&&a+b>c&&a+c>b&&c+b>a)
            {
                double p = (a + b + c) / 2;
                double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                Console.WriteLine("面积为:" + s);
            }
            else
            {
                Console.WriteLine("无法构成三角形！");
            }
            return null;
        }
    }
    class square : Graph
    {
        public double L { set; get; }
        public override string GraphShow()
        {
            Console.WriteLine("面积为：" +  L * L);
            return null;
        }
    }
    class rectangle :Graph
    {
        public double L { set; get; }
        public double K { set; get; }
        public override string GraphShow()
        {
            Console.WriteLine("面积为：" + L * K);
            return null;
        }
    }

        public class GraphFactory
        {
            public static Graph createGraph(string type)
            {
                Graph shape = null;
                switch (type)
                {
                case "圆":
                    Console.WriteLine("请输入半径：");
                    string s = Console.ReadLine();
                    double R = Double.Parse(s);
                    shape = new circle { r = R };
                    break;
                case "三角形":
                    Console.WriteLine("请输入三边（整形）：");
                    s = Console.ReadLine();
                    int a = int.Parse(s);
                    s = Console.ReadLine();
                    int b = int.Parse(s);
                    s = Console.ReadLine();
                    int c = int.Parse(s);
                    shape = new triangle { a=a,b=b,c=c };
                    break;
                case "正方形":
                    Console.WriteLine("请输入边长：");
                    s = Console.ReadLine();
                    double L = double.Parse(s);
                    shape = new square { L = L };
                    break;
                case "长方形":
                    Console.WriteLine("请输入两边长：");
                    s = Console.ReadLine();
                    L = double.Parse(s);
                    s = Console.ReadLine();
                    double K = double.Parse(s);
                    shape = new rectangle { L = L, K = K };
                    break;
            }
                return shape;
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("请输入：\"圆\"、\"正方形\"、\"三角形\"或者\"长方形\"。");
                string type = Console.ReadLine();
                Graph shape = GraphFactory.createGraph(type);
                Console.WriteLine(shape.GraphShow());
            }
        }
    }
