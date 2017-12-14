using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int[] result = input.Split(' ').Select(x=>int.Parse(x)).ToArray();
            int? sum;
            int? max = null; //max sum
            int rows = result[0];
            int cols = result[1];
            int[,] matrix = new int[rows, cols];

            string line = "";
            int[] lineArr = new int[cols];

            //read console input into array
            for (int row = 0; row < rows; row++)
            {
                line = Console.ReadLine();
                lineArr = line.Split(' ').Select(x => int.Parse(x)).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = lineArr[col];
                }    
            }

            //read and analyze array
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i<rows-2 && j<cols-2)
                    {
                        sum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                        if (sum > max || max == null)
                        {
                            max = sum;
                        }
                    }
                }
            }

            Console.WriteLine(max);
        }
    }
}
