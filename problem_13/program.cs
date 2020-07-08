using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;

namespace problem13
{
    class Program
    {
        public static string Add(string n1, string n2)
        {
            if (n2.Length > n1.Length)
            {
                string temp = n1;
                n1 = n2;
                n2 = temp;
            }

            int Diff = n1.Length - n2.Length;

            List<string> N1 = new List<string>();
            foreach (char c in n1){ N1.Add(c.ToString()); }

            List<string> N2 = new List<string>();
            for (int i = 0; i < Diff; i++) { N2.Add("0"); }
            foreach (char c in n2) { N2.Add(c.ToString()); }

            List<string> Output = new List<string>();
            for (int i = 0; i < N1.Count + 1; i++) { Output.Add("0".ToString()); }

            int CarryOver = 0;
            for (int i=N1.Count-1; i >= 0; i--)
            {
                int S = Int16.Parse(N1[i]) + Int16.Parse(N2[i]) + CarryOver;
                CarryOver = 0;
                if (S > 9)
                {
                    string Sum = S.ToString();
                    Output[i+1] = Sum[1].ToString();
                    CarryOver = Int16.Parse(Sum[0].ToString());
                }
                else
                {
                    Output[i+1] = S.ToString();
                }
            }
            if (CarryOver != 0)
            {
                Output[0] = CarryOver.ToString();
            }
            int j = 0;
            while (Output[j] == "0".ToString())
            {
                j += 1;
            }
            List<string> Result = Output.Skip(j).ToList();

            var stringsArray = Result.Select(i => i.ToString()).ToArray();
            var values = string.Join("", stringsArray);

            return values;
        }

        public static string Problem13()
        {
            string[] Numbers = File.ReadAllText("problem_13.txt").Split("\n");
            string Solution = string.Join("", Numbers.Aggregate((a, b) => Add(a, b)).Skip(0).Take(10));
            return Solution;
        }

        static void Main(string[] args)
        {
            Stopwatch Timer = new Stopwatch();
            Timer.Start();
            string Solution = Problem13();
            Timer.Stop();
            Console.WriteLine($"{Solution} found in {Timer.Elapsed} time.");
            // 5537376230 found in 00:00:00.0183323 time.
        }
    }
}
