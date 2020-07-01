using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;


namespace problem10
{
    // Array Extenstion for PrimeSieve method
    class Program
    {
        // Range, Compress, & PrimeSieve functions
        public static long Problem10()
        {
            return PrimeSieve(2000000).Sum(x => (long)x);
        }
        static void Main(string[] args)
        {
            Stopwatch Timer = new Stopwatch();
            Timer.Start();
            long Solution = Problem10();
            Timer.Stop();
            Console.WriteLine($"{Solution} found in {Timer.Elapsed} time.");
            // 142913828922 found in 00:00:00.0554777 time.
        }
    }
}
