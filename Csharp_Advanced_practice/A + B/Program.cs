using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A___B
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[] sum = new double[n];

            for (int i = 0; i < n; i++)
            {
                int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                sum[i] = line[0] + line[1];    
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(sum[i]);
            }
            
        }

    }
}
