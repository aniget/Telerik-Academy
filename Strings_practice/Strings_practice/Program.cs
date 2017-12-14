using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_length
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            
            //if (text.Length < 20)
            //{
            //    string textEnd = new string('*', 20 - text.Length);
            //    text += textEnd;
            //}

            StringBuilder sb = new StringBuilder(); //initialize the SB
            sb.Append(text);
            if (sb.Length < 20)
            {
                sb.Append('*', 20 - sb.Length);
            }


            Console.WriteLine(sb);
        }
    }
}
