using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08.Extract_sentences
{
    class Program
    {
        static void Main()
        {
            string word = Console.ReadLine();
            string sentences = Console.ReadLine(); //"We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

            string[] arr = sentences.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string selected = "";
            bool hasSentence = false;
            //adding the dot to each sentence
            for (int j = 0; j < arr.Length; j++)
            {
                Match match = Regex.Match(arr[j], @"\b" + word + @"\b");
                if (match.Success)
                {
                    if (arr[j].Trim().Substring(arr[j].Trim().Length-1) != ".")
                    {
                        selected += arr[j].Trim() + ". ";
                        hasSentence = true;
                    }
                    else
                    {
                        selected += arr[j].Trim();
                        hasSentence = true;
                    }
                }
            }

            if (hasSentence)
            {
                   Console.WriteLine(selected.Trim());
            }
        }
    }
}
