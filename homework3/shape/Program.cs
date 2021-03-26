using System;


namespace shape
{
    class Program
    {
        static void Main(string[] args)
        {
            double total = 0;
            ShapeFactory factory_Shape;
            try
            {
                for (int i = 1; i < 11; i++)
                {
                    Random rd = new Random();
                    int num = rd.Next(1, 4);
                    Factory factory = new Factory();
                    if (num == 1)
                    {
                        Console.WriteLine("第" + i + "个图形是长方形，");
                        factory_Shape = factory.GetFactoryShape(ShapeType.Rectangle);
                        Rectangle rectangle = (Rectangle)factory_Shape;
                        Console.WriteLine("请输入长方形的长和宽:");
                        string number1 = Console.ReadLine();
                        string number2 = Console.ReadLine();
                        rectangle.Width = Int32.Parse(number1);
                        rectangle.Length = Int32.Parse(number2);
                        Console.WriteLine("长方形的面积:" + rectangle.getArea());
                        total += rectangle.getArea();
                    }
                    else if (num == 2)
                    {
                        Console.WriteLine("第" + i + "个图形是三角形，");
                        factory_Shape = factory.GetFactoryShape(ShapeType.Triangle);
                        Triangle triangle = (Triangle)factory_Shape;
                        Console.WriteLine("请输入三角形的三条边:");
                        string number1 = Console.ReadLine();
                        string number2 = Console.ReadLine();
                        string number3 = Console.ReadLine();
                        triangle.Side1 = Int32.Parse(number1);
                        triangle.Side2 = Int32.Parse(number2);
                        triangle.Side3 = Int32.Parse(number3);
                        Console.WriteLine("三角形的面积:" + triangle.getArea());
                        total += triangle.getArea();
                    }
                    else if (num == 3)
                    {
                        Console.WriteLine("第" + i + "个图形是正方形，");
                        factory_Shape = factory.GetFactoryShape(ShapeType.Square);
                        Square square = (Square)factory_Shape;
                        Console.WriteLine("请输入正方形的边长:");
                        string number = Console.ReadLine();
                        square.Side = Int32.Parse(number);
                        Console.WriteLine("正方形面积:" + square.getArea());
                        total += square.getArea();
                    }
                }
                Console.WriteLine("总的面积为:" + total);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
    public interface Shape
    {
        void isLegal();
    }

    public interface ShapeFactory
    {
        void getShape();
    }

    public enum ShapeType
    {
        Rectangle = 1,
        Triangle = 2,
        Square = 3
    }

    public class Rectangle : Shape, ShapeFactory
    {
        private int width;
        private int length;
        public int Width { get => width; set => width = value; }
        public int Length { get => length; set => length = value; }
        public Rectangle()
        {

        }
        public Rectangle(int width, int length)
        {
            this.Width = width;
            this.Length = length;
        }

        public void isLegal()
        {
            if (Length > 0 && Width > 0 && Width != Length)
            {
                Console.WriteLine("这是一个长方形.");
            }
            else if (Length > 0 && Width > 0 && Width == Length)
            {
                Console.WriteLine("这是一个正方形.");
            }
        }

        public int getArea()
        {
            return width * length;
        }

        public void getShape()
        {
            Console.WriteLine("成功调用一个长方形.");
        }
    }

    public class Triangle : Shape, ShapeFactory
    {
        private int side1;
        private int side2;
        private int side3;
        public int Side1 { get => side1; set => side1 = value; }
        public int Side2 { get => side2; set => side2 = value; }
        public int Side3 { get => side3; set => side3 = value; }
        public Triangle()
        {

        }
        public Triangle(int a, int b, int c)
        {
            side1 = a;
            side2 = b;
            side3 = c;
        }

        public void isLegal()
        {
            if (Side1 > 0 && Side2 > 0 && Side3 > 0 && (Side1 + Side2) > Side3 && (Side1 + Side3) > Side2 && (Side2 + Side3) > Side1)
            {
                Console.WriteLine("这是一个三角形.");
            }
            else
            {
                Console.WriteLine("三角形不合法.");
            }
        }

        public double getArea()
        {
            double p = (side1 + side2 + side3) / 2;
            return System.Math.Sqrt(p * ( p - side3) * ( p - side2) * ( p - side3));
        }

        public void getShape()
        {
            Console.WriteLine("成功调用一个三角形.");
        }
    }

    public class Square : Shape, ShapeFactory
    {
        private int side;
        public int Side { get => side; set => side = value; }
        public Square()
        {

        }
        public Square(int side)
        {
            this.Side = side;
        }
        public void isLegal()
        {
            if (Side > 0)
            {
                Console.WriteLine("这个正方形合法.");
            }
        }
        public int getArea()
        {
            return Side * Side;
        }

        public void getShape()
        {
            Console.WriteLine("成功调用一个正方形.");
        }
    }

    public class Factory
    {
        public ShapeFactory GetFactoryShape(ShapeType shapeType)
        {
            switch (shapeType)
            {
                case ShapeType.Rectangle:
                    return new Rectangle();
                case ShapeType.Triangle:
                    return new Triangle();
                case ShapeType.Square:
                    return new Square();
                default:
                    throw new Exception("没有这种图形.");
            }
        }
    }
}