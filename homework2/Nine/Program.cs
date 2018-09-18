using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nine
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] NatureArry = new int [99];
            for(int i = 2; i <= 100; i++)
            {
                NatureArry[i - 2] = i;
            }
            int a = 2;
            while (a <= 100)
            {
                for (int j = 0; j <NatureArry.Length;j++)
                {
                    if (NatureArry[j]!=1 && (NatureArry[j]/a >1) && NatureArry[j] % a == 0)
                    {
                       NatureArry[j] = 1;
                    }
                }
                a++;
            }
            for (int k = 0;k<NatureArry.Length;k++)
            if(NatureArry[k] != 1)
                {
                    Console.WriteLine(NatureArry[k]);
                }
          
        }
    }
}
