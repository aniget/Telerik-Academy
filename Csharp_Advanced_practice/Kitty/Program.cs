using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitty
{
    class Program
    {
        static void Main(string[] args)
        {
            string sfd = Console.ReadLine();
            string path = Console.ReadLine();

            //string sfd = "@*@*x";
            //string path = "-1 1 -1 -1 4";


            //ZeroTest 1
            //string sfd = "@@@xx@*";
            //string path = "1 -1 -1 4";

            //ZeroTest 2
            //string sfd = "x@*@*@*";
            //string path = "2 -1 2 -1";

            //ZeroTest 3
            //string sfd = "@*@*@*xxx";
            //string path = "1 -1 1 -1 2 1 1 1 1 1 1";


            char soul = '@';
            char food = '*';
            char deadlock = 'x';

            int sumS = 0;
            int sumF = 0;
            int sumD = 0;
            int sumM = 0;

            bool dead = false;

            char[] sfdArr = sfd.ToCharArray();
            int[] pathArr = path.Split(' ').Select(int.Parse).ToArray();

            //int lengthOfPath = 0;
            //foreach (var item in pathArr) lengthOfPath += Math.Abs(item);

            int position = 0;


            if (sfdArr[0] != deadlock)
            {
                if (sfdArr[position] == soul) { sumS++; sfdArr[position] = '0'; }
                if (sfdArr[position] == food) { sumF++; sfdArr[position] = '0'; }

                //Loop through moves
                for (int move = 0; move < pathArr.Length; move++)
                {
                    sumM++;
                    //solve the position issue
                    position += pathArr[move];
                    if (position >= 0) position = position % sfdArr.Length;
                    else position = sfdArr.Length - Math.Abs(position % sfdArr.Length);

                    if (sfdArr[position] == soul) { sumS++; sfdArr[position] = '0'; }
                    if (sfdArr[position] == food) { sumF++; sfdArr[position] = '0'; }
                    if (sfdArr[position] == deadlock)
                    {
                        if (position % 2 == 0 && sumS > 0) //leave SOUL
                        {
                            sumS--;
                            sumD++;
                            sfdArr[position] = soul;
                        }
                        else if (position % 2 == 0 && sumS == 0)
                        {
                            dead = true;
                            break;
                        }
                        else if (position % 2 == 1 && sumF > 0)
                        {
                            sumF--;
                            sumD++;
                            sfdArr[position] = food;
                        }
                        else if (position % 2 == 1 && sumF == 0)
                        {
                            dead = true;
                            break;
                        }
                    }
                }
            }
            else //deadlocked from the start
            {
                dead = true;
            }
            if (dead == true)
            {
                Console.WriteLine("You are deadlocked, you greedy kitty!");
                Console.WriteLine("Jumps before deadlock: " + sumM);
            }
            else
            {
                Console.WriteLine("Coder souls collected: " + sumS);
                Console.WriteLine("Food collected: " + sumF);
                Console.WriteLine("Deadlocks: " + sumD);
            }
        }
    }
}
