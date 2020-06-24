using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace problem5
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

        public static Dictionary<int, int> PrimeFactorization(int n)
        {
            // Assumes n >= 2
            // Returns a dict mapping the prime factors of n and their respective powers 
            Dictionary<int, int> PrimeFactors = new Dictionary<int, int>();

            if (IsPrime(n)) { PrimeFactors.Add(n, 1); }
            else
            {
                PrimeFactors.Add(2, 0);
                PrimeFactors.Add(3, 0);
                while (n % 2 == 0)
                {
                    PrimeFactors[2] += 1;
                    n /= 2;
                }
                while (n % 3 == 0)
                {
                    PrimeFactors[3] += 1;
                    n /= 3;
                }
                for (int i = 5; i < Math.Sqrt(n) + 1; i++)
                {
                    if (!IsPrime(i)) { continue; }
                    while (n % i == 0)
                    {
                        if (!PrimeFactors.ContainsKey(i)) { PrimeFactors.Add(i, 1); }
                        else { PrimeFactors[i] += 1; }
                        n /= i;
                    }
                }
            }
            return PrimeFactors;
        }

        public static long Problem5(int n)
        {
            // Returns the smallest number divisible by every number <= n
            long output = 1;
            Dictionary<int, int> PrimeFactorMaps = new Dictionary<int, int>();

            for (int i = 2; i < n + 1; i++)
            {
                Dictionary<int, int> PrimeFactors = PrimeFactorization(i);
                foreach (KeyValuePair<int,int> entry in PrimeFactors)
                {
                    if (!PrimeFactorMaps.ContainsKey(entry.Key)) { PrimeFactorMaps.Add(entry.Key, entry.Value); }
                    else if (PrimeFactorMaps[entry.Key] < entry.Value) { PrimeFactorMaps[entry.Key] = entry.Value; }
                }
            }
            foreach (KeyValuePair<int, int> entry in PrimeFactorMaps)
            {
                output *= Convert.ToInt64(Math.Pow(entry.Key, entry.Value));
            }


            return output;
        }

        static void Main(string[] args)
        {
            Stopwatch Timer = new Stopwatch();
            Timer.Start();
            long Solution = Problem5(20);
            Timer.Stop();
            Console.WriteLine($"{Solution} found in {Timer.Elapsed} time.");
            // 232792560 found in 00:00:00.0016759 time.
        }
    }
}
