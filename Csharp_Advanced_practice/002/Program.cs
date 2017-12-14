using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _002
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> turns = new List<int>();
            List<int> jumpSize = new List<int>();
            List<string> direction = new List<string>();
            string[] instruction = new string[3];

            int startPosition = int.Parse(Console.ReadLine());
            int[] arr = Console.ReadLine().Split(',').Select(m => int.Parse(m)).ToArray();
            int arrLen = arr.Length;
            string check = Console.ReadLine();

            if (check == "exit")
            {
                Console.WriteLine("Forward: 0");
                Console.WriteLine("Backwards: 0");
                return;
            }

            int startNum = arr[startPosition];

            int nJumps = 0;
            int jumpSi = 0;
            //int count = 0;

            int newCurrentPosition = 0;

            double sumF = 0;
            double sumB = 0;

            do
            {

                instruction = check.Split(' ').ToArray();

                nJumps = int.Parse(instruction[0]);
                jumpSi = int.Parse(instruction[2]);

                turns.Add(int.Parse(instruction[0]));
                jumpSize.Add(int.Parse(instruction[2]));
                direction.Add(instruction[1]);

                for (int i = 0; i < nJumps; i++) //start JUMPing
                {
                    if (instruction[1] == "forward")
                    {
                        if ((startPosition + jumpSi) > arrLen - 1) //0 + 7 > 5 - 1
                        {
                            newCurrentPosition = (jumpSi % arrLen + startPosition)%arrLen;
                            startPosition = newCurrentPosition;
                        }
                        else
                        {
                            newCurrentPosition = jumpSi + startPosition;
                            startPosition = newCurrentPosition;
                        }
                        sumF += arr[newCurrentPosition];
                    }
                    else
                    {
                        if ((startPosition - jumpSi) < 0) //0 + 7 > 5 - 1
                        {
                            newCurrentPosition = (arrLen - (Math.Abs(startPosition - jumpSi)) % arrLen)%arrLen; //!!!
                            startPosition = newCurrentPosition;
                        }
                        else
                        {
                            newCurrentPosition = startPosition - jumpSi;
                            startPosition = newCurrentPosition;
                        }
                        sumB += arr[newCurrentPosition];
                    }
                }
                check = Console.ReadLine();
            } while (check != "exit");

            Console.WriteLine("Forward: " + sumF);
            Console.WriteLine("Backwards: " + sumB);

        }
    }
}
