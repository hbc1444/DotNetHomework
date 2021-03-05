using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请依次输入两个数：");
            double x = Convert.ToDouble(Console.ReadLine());
            double y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("请输入一个运算符(+-*/)：");
            char q = Convert.ToChar(Console.ReadLine());
            double z = 0;
            switch (q)
            {
                case '+':
                    z = x + y;
                    Console.WriteLine(x + "+" + y + "=" + z);
                    break;
                case '-':
                    z = x - y;
                    Console.WriteLine(x + "-" + y + "=" + z);
                    break;
                case '*':
                    z = x * y;
                    Console.WriteLine(x + "*" + y + "=" + z);
                    break;
                case '%':
                    z = x / y;
                    Console.WriteLine(x + "/" + y + "=" + z);
                    break;
            }
        }
    }
}