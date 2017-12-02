using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Bishop_Path_Finder
{
    class Program
    {

        static int[] rowChange = { -1, -1, 1, 1 };
        static int[] colChange = { -1, 1, 1, -1 };

        static int Direction(string input)
        {

            switch (input)
            {
                case "UL": return 0;
                case "LU": return 0;
                case "UR": return 1;
                case "RU": return 1;
                case "DR": return 2;
                case "RD": return 2;
                case "DL": return 3;
                case "LD": return 3;
                default: return -1;
            }
        }


        static void Main()
        {
            int[] dim = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = dim[0];
            int cols = dim[1];

            //initial position
            int currentRow = rows - 1;
            int currentCol = 0;
            int[,] matrix = new int[rows, cols];

            matrix[currentRow, currentCol] = 0;

            int counter = 0;
            //construct the board
            for (int row = rows - 1; row >= 0; row--)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = counter * 3 + col * 3;
                }
                counter++;
            }

            int repeat = 0;
            int sum = 0;
            int moves = int.Parse(Console.ReadLine());

            int rowB = 0;
            int colB = 0;


            for (int i = 0; i < moves; i++) //DIRECTIONS loop
            {
                string[] move = Console.ReadLine().Split(' ').Select(x => x).ToArray();
                int rowMove = rowChange[Direction(move[0])];
                int colMove = colChange[Direction(move[0])];
                repeat = int.Parse(move[1]);

                //Console.WriteLine(currentRow + " " + currentCol + " " + repeat);

                //go BISHOP go
                rowB = currentRow;
                colB = currentCol;

                for (int j = 0; j < repeat; j++) //execute the moves per DIRECTION
                {
                    if (rowB >= 0 && rowB <= rows - 1 && colB >= 0 && colB <= cols - 1)
                    {
                        sum += matrix[rowB, colB];
                        matrix[rowB, colB] = 0;

                        //used to define position when jump to new Direction
                        currentRow = rowB;
                        currentCol = colB;

                        rowB += rowMove;
                        colB += colMove;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            //PrintMatrix(matrix); //used for debugging
            Console.WriteLine(sum);
        }



        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == matrix.GetLength(1) - 1)
                    {
                        Console.Write(matrix[i, j].ToString().PadLeft(3)); //PadLeft
                    }
                    else
                    {
                        Console.Write(matrix[i, j].ToString().PadLeft(3) + " "); //PadLeft
                    }
                }
                Console.WriteLine();
            }
        }



    }
}
