using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//90/100
namespace Task_3.Sneaky_the_Snake
{
    class Program
    {
        static int[] rowChange = { 1, -1, 0, 0 };
        static int[] colChange = { 0, 0, -1, 1 };

        static int Direction(char input)
        {
            switch (input)
            {
                case 's': return 0;
                case 'w': return 1;
                case 'a': return 2;
                case 'd': return 3;
                default: return -1;
            }
        }


        static void Main(string[] args)
        {
            //s - down
            //w - up
            //a - left
            //d - right

            int[] dimensions = Console.ReadLine().Split('x').Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            //int rows = 5;
            //int cols = 8;
            //char[] route = { 's', 'a', 'a', 's', 's', 'd', 'd', 'w', 'w', 'w' };

            char[,] matrix = new char[rows, cols];

            int enterCol = -1;

            for (int i = 0; i < rows; i++)
            {
                string line = Console.ReadLine().Trim();
                for (int j = 0; j < cols; j++)
                {
                    //get the entrance
                    if (i == 0 && enterCol == -1)
                    {
                        enterCol = line.IndexOf('e');
                    }
                    matrix[i, j] = line[j];
                }
            }

            char[] route = Console.ReadLine().Split(',').Select(m => char.Parse(m)).ToArray();

            int rowStart = 0;
            int colStart = enterCol;

            int sL = 3; //snake length
            int row = rowStart;
            int col = colStart;

            char result = ' ';
            int move = 1;

            for (move = 1; move <= route.Length; move++)
            {
                row += rowChange[Direction(route[move - 1])];
                col += colChange[Direction(route[move - 1])];
                if (col < 0) col = cols - 1;
                if (col > cols - 1) col = 0;
                if (row > rows - 1)
                {
                    if (SnakeLengthIsZero(move, ref sL, row, col)) break;
                    Console.WriteLine("Sneaky is going to be lost into the depths with length " + sL); break;
                }

                result = matrix[row, col];

                if (result == '-')
                    if (SnakeLengthIsZero(move, ref sL, row, col)) break;

                if (result == '%')
                {
                    if (SnakeLengthIsZero(move, ref sL, row, col)) break;
                    Console.WriteLine("Sneaky is going to hit a rock at [" + row + "," + col + "]"); break;
                }
                if (result == '@')
                {
                    if (SnakeLengthIsZero(move, ref sL, row, col)) break;
                    sL++;
                    matrix[row, col] = '-';
                }

                if (row == 0 && col == colStart) // Snake is out                
                {
                    if (SnakeLengthIsZero(move, ref sL, row, col)) break;
                    Console.WriteLine("Sneaky is going to get out with length " + sL); break;
                }

            }

            if (move > route.Length)
                Console.WriteLine("Sneaky is going to be stuck in the den at [" + row + "," + col + "]");


            //PrintMatrix(matrix);

        }

        private static bool SnakeLengthIsZero(int move, ref int sL, int row, int col)
        {
            if (move % 5 == 0)
            {
                sL--;
                if (sL <= 0) { Console.WriteLine("Sneaky is going to starve at [" + row + "," + col + "]"); return true; }
                else return false;
            }
            else return false;

        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
