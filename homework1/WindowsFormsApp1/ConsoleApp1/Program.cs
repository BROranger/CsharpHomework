using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            String s;
            int a, b, c;
            System.Console.WriteLine("Please input two number :");
            s = Console.ReadLine();
            a = Int32.Parse(s);
            s = Console.ReadLine();
            b = Int32.Parse(s);
            c = a * b;
            Console.WriteLine("The result is " + c);
        }
    }
}
