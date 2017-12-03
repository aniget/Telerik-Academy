using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Unicode_characters
{
    class Program
    {
        static void Main(string[] args)
        {
            //string value = Console.ReadLine(); ;
            string value = "Hi!";

            int[] arr = value.ToCharArray().Select(m=>(int)m).ToArray();
            
            var result = string.Concat(arr);
            Console.WriteLine(result);

        }
    }
}
