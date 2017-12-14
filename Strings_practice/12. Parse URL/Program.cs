using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Parse_URL
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = Console.ReadLine();
            //string url = "http://telerikacademy.com/Courses/Courses/Details/212";

            string prot = "";
            string serv = "";
            string res = "";

            prot = url.Substring(0, url.IndexOf(':'));
            int servStart = url.IndexOf("//")+2;
            int servEnd = url.IndexOf('/', servStart) - 1;
            serv = url.Substring(servStart, servEnd - servStart+1);

            int resStart = servEnd + 1;
            res = url.Substring(resStart);

            Console.WriteLine("[protocol] = " + prot);
            Console.WriteLine("[server] = " + serv);
            Console.WriteLine("[resource] = " + res);

        }
    }
}
