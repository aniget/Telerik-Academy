using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task_4.GoshoCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int wL = word.Length;
            int lines = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder("");
            for (int i = 1; i <= lines; i++)
                text.Append(Console.ReadLine() + " ");


            //string[] sentences = text.ToString().Split(new char[] { '.', '!' });
            string[] sentences = Regex.Split(text.ToString(), @"(?<=[.!])");

            //string sub = "about who its friends are";
            string sub = "";

            for (int i = 0; i < sentences.Length; i++)
            {
                if (sentences[i].IndexOf(word) > 0) {
                    if (sentences[i].Contains("."))
                    {
                        sub = sentences[i].Substring(sentences[i].IndexOf(word)+wL).TrimEnd('.');
                    }
                    else
                    {
                        sub = sentences[i].Substring(0,sentences[i].IndexOf(word));
                    }

                }
            }
            
            Console.WriteLine(Convert2Ascii(sub, wL));

        }

        private static double Convert2Ascii(string sub, int wL)
        {
            int[] subArr = new int[sub.Length];
            //char test = 't';
            //Console.WriteLine((int)test);
            //subArr = sub.ToCharArray().Select(m => (int)m).ToArray();
            subArr = sub.ToCharArray().Select(m => (int)m).Where(p => p != 32).ToArray();
            double sum = subArr.Sum() * wL;
            return sum;
        }

    }
}
