using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace problem16
{
    class Program
    {
        static string MultiplyBy2(string n)
        {
            // create list from input string
            List<short> N = new List<short>();
            N.Add(0);
            foreach (char d in n) { N.Add(Int16.Parse(d.ToString())); }

            // create output list and fill with zeros
            List<short> Output = new List<short>();
            for (short i = 0; i < N.Count; i++) { Output.Add(0); }

            // multiply each digit by 2, accounting for carryover
            short CarryOver = 0;
            for (int i = N.Count - 1; i >= 0; i--)
            {
                int Product = N[i] * 2 + CarryOver;
                CarryOver = 0; // reset carryover to zero
                if (Product > 9)
                {
                    string Number = Product.ToString();
                    Output[i] = Int16.Parse(Number[1].ToString());
                    CarryOver = Int16.Parse(Number[0].ToString());
                }
                else { Output[i] = Convert.ToInt16(Product); }
            }

            // handle leftover carryover
            if (CarryOver != 0) { Output[0] = CarryOver; }

            // strip leading zeros
            short j = 0;
            while (Output[j] == 0) { j += 1; }

            // Slice output, convert to string and return
            return string.Join("", Output.Skip(j).ToList().Select(d => d.ToString()).ToArray());
        }

        static int Problem16()
        {
            string Number = "2";
            for (int i = 1; i < 1000; i++) { Number = MultiplyBy2(Number); }
            List<int> Output = new List<int>();
            foreach (char d in Number) { Output.Add(Int16.Parse(d.ToString())); }
            return Output.Aggregate((a, b) => a + b);
        }

        static void Main(string[] args)
        {

            Stopwatch Timer = new Stopwatch();
            Timer.Start();
            int Solution = Problem16();
            Timer.Stop();
            Console.WriteLine($"{Solution} found in {Timer.Elapsed} time.");
            // 1366 found in 00:00:00.0335061 time.
        }
    }
}
