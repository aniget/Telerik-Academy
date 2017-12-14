using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Parse_tags
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int i = 0;

            StringBuilder sb = new StringBuilder(input);

            do
            {
                string check = input.Substring(i, "<upcase>".Length);
                if (string.Compare(check, "<upcase>", true) == 0) //0 - we have a match
                {
                    int positionStart = i + "<upcase>".Length;
                    int positionEnd = input.IndexOf("</upcase>", positionStart);

                    string oldtext = input.Substring(positionStart, positionEnd - positionStart);
                    string newtext = input.Substring(positionStart, positionEnd - positionStart).ToUpper();
                    if (positionEnd - positionStart>0)
                    {
                        sb.Replace(oldtext, newtext, positionStart, positionEnd - positionStart);
                    }
                    
                }
                i++;
            } while (i <= input.LastIndexOf("</upcase>"));

            sb = sb.Replace("<upcase>", "");
            sb = sb.Replace("</upcase>", "");

            Console.WriteLine(sb);

        }
    }
}
