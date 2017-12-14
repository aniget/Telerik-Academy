using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23.Series_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            //string input = "aaaaabbbbbcdddeeeedssaa";
            char[] charArr = input.ToCharArray();

            List<char> newArr = new List<char>();
            newArr.Add(charArr[0]);

            for (int i = 1; i < charArr.Length; i++)
            {
                if (charArr[i] != charArr[i-1])
                {
                    newArr.Add(charArr[i]);
                }
            }
            string output = string.Join("", newArr);
            Console.WriteLine(output);

        }
    }
}
