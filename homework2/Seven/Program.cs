using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seven
{
    class Program
    {
        static void Main(string[] args)
        {
            //求最大值
            int SearchTheMax(int[] array)
            {
                int max = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (max < array[i])
                    {
                        max = array[i];
                    }
                }
                return max;
            }
            //求最小值
            int SearchTheMin(int[] array)
            {
                int min = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (min > array[i])
                    {
                        min = array[i];
                    }
                }
                return min;
            }
            //求总和
            int Sum(int[] array)
            {
                int sum = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    sum += array[i];
                }
                return sum;
            }
            //求平均值
            double Average(int[] array)
            {
                double average = Sum(array) / (array.Length);
                return average;
            }

            int[] numbers = { 45, 68, 7, 1, 22, 3, 49 };
            Console.WriteLine("最大值是：" + SearchTheMax(numbers));
            Console.WriteLine("最小值是：" + SearchTheMin(numbers));
            Console.WriteLine("总和是：" + Sum(numbers));
            Console.WriteLine("平均值是：" + Average(numbers));
        }
    }
}
