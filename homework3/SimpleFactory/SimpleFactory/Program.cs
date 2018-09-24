using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{   
    public abstract class Shape
    {
        public abstract double Area();
    }

    public class Cricle : Shape
    {
        private double r;
        private double area;
        public Cricle(double r)
        {
            this.r = r;
        }
        public override double Area()
        {
            area = r * r * System.Math.PI;
            return area;
        }
    }

    public class Triangle : Shape
    {
        private double a, b, c;
        private double area;
        public Triangle(double a,double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override double Area()
        {
            double h = (a + b + c)/2;
            area = Math.Sqrt(h * (h - a) * (h - b) * (h - c));
            return area;
        }
    }

    public class Square : Shape
    {
        private double a;
        private double area;
        public Square(double a)
        {
            this.a = a;
        }
        public override double Area()
        {
            area = a * a;
            return area;
        }
    }

    public class Rectangle : Shape
    {
        private double width, height;
        private double area;
        public Rectangle(double width,double height)
        {
            this.width = width;
            this.height = height;
        }
        public override double Area()
        {
            area = width * height;
            return area;
        }
    }

    public class Factory
    {
        public static Shape Creat(string shape,double x,double y,double z)
        {
            Shape graph = null;
           if(shape == "Cricle")
            {
                graph = new Cricle(x);
            }
           else if(shape == "Triangle")
            {
                graph = new Triangle(x, y, z);
            }
           else if(shape == "Square")
            {
                graph = new Square(x);
            }
           else if(shape == "Rectangle")
            {
                graph = new Rectangle(x, y);
            }
            else
            {
                throw new Exception("参数错误");
            }
            return graph;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Shape shape;
            shape = Factory.Creat("Cricle", 2.0, 0.0, 0.0);
            Console.WriteLine("面积为："+ shape.Area());
            shape = Factory.Creat("Triangle",3.0,4.0,5.0);
            Console.WriteLine("面积为：" + shape.Area());
            shape = Factory.Creat("Square", 5.5, 0.0, 0.0);
            Console.WriteLine("面积为：" + shape.Area());
            shape = Factory.Creat("Rectangle", 6.0, 4.0, 0.0);
            Console.WriteLine("面积为：" + shape.Area());

        }
    }
}
