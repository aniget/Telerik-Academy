using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Largest_Area_in_Matrix
{
    // РЕШЕНИЕТО НА СТИЛЯН !!!

    class Program
    {
        static int rows;
        static int cols;
        static bool[,] used;
        static int greatestArea;
        static int currentArea;

        static int[][] matrix;
        static void Main(string[] args)
        {
            var token = Console.ReadLine().Split().Select(int.Parse).ToArray();
            rows = token[0];
            cols = token[1];

            var matrix = new int[rows][];
            used = new bool[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (!used[row, col])
                    {
                        currentArea = 0;
                        DFS(matrix, row, col, matrix[row][col]);
                    }
                }

            }

            Console.WriteLine(greatestArea);
        }

        private static void DFS(int[][] matrix, int row, int col, int targetValue)
        {
            if (row < 0 || col < 0 || row > rows - 1 || col > cols - 1)
                return;
            if (matrix[row][col] != targetValue)
                return;
            if (used[row, col])
                return;

            currentArea++;
            used[row, col] = true;
            greatestArea = greatestArea < currentArea ? currentArea : greatestArea;

            DFS(matrix, row + 1, col, targetValue);
            DFS(matrix, row - 1, col, targetValue);
            DFS(matrix, row, col + 1, targetValue);
            DFS(matrix, row, col - 1, targetValue);
        }
    }
}

