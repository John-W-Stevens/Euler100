using System;
using System.Diagnostics;

namespace problem9
{
    class Program
    {
        public static int Problem9()
        {
            int limit = Convert.ToInt32(Math.Sqrt(500) + 1);
            for (int m = 2; m <= limit; m++)
            {
                for (int n = 1; n < m; n++)
                {
                    if (Convert.ToInt32(m*m + m*n) == 500)
                    {
                        return Convert.ToInt32((m*m - n*n) * 2 * m * n * (m*m + n*n));
                    }
                }
            }
            return 1;
        }
        static void Main(string[] args)
        {
            Stopwatch Timer = new Stopwatch();
            Timer.Start();
            long Solution = Problem9();
            Timer.Stop();
            Console.WriteLine($"{Solution} found in {Timer.Elapsed} time.");
            //31875000 found in 00:00:00.0004856 time.
        }
    }
}
