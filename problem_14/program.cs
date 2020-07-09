using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace problem14
{
    public static class Variables
    {
        public static Dictionary<long, int> ChainTable = new Dictionary<long, int>();
    }

    class Program
    {
        static int CheckChainLength(long n)
        {
            int Length;
            if (n <= 1) { return 1; }
            if (Variables.ChainTable.ContainsKey(n)) { return Variables.ChainTable[n]; }

            if (n % 2 == 0){ Length = CheckChainLength(n / 2) + 1; }
            else { Length = CheckChainLength((3 * n + 1) / 2) + 2; }
            if (n < 1000000){ Variables.ChainTable[n] = Length; }
            return Length;
        }

        static long Problem14()
        {
            int LongestChain = 1;
            long Number = 1;
            for (long n = 500000; n < 1000000; n++)
            {
                int ChainLength = CheckChainLength(n);
                if (ChainLength > LongestChain)
                {
                    LongestChain = ChainLength;
                    Number = n;
                }
            }
            return Number;
        }

        static void Main(string[] args)
        {
            Stopwatch Timer = new Stopwatch();
            Timer.Start();
            long Solution = Problem14();
            Timer.Stop();
            Console.WriteLine($"{Solution} found in {Timer.Elapsed} time.");
            // 837799 found in 00:00:00.2300996 time.
        }
    }
}
