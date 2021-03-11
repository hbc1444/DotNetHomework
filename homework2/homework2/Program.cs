using System;
using System.Collections.Generic;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //第一题
            Console.WriteLine("请输入一个整数：");
            int number= Convert.ToInt32(Console.ReadLine());
            Func1(number);

            //第二题
            Func2();

            //第三题：
            Func3();

            int[,] array = { { 1, 2, 3, 4 }, { 5, 1, 2, 3 }, { 9, 5, 1, 2 } };
            if (Func4(array))
            {
                Console.WriteLine("该矩阵是托普利茨矩阵。");
            }
            else
            {
                Console.WriteLine("该矩阵不是托普利茨矩阵。");
            }
        }

        public static void Func1(int number)
        {
            int x = 2;
            while (number > x)
            {
                if (number % x == 0)
                {
                    Console.Write(x + "  ");
                    number /= x;
                }
                if (number % x != 0)
                {
                    x++; 
                }
            }
            Console.WriteLine(x);
        }
        public static void Func2()
        {
            int[] number = { 1, 2, 3 };
            int max = 0;
            int min = number[0];
            int sum = 0;
            foreach(int num in number)
            {
                if (num > max)
                {
                    max = num;
                }
                if (num < min)
                {
                    min = num;
                }
            }
            for(int i = 0; i < number.Length; i++)
            {
                sum += number[i];
            }
            Console.WriteLine(" " + max + " " + min + " " + sum);
        }
        public static void Func3()
        {
            List<int> list = new List<int>();
            for (int i = 2; i < 101; i++)
            {
                list.Add(i);
            }
            for(int x = 2; x < 100; x++)
            {
                for(int i=0;i<list.Count;i++)
                {
                    if (list[i] % x == 0 && list[i]!=x)
                    {
                        list.RemoveAt(i);
                    }
                }
            }
            for(int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i]+" ");
            }
            Console.WriteLine();
        }

        static bool Func4(int[,] array)
        {

            
            
            for(int i = 0; i < array.GetLength(0)-1; i++)
            {
                for(int j = 0; j < array.GetLength(1) - 1; j++)
                {
                    if(array[i+1,j+1]!=array[i,j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
