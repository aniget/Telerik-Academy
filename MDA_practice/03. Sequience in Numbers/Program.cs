using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Sequience_in_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] result = input.Split(' ').Select(x => int.Parse(x)).ToArray();
            int? count;
            int? max = 1; //max sum
            int? maxR = 1;
            int? maxC = 1;
            int? maxD1 = 1;
            int? maxD2 = 1;
            int rows = result[0];
            int cols = result[1];
            string[,] matrix = new string[rows, cols];

            string line = "";
            string[] lineArr = new string[cols];

            //read console input into array
            for (int row = 0; row < rows; row++)
            {
                line = Console.ReadLine();
                lineArr = line.Split(' ').Select(x => x).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = lineArr[col];
                }
            }

            //read and analyze array


            //read ROWS
            for (int r = 0; r < rows; r++)
            {
                count = 1;
                for (int c = 0; c < cols - 1; c++)
                {
                    if (matrix[r, c] == matrix[r, c + 1])
                    {
                        count++;
                        if (count > maxR)
                        {
                            maxR = count;
                        }
                    }
                    else
                    {
                        count = 1;
                    }

                }
            }

            //read COLUMNS

            for (int c = 0; c < cols; c++)
            {
                count = 1;
                for (int r = 0; r < rows - 1; r++)
                {
                    if (matrix[r, c] == matrix[r + 1, c])
                    {
                        count++;
                        if (count > maxC)
                        {
                            maxC = count;
                        }
                    }
                    else
                    {
                        count = 1;
                    }

                }
            }

            //read DIAGONALS 1 (1 of 2)

            //loop through diagonals
            for (int r = 0; r < rows - 1; r++)
            {
                int c = 0;
                count = 1;
                //loop through diagonal elements
                for (int r1 = r; r1 < rows - 1; r1++)
                {
                    if (c < cols - 1)
                    {
                        if (matrix[r1, c] == matrix[r1 + 1, c + 1])
                        {
                            count++;
                            if (count > maxD1)
                            {
                                maxD1 = count;
                            }
                        }
                        else
                        {
                            count = 1;
                        }
                        c++;
                    }
                }
            }

            //read DIAGONALS 1 (2 of 2)

            //loop through diagonals
            for (int c = 0; c < rows - 1; c++)
            {
                int c1 = c;
                count = 1;
                //loop through diagonal elements
                for (int r = 0; r < rows - 1; r++)
                {
                    if (c1 < cols - 1)
                    {
                        if (matrix[r, c1] == matrix[r + 1, c1 + 1])
                        {
                            count++;
                            if (count > maxD1)
                            {
                                maxD1 = count;
                            }
                        }
                        else
                        {
                            count = 1;
                        }
                        c1++;
                    }

                }
            }


            //read DIAGONALS 2 (1 of 2)

            //loop through diagonals
            for (int r = 0; r < rows - 1; r++)
            {
                int c = cols - 1;
                count = 1;
                //loop through diagonal elements
                for (int r1 = r; r1 < rows - 1; r1++)
                {
                    if (c > 0)
                    {
                        if (matrix[r1, c] == matrix[r1 + 1, c - 1])
                        {
                            count++;
                            if (count > maxD2)
                            {
                                maxD2 = count;
                            }
                        }
                        else
                        {
                            count = 1;
                        }
                        c--;

                    }
                }
            }

            //read DIAGONALS 2 (2 of 2)
            //loop through diagonals
            for (int c = cols - 1; c > 0; c--)
            {
                count = 1;
                int c1 = c;
                //loop through diagonal elements
                for (int r1 = 0; r1 < rows - 1; r1++)
                {
                    if (c1 > 0)
                    {
                        if (matrix[r1, c1] == matrix[r1 + 1, c1 - 1])
                        {
                            count++;
                            if (count > maxD2)
                            {
                                maxD2 = count;
                            }
                        }
                        else
                        {
                            count = 1;
                        }
                        c1--;
                    }

                }
            }

            max = new[] { maxR, maxC, maxD1, maxD2 }.Max();
            Console.WriteLine(max);
        }
    }
}
