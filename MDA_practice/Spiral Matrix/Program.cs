using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiral_Matrix
{
    class Program
    {
        // 1 2 3 4 5
        // 12 13 14 15 6
        // 11 10 9 8 7
        
        static void Main(string[] args)
        {
            //Console Read
            int n = int.Parse(Console.ReadLine().ToString());
            int rows = n;
            int cols = n + 2;
            int[,] matrix = new int[rows, cols];
            //Starting Position
            int rowStart = 0; //the position of the starting row
            int colStart = 0; //the position of the starting column
            
            //First Element
            matrix[rowStart, colStart] = 1;
            int counter = 1;
            int turns = 0; //number of turns

            //Fill Spiral Matrix
            FillSpiralMatrix(matrix, counter, rowStart, colStart, turns, rows, cols);


            PrintMatrix(matrix);
        }

        private static void FillSpiralMatrix(int[,] matrix, int counter, int rowStart, int colStart, int turns, int rows, int cols)
        {
            while (counter < rows * cols) //loop from 1 to 9 in case of 3x3 matrix
            {
                for (int move2R = colStart + 1; move2R < cols - turns; move2R++)
                {
                    counter++;
                    matrix[rowStart, move2R] = counter;
                    colStart = move2R;
                }
                if (counter >= rows * cols) break;
                for (int moveD = rowStart + 1; moveD < rows - turns; moveD++)
                {
                    counter++;
                    matrix[moveD, colStart] = counter;
                    rowStart = moveD;
                }
                if (counter >= rows * cols) break;
                for (int move2L = colStart - 1; move2L >= 0 + turns; move2L--)
                {
                    counter++;
                    matrix[rowStart, move2L] = counter;
                    colStart = move2L;
                }
                if (counter >= rows * cols) break;

                turns++;

                for (int moveU = rowStart - 1; moveU >= 0 + turns; moveU--)
                {
                    counter++;
                    matrix[moveU, colStart] = counter;
                    rowStart = moveU;
                }
                if (counter >= rows * cols) break;
            }
        }
        


        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == matrix.GetLength(1) - 1)
                    {
                        Console.Write(matrix[i, j]);
                        //Console.Write(matrix[i, j].ToString().PadLeft(3)); //PadLeft
                    }
                    else
                    {
                        Console.Write(matrix[i, j] + " ");
                        //Console.Write(matrix[i, j].ToString().PadLeft(3) + " "); //PadLeft
                    }
                }
                Console.WriteLine();
            }
        }


    }
}
