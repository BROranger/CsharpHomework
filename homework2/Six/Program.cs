using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Six
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 10, 35, 37, 49, 7, 4, 6, 66, 89 };
            Console.WriteLine("其中的素数有：");
            int i = 0, p = 0;
            while( i< numbers.Length) {
                int temp = (int)Math.Sqrt(numbers[i]);
                for (int j = 2; j <= temp; j++)
                {
                    if (numbers[i] % j == 0)
                    {
                        p = 1;
                        break;
                    }
                } 
                if(p == 0)
                {
                    Console.WriteLine(numbers[i]);
                }
                p = 0;
                i++;
            }
        }
    }
}
