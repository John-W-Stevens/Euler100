using System;
using System.Diagnostics;

namespace Problem2
{
    class Program
    {

        public static int Problem2(int limit)
        {
            int Total = 2;
            int n1 = 1;
            int n2 = 2;
            int n3 = 3;

            while (n3 < limit)
            {
                if (n3 % 2 == 0)
                {
                    Total += n3;
                }
                n1 = n2;
                n2 = n3;
                n3 += n1;
            }

            return Total;
        }

        static void Main(string[] args)
        {
            Stopwatch Timer = new Stopwatch();
            Timer.Start();
            int Solution = Problem2(4000000);
            Timer.Stop();
            Console.WriteLine($"{Solution} found in {Timer.Elapsed} time.");
            // 4613732 found in 00:00:00.0000970 time.
        }
    }
}
