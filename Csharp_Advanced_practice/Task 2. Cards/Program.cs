using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            n = int.Parse(Console.ReadLine());
            string[] hands = new string[n];

            string[] cards = { "2c", "3c", "4c", "5c", "6c", "7c", "8c", "9c", "Tc", "Jc", "Qc", "Kc", "Ac", "2d", "3d", "4d", "5d", "6d", "7d", "8d", "9d", "Td", "Jd", "Qd", "Kd", "Ad", "2h", "3h", "4h", "5h", "6h", "7h", "8h", "9h", "Th", "Jh", "Qh", "Kh", "Ah", "2s", "3s", "4s", "5s", "6s", "7s", "8s", "9s", "Ts", "Js", "Qs", "Ks", "As" };
            List<int> allCardsInHand = new List<int>();

            for (int i = 0; i < n; i++) //loop through the HANDS
            {
                string hand = Convert.ToString(long.Parse(Console.ReadLine()), 2);
                hands[i] = hand;
                char[] bitHand = hand.ToCharArray(); //1 or 0
                int countCardsInHand = bitHand.Count(m => m == '1');
                int[] cardsInHand = new int[countCardsInHand];
                int cardCount = 0;

                for (int j = hands[i].Length - 1; j >= 0; j--) //loop through the BITs to find each card in the hand
                {
                    if (bitHand[j] == '1')
                    {
                        cardsInHand[cardCount] = hands[i].Length - j - 1;
                        allCardsInHand.Add(hands[i].Length - j - 1);
                        cardCount++;
                    }
                }
            }

            allCardsInHand.Sort();

            //work on All Cards in Hand

            string fullDeck = "Full deck";
            StringBuilder cardsOdd = new StringBuilder();

            for (var p = 0; p < 52; p++)
            {
                if (!allCardsInHand.Contains(p))
                    fullDeck = "Wa wa!";
                else //count the number of cards
                    if (allCardsInHand.Count(m => m == p) % 2 == 1) cardsOdd.Append(cards[p] + " ");
            }

            cardsOdd.ToString().Trim();
            Console.WriteLine(fullDeck);
            Console.WriteLine(cardsOdd);



            //using (var reader = new StreamReader("../../input.txt"))
            //{
            //    //Console.WriteLine(reader.ReadLine()); // More methods: reader.ReadToEnd();
            //    n = int.Parse(reader.ReadLine());

            //    for (int i = 0; i < n; i++)
            //    {
            //        long num = long.Parse(reader.ReadLine());
            //        string binary = Convert.ToString(num, 2);
            //BELOW LINE GIVES ERROR HERE - VERY STRANGE
            //        hands[i] = binary; 
            //    }
            //}



        }
    }
}
