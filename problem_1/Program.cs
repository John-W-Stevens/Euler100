using System;
using System.Diagnostics;

namespace Problem1
{
    class Program
    {
        // Problem:
        // If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9.
        // The sum of these multiples is 23. Find the sum of all the multiples of 3 or 5 below 1000.

        // The iterative approach:
        public static int Problem1A(int n)
        {
            int Total = 0;
            for (int i=3; i<n; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    Total += i;
                }
            }
            return Total;
        }

        // The mathematical approach:
        public static int SumAS(int a, int d, int n)
        {
            // Returns the sum of an arithmetic sequence
            // a: first term in series,
            // d: difference between each term
            // n: number of terms we want to sum 
            return Convert.ToInt32(n/2 * (2*a + (n-1) * d));
        }

        public static int Floor(int n, int d) {
            int q = n % d;
            return Convert.ToInt32((n - q) / d);
        }

        public static int Problem2A(int n)
        {
            int x = SumAS(3, 3, Floor(n,3));
            int y = SumAS(5, 5, Floor(n,5));
            int z = SumAS(15, 15, Floor(n, 15));
            return x + y - z;
        }

        public static void Main(string[] args)
        {
            // The iterative approach:
            Stopwatch timer1 = new Stopwatch();
            timer1.Start();
            int Solution1 = Problem1A(1000);
            timer1.Stop();
            Console.WriteLine($"{Solution1} found in {timer1.Elapsed} time.");
            // 233168 found in 00:00:00.0001084 total time.

            // The mathematical approach:
            Stopwatch timer2 = new Stopwatch();
            timer2.Start();
            int Solution2 = Problem1A(1000);
            timer2.Stop();
            Console.WriteLine($"{Solution2} found in {timer2.Elapsed} time.");
            // 233168 found in 00:00:00.0000079 time.
        }
    }
}
