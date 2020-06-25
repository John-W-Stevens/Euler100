using System;
using System.Diagnostics;

namespace problem_6
{
    // The sum of the squares of the first ten natural numbers is,
    // 1^2 + 2^2 + ... + 10^2 = 385
    // The square of the sum of the first ten natural numbers is,
    // (1 + 2 + ... + 10)^2 = 55^2 = 3025
    // Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
    // Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

    class Program
    {
        // iterative method
        public static long Problem6a(long n)
        {
            double SumOfSquares = 0;
            long SquareOfSum = 0;

            for (var i = 1; i <= n; i++)
            {
                SumOfSquares += Math.Pow(i, 2);
                SquareOfSum += i;
            }
            return Convert.ToInt64(Math.Pow(SquareOfSum, 2) - SumOfSquares);
        }

        // mathematical method
        public static long Problem6b(long n)
        {
            long SumOfSquares = n * (n + 1) * (2 * n + 1) / 6;
            long SquareOfSum = Convert.ToInt64(Math.Pow((n * (n + 1) / 2),2));
            return SquareOfSum - SumOfSquares;
        }

        static void Main(string[] args)
        {
            Stopwatch Timer1 = new Stopwatch();
            Timer1.Start();
            long Solution1 = Problem6a(100);
            Timer1.Stop();
            Console.WriteLine($"{Solution1} found in {Timer1.Elapsed} time.");
            // 25164150 found in 00:00:00.0003979 time.

            Stopwatch Timer2 = new Stopwatch();
            Timer2.Start();
            long Solution2 = Problem6b(100);
            Timer2.Stop();
            Console.WriteLine($"{Solution2} found in {Timer2.Elapsed} time.");
            //25164150 found in 00:00:00.0001244 time.
        }
    }
}
