using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _15.Replace_tags
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] splitterArr = { "<a href=\"", "</a>" };
            string[] newArr = input.Split(splitterArr, StringSplitOptions.None).ToArray();

            int count = Regex.Matches(input, "<a href=\"").Count;

            int p = 1;

            for (int i = 0; i < input.Length - 9; i++)
            {
                string substr = input.Substring(i, 9);
                if (substr == "<a href=\"")
                {
                    //text starts with tag
                    string[] parts = newArr[p].Split(new[] { "\">" }, StringSplitOptions.None).ToArray();
                    newArr[p] = '[' + parts[1] + ']' + '(' + parts[0] + ')';
                    p += 2;

                }
            }
            
            input = string.Join("", newArr);
            
            Console.WriteLine(input);


        }
    }
}
