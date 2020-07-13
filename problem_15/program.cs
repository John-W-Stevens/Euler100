using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace problem15
{
    class Program
    {
        public static long Problem15(int n, int m, Dictionary<string, long> Memo)
        {
            if (Memo == null) { Memo = new Dictionary<string, long>(); }
            if (m == 1 || n == 1) { return 1; }
            string Key = $"{m},{n}";
            if (Memo.ContainsKey(Key)) { return Memo[Key]; }
            else
            {
                long Result = Problem15(m - 1, n, Memo) + Problem15(m, n - 1, Memo);
                Memo[Key] = Result;
                return Result;
            }
        }
        static void Main(string[] args)
        {
            Stopwatch Timer = new Stopwatch();
            Timer.Start();
            Dictionary<string, long> Memo = new Dictionary<string, long>();
            long Solution = Problem15(21,21,Memo);
            Timer.Stop();
            Console.WriteLine($"{Solution} found in {Timer.Elapsed} time.");
            // 137846528820 found in 00:00:00.0014960 time.
        }
    }
}
