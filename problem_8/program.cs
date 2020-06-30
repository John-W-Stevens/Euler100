using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace problem8
{
    class Program
    {
        public static long Multiply(Queue<int> Q)
        {
            long output = 1;
            foreach (int n in Q) { output *= n; }
            return output;
        }

        public static long Problem8()
        {
            long MaxProduct = 0;
            string NumberString = File.ReadAllText("./problem_8.txt").Replace("\n", "");

            Queue<int> Numbers = new Queue<int>();
            int i = 0;

            while (i < NumberString.Length - 13)
            {
                while (Numbers.Count < 13)
                {
                    Numbers.Enqueue(int.Parse(NumberString.Substring(i, 1)));
                    i++;
                }
                while (Numbers.Contains(0)) { Numbers.Dequeue(); }

                if (Numbers.Count == 13)
                {
                    long Product = Multiply(Numbers);
                    if (Product > MaxProduct) { MaxProduct = Product; }
                    Numbers.Dequeue();
                }
            }
            return MaxProduct;
        }

        static void Main(string[] args)
        {
            Stopwatch Timer = new Stopwatch();
            Timer.Start();
            long Solution = Problem8();
            Timer.Stop();
            Console.WriteLine($"{Solution} found in {Timer.Elapsed} time.");
            // 23514624000 found in 00:00:00.0125418 time.       
        }
    }
}
