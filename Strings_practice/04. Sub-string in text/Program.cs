using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.Sub_string_in_text
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();
            //int count = Regex.Matches(Regex.Escape(text.ToLower()), pattern.ToLower()).Count; //Q: why this is not a correct solution ()only 40 of 100)?

            //Longer Solution - with substring and do/while loop
            int count = 0;
            int i = 0;
            int l_text = text.Length;
            do
            {
                string check = text.Substring(i, pattern.Length);
                if (string.Compare(check, pattern, true) == 0) //0 - we have a match
                {
                    count++;
                }
                i++;
            } while (i <= l_text - pattern.Length);


            Console.WriteLine(count);


        }
    }
}
