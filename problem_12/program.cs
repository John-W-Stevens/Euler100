using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace problem12
{
    // Array extension from PrimeSieve Namespace

    class Program
    {
        // Range, Compress, PrimeSieve Methods
        // PrimeFactorization and NumDivisors methods from PrimeFactorization

        public static long Problem12()
        {
            int n = 1;
            int[] Primes = PrimeSieve(100);
            while (n < 50000)
            {
                int Triangle = Convert.ToInt32(n * (n + 1) / 2);
                Dictionary<int, int> PrimeFactors = PrimeFactorization(Triangle, Primes);
                if (NumDivisors(PrimeFactors) > 500)
                {
                    return Triangle;
                }
                n += 1;
            }
            return 1;
        }

        static void Main(string[] args)
        {
            Stopwatch Timer = new Stopwatch();
            Timer.Start();
            long Solution = Problem12();
            Timer.Stop();
            Console.WriteLine($"{Solution} found in {Timer.Elapsed} time.");
            // 76576500 found in 00:00:00.0132832 time.
        }
    }
}