using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

//for unknow reason I got only 50 out ot 100
namespace BigShiftmatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            //int rows = 2;
            //int cols = 2;
            //int moves = 4;
            //decimal[] codes = { 14, 27, 1, 5 };
            //int moves = 2;
            //decimal[] codes = { 2, 0 };

            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int moves = int.Parse(Console.ReadLine());
            decimal[] codes = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();

            int max = Math.Max(rows, cols);

            BigInteger[,] matrix = new BigInteger[rows, cols];

            BigInteger sum = 0;

            BigInteger s = BigInteger.Parse(Math.Pow(2, rows - 1).ToString());

            BigInteger start = s;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = start;
                    start *= 2;
                }
                s /= 2;
                start = s;
            }

            PrintMatrix(matrix);

            int row = 0;
            int col = 0;

            int prevRow = rows - 1;
            int prevCol = 0;
            for (int code = 0; code < moves; code++)
            {
                row = int.Parse(Math.Floor(codes[code] / max).ToString());
                col = int.Parse(Math.Floor(codes[code] % max).ToString());

                if (row == rows-1 && col == 0 && matrix[row, col] == 1)
                {
                    sum = 1;
                    matrix[row, col] = 0;
                }

                //col = int.Parse(Math.Round(codes[code] % max, MidpointRounding.AwayFromZero).ToString());

                if (prevCol > col)
                {
                    for (int cc = prevCol; cc >= col; cc--)
                    {
                        sum += matrix[prevRow, cc];
                        matrix[prevRow, cc] = 0;
                    }
                    prevCol = col;
                }
                else if (prevCol < col)
                {
                    for (int cc = prevCol; cc <= col; cc++)
                    {
                        sum += matrix[prevRow, cc];
                        matrix[prevRow, cc] = 0;
                    }
                    prevCol = col;
                }

                if (prevRow > row)
                {
                    for (int rr = prevRow; rr >= row; rr--)
                    {
                        sum += matrix[rr, prevCol];
                        matrix[rr, prevCol] = 0;
                    }
                    prevRow = row;
                }
                else if (prevRow < row)
                {
                    for (int rr = prevRow; rr <= row; rr++)
                    {
                        sum += matrix[rr, prevCol];
                        matrix[rr, prevCol] = 0;
                    }
                    prevRow = row;
                }
                //PrintMatrix(matrix);
                prevCol = col;
                prevRow = row;
            }

            //print the matrix
            //PrintMatrix(matrix);

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
