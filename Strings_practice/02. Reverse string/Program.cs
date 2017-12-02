using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Reverse_string
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] arr = Console.ReadLine().ToCharArray();
            Array.Reverse(arr);
            //string revstr = new string(arr); // convert char array (or string array) to string 
            Console.WriteLine(new string(arr));
        }
    }
}
