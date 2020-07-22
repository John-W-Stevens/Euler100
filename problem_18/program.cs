using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace problem18
{

    class Program
    {
        static List<int[]> buildTriangle(string fileName)
        {
            List<int[]> Triangle = new List<int[]>();
            foreach (string line in File.ReadLines(fileName))
            {
                string[] splitLine = line.Split(" ");
                Triangle.Add(Array.ConvertAll(splitLine, e => int.Parse(e)));
            }
            return Triangle;
        }

        static void AddLeftChild(List<int[]> Triangle, int i, int j)
        {
            Triangle[i][j] += Triangle[i + 1][j];
        }   

        static void AddRightChild(List<int[]> Triangle, int i, int j)
        {
            Triangle[i][j] += Triangle[i + 1][j+1];
        }

        static void CompareChildrenAndAddLargestChild(List<int[]> Triangle, int i, int j)
        {
            if (Triangle[i+1][j] > Triangle[i + 1][j + 1])
            {
                AddLeftChild(Triangle, i, j);
            }
            else
            {
                AddRightChild(Triangle, i, j);
            }
        }

        static int Problem18()
        {
            List<int[]> Triangle = buildTriangle("problem_18.txt");

            for (int i = Triangle.Count - 2; i >= 0; i--)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    CompareChildrenAndAddLargestChild(Triangle, i, j);
                }
            }
            return Triangle[0][0];
        }
        static void Main(string[] args)
        {

            Stopwatch Timer = new Stopwatch();
            Timer.Start();
            int Solution = Problem18();
            Timer.Stop();
            Console.WriteLine($"{Solution} found in {Timer.Elapsed} time.");
            // 1074 found in 00:00:00.0129024 time.
        }
    }
}
