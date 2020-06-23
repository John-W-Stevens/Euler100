using System;
using System.Diagnostics;

namespace Problem3
{
    class Program
    {
        public static Boolean IsPrime(long n)
        {
            if (n <= 1) { return false; }
            if (n == 2 || n == 3) { return true; }
            if (n % 2 == 0 || n % 3 == 0) { return false; }

            int i = 5;
            int w = 2;
            while (i * i < n)
            {
                if (n % i == 0) { return false; }
                i += w;
                w = 6 - w;
            }
            return true;
        }

        public static long Problem3(long n)
        {
            long lpf = 0; // largest prime factor
            int lower;
            int step;

            if (n % 2 != 0) // if n is odd then we don't need to look at even numbers
            {
                lower = 3;
                step = 2;
            }
            else // if n is even then we need to look at odd & even numbers
            {
                lower = 2;
                step = 1;
            }
            for (long num = lower; num < Convert.ToInt64(Math.Sqrt(n)+1); num += step)
            {
                if (n % num == 0)
                {
                    // the first value that satisfies the first condition below is the answer
                    if (IsPrime(n / num)) { return n / num; }
                    if (IsPrime(num)) { lpf = num; }
                    n /= num; // reduce the size of the problem at each step
                }
            }
            return lpf;
        }



        static void Main(string[] args)
        {
            Stopwatch Timer = new Stopwatch();
            Timer.Start();
            long Solution = Problem3(600851475143);
            Timer.Stop();
            Console.WriteLine($"{Solution} found in {Timer.Elapsed} time.");
            // 6857 found in 00:00:00.0005383 time.
        }
    }
}
