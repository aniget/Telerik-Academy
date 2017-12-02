using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Correct_brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();
            char[] arr = Console.ReadLine().ToString().ToCharArray();
            int bra1 = 0;
            int bra2 = 0;

            //main approach is traversing the string like an array and applying the checks we have in order to validate the brackets placement
            //start with symbol 1 - it cna be any but ). Go further and count the no of ( and ), at the end it should be qual. 
            
            //check for this cases in groups: (), (-) or (+), etc. - THIS CASE APPEARS TO BE ACCEPTABLE ALTHOUGH IT IS INVALID BRACKET USAGE

            if (arr[0] == ')' || arr[arr.Length - 1] == '(')
            {
                Console.WriteLine("Incorrect");
                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                //if (i < arr.Length - 2 && (arr[i] + arr[i + 2] == '(' + ')' || (arr[i] + arr[i + 2] == '(' + '(' && arr[i+1] != '(') || (arr[i] + arr[i + 2] == ')' + ')' && arr[i + 1] != ')')))
                //{
                //    Console.WriteLine("Incorrect");
                //    return;
                //}
                //else
                    switch (arr[i])
                    {
                        case '(': bra1++; break;
                        case ')': bra2++; break;
                    }

            }

            if (bra1 == bra2) Console.WriteLine("Correct");
            else Console.WriteLine("Incorrect");

        }
    }
}
