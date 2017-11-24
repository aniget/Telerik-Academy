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
            var nr = int.Parse(Console.ReadLine());
            var nc = nr;
            int r = 0;
            int c = 0;

            string pattern = Console.ReadLine();
            int[,] matrix = new int[nr, nc];
            int counter;

            //1 5 9 13
            //2 6 10 14
            //3 7 11 15
            //4 8 12 16
            //
            if (pattern == "a")
            {
                counter = 1;
                for (c = 0; c < matrix.GetLength(1); c++)

                {
                    for (r = 0; r < matrix.GetLength(0); r++)
                    {
                        matrix[r, c] = counter;
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
                counter = 1;
                for (c = 0; c < nr; c++)
                {
                    if (c % 2 == 0)
                    {
                        for (r = 0; r < nr; r++)
                        {
                            matrix[r, c] = counter;
                            counter++;
                        }
                    }
                    else
                    {
                        for (r = nr - 1; r > -1; r--)
                        {
                            matrix[r, c] = counter;
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
                counter = 1;
                int max_j = 1;
                //i - the number of iterations
                for (int i = 1; i < 2 * nr; i++)
                {
                    //j - the number of elements per iteration
                    r = nr - i;
                    if (i > nr)
                    {
                        max_j = 2 * nr - i;
                        r = 0;
                        c = i - nr;
                    }
                    else
                    {
                        max_j = i;
                        r = nr - i;
                        c = 0;
                    }
                    for (int j = 1; j < max_j + 1; j++)
                    {
                        matrix[r, c] = counter;
                        counter++;
                        c++;
                        r++;
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
                    c = count_circle;
                    for (r = count_circle; r < nr; r++)
                    {
                        if (matrix[r, c] == 0)
                        {
                            matrix[r, c] = counter;
                            counter++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    // RIGTH
                    r = nr - count_circle - 1;
                    for (c = count_circle + 1; c < nr; c++)
                    {
                        if (matrix[r, c] == 0)
                        {
                            matrix[r, c] = counter;
                            counter++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    // UP
                    c = nr - count_circle - 1;
                    for (r = nr - 2 - count_circle; r > -1 + count_circle; r--)
                    {
                        if (matrix[r, c] == 0)
                        {
                            matrix[r, c] = counter;
                            counter++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    // LEFT
                    r = count_circle;
                    for (c = nr - 2 - count_circle; c > -1 + count_circle; c--)
                    {
                        if (matrix[r, c] == 0)
                        {
                            matrix[r, c] = counter;
                            counter++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    count_circle++;
                } while (nr * nr > counter - 1);
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
                    }
                    else
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    //Console.Write(matrix[i, j].ToString().PadLeft(3) + " "); //PadLeft
                }
                Console.WriteLine();
            }
        }


    }

}
