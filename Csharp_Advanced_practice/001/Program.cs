using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _001
{
    class Program
    {
        static void Main(string[] args)
        {
            bool minus = false;

            string num = Console.ReadLine();
            if (num.Substring(0, 1) == "-")
            {
                num = num.TrimStart('-');
                minus = true;
            }
            int[] inputReverse = new int[num.Length];

            double[] result = new double[num.Length];

            int index = 0;

            for (int i = num.Length - 1; i >= 0; i--)
            {
                inputReverse[index] = int.Parse(num[i].ToString());
                if (index % 2 == 0)
                {
                    result[index] = inputReverse[index] * (index + 1) * (index + 1);
                    index++;
                }
                else
                {
                    result[index] = inputReverse[index] * inputReverse[index] * (index + 1);
                    index++;
                }
            }

            BigInteger sum = BigInteger.Parse(result.Sum().ToString());

            string sumString = sum.ToString();


            char[] abc = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            int lastDigit = int.Parse(sumString.Substring(sumString.Length - 1)); //6
            int msgStart = int.Parse((sum % 26).ToString()); //22

            StringBuilder msg = new StringBuilder();

            if (lastDigit == 0)
            {
                Console.WriteLine(sumString);
                Console.WriteLine("Big Vik wins again!");
                return;
            }
            else
            {
                for (int i = 1; i <= lastDigit; i++)
                {
                    if (msgStart < 26)
                    {
                        msg.Append(abc[msgStart]);
                        msgStart++;

                    }
                    else
                    {
                        msgStart = 0;
                        msg.Append(abc[msgStart]);
                        msgStart++;

                    }
                }

            }

            Console.WriteLine(sum);
            Console.WriteLine(string.Join("", msg.ToString()));



        }
    }
}
