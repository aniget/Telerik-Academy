using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
//100 of 100
namespace BigShiftMatrix_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //read INPUT
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int moves = int.Parse(Console.ReadLine());
            decimal[] codes = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();

            int powerC = 0;
            int powerR = 0;

            //fill the matrix
            BigInteger[,] matrix = new BigInteger[rows, cols];
            for (int r = rows - 1; r >= 0; r--)
            {
                for (int c = 0; c < cols; c++)
                {
                    matrix[r,c] = (BigInteger)Math.Pow(2, powerC);
                    powerC++;
                }
                powerR++;
                powerC = powerR;
            }

            int rowStart = rows - 1;
            int colStart = 0;

            int max = Math.Max(rows, cols);

            BigInteger sum = matrix[rowStart, colStart];
            matrix[rowStart, colStart] = 0;

            foreach (var code in codes)
            {
                int rowEnd = int.Parse(Math.Truncate(code / max).ToString());
                int colEnd = int.Parse(Math.Truncate(code % max).ToString());

                if (colStart<=colEnd)
                {
                    for (int c = colStart; c <= colEnd; c++)
                    {
                        sum += matrix[rowStart, c];
                        matrix[rowStart, c] = 0;
                    }
                    colStart = colEnd;
                }
                else
                {
                    for (int c = colStart-1; c >= colEnd; c--) //it is colStart - 1 because on colStart position number was already added to sum
                    {
                        sum += matrix[rowStart, c];
                        matrix[rowStart, c] = 0;
                    }
                    colStart = colEnd;
                }

                if (rowStart <= rowEnd)
                {
                    for (int r = rowStart; r <= rowEnd; r++)
                    {
                        sum += matrix[r, colStart];
                        matrix[r, colStart] = 0;
                    }
                    rowStart = rowEnd;
                }
                else
                {
                    for (int r = rowStart - 1; r >= rowEnd; r--) //it is colStart - 1 because on colStart position number was already added to sum
                    {
                        sum += matrix[r, colStart];
                        matrix[r, colStart] = 0;
                    }
                    rowStart = rowEnd;
                }
                
            }

            Console.WriteLine(sum);
        }






        public static void PrintMatrix(BigInteger[,] matrix)
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == matrix.GetLength(1) - 1)
                    {
                        //Console.Write(matrix[i, j]);
                        Console.Write(matrix[i, j].ToString().PadLeft(3)); //PadLeft
                    }
                    else
                    {
                        //Console.Write(matrix[i, j] + " ");
                        Console.Write(matrix[i, j].ToString().PadLeft(3) + " "); //PadLeft
                    }
                }
                Console.WriteLine();
            }
        }

    }
}

