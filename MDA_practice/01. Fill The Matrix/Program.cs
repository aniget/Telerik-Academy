using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Fill_The_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfRows = int.Parse(Console.ReadLine());
            var numberOfCols = numberOfRows;
            int row = 0;
            int col = 0;

            string pattern = Console.ReadLine();
            int[,] matrix = new int[numberOfRows, numberOfCols];
            int counter = 1;

            //1 5 9 13
            //2 6 10 14
            //3 7 11 15
            //4 8 12 16
            //
            if (pattern == "a")
            {
                for (col = 0; col < matrix.GetLength(1); col++)

                {
                    for (row = 0; row < matrix.GetLength(0); row++)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                }
            }

            //1 8 9 16
            //2 7 10 15
            //3 6 11 14
            //4 5 12 13

            if (pattern == "b")
            {
                for (col = 0; col < numberOfRows; col++)
                {
                    if (col % 2 == 0)
                    {
                        for (row = 0; row < numberOfRows; row++)
                        {
                            matrix[row, col] = counter;
                            counter++;
                        }
                    }
                    else
                    {
                        for (row = numberOfRows - 1; row > -1; row--)
                        {
                            matrix[row, col] = counter;
                            counter++;
                        }
                    }
                }

            }

            //7 11 14 16
            //4 8 12 15
            //2 5 9 13
            //1 3 6 10

            if (pattern == "c")
            {
                int max_j = 1;
                //i - the number of iterations
                for (int i = 1; i < 2 * numberOfRows; i++)
                {
                    //j - the number of elements per iteration
                    row = numberOfRows - i;
                    if (i > numberOfRows)
                    {
                        max_j = 2 * numberOfRows - i;
                        row = 0;
                        col = i - numberOfRows;
                    }
                    else
                    {
                        max_j = i;
                        row = numberOfRows - i;
                        col = 0;
                    }
                    for (int j = 1; j < max_j + 1; j++)
                    {
                        matrix[row, col] = counter;
                        counter++;
                        col++;
                        row++;
                    }
                }
            }

            //1 12 11 10
            //2 13 16  9
            //3 14 15  8
            //4  5  6  7
            if (pattern == "d")
            {
                counter = 1;
                //change direction in a cycle
                //down, right, up, left
                int count_circle = 0;

                do
                {
                    // DOWN
                    col = count_circle;
                    for (row = count_circle; row < numberOfRows - count_circle; row++)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                    if (counter > numberOfRows * numberOfRows) break;
                    row = numberOfRows - count_circle - 1;

                    // RIGTH
                    for (col = count_circle + 1; col < numberOfRows - count_circle; col++)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                    if (counter > numberOfRows * numberOfRows) break;
                    col = numberOfRows - count_circle - 1;

                    // UP
                    for (row = numberOfRows - 2 - count_circle; row > -1 + count_circle; row--)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                    if (counter > numberOfRows * numberOfRows) break;
                    row = count_circle;

                    count_circle++;
                    // LEFT

                    for (col = numberOfRows - 1 - count_circle; col > -1 + count_circle; col--)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                } while (numberOfRows * numberOfRows > counter - 1);
            }


            PrintMatrix(matrix);

        }

        public static void PrintMatrix(int[,] matrix)
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
