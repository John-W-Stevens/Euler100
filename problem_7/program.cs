using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace problem7
{
    // Array Extenstion for PrimeSieve method

    class Program
    {
        // Range, Compress, & PrimeSieve functions

        public static int Problem7(int limit, int n)
        {
            return PrimeSieve(limit)[n];
        }

        static void Main(string[] args)
        {
            Stopwatch Timer = new Stopwatch();
            Timer.Start();
            int Solution = Problem7(150000, 10001);
            Timer.Stop();
            Console.WriteLine($"{Solution} primes found in {Timer.Elapsed} time.");
            // 104759 primes found in 00:00:00.0101365 time.
        }
    }
}
