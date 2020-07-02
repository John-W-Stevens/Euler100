using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

namespace problem11
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch Timer = new Stopwatch();
            Timer.Start();

            string[] StringGrid = File.ReadAllText("problem_11.txt").Split("\n");
            List<int[]> Grid = new List<int[]>();

            foreach (string row in StringGrid)
            {
                int[] IntRow = new int[20];
                string[] Row = row.Split(" ");
                for (int i = 0; i < 20; i++)
                {
                    IntRow[i] = Int16.Parse(Row[i]);
                }
                Grid.Add(IntRow);
            }

            long max_product = 0;

            foreach (int[] row in Grid) // horizontal
            {
                for (var i = 0; i < 17; i++)
                {
                    long product = row[i] * row[i + 1] * row[i + 2] * row[i + 3];
                    max_product = product > max_product ? product : max_product;
                }
            }

            for (int i = 0; i < 17; i++) // vertical
            {
                for (int j = 0; j < 20; j++)
                {
                    long product = Grid[i][j] * Grid[i + 1][j] * Grid[i + 2][j] * Grid[i + 3][j];
                    max_product = product > max_product ? product : max_product;
                }
            }

            for (int i = 0; i < 17; i++) // diagonal right
            {
                for (int j = 0; j < 17; j++)
                {
                    long product = Grid[i][j] * Grid[i + 1][j + 1] * Grid[i + 2][j + 2] * Grid[i + 3][j + 3];
                    max_product = product > max_product ? product : max_product;
                }
            }

            for (int i = 0; i < 17; i++) // diagonal left
            {  
                for (var j = 0; j < 17; j++)
                {
                    long product = Grid[i + 3][j] * Grid[i + 2][j + 1] * Grid[i + 1][j + 2] * Grid[i][j + 3];
                    max_product = product > max_product ? product : max_product;
                }
            }

            Timer.Stop();
            Console.WriteLine($"{max_product} found in {Timer.Elapsed} time.");
            //70600674 found in 00:00:00.0082573 time.
        }
    }
}
