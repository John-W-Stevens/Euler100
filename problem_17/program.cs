using System;
using System.Linq;
using System.Diagnostics;

namespace problem17
{
    class Program
    {

        static int Sum(int[] arr)
        {
            return arr.Aggregate((a, b) => (a + b));
        }

        static int Problem17()
        {
            int[] Ones = new string[9] {
                "one","two","three",
                "four","five","six",
                "seven","eight","nine"
            }.Select(e => e.Length).ToArray();

            int[] Teens = new string[9] {
                "eleven","twelve","thirteen",
                "fourteen","fifteen","sixteen",
                "seventeen","eighteen","nineteen"
            }.Select(e => e.Length).ToArray();

            int[] Tens = new string[9] {
                "ten","twenty","thirty",
                "forty","fifty","sixty",
                "seventy","eighty","ninety"
            }.Select(e => e.Length).ToArray();

            int[] Hundreds = new string[9] {
                "onehundred","twohundred","threehundred",
                "fourhundred","fivehundred","sixhundred",
                "sevenhundred","eighthundred","ninehundred"
            }.Select(e => e.Length).ToArray();

            int letters = 0;

            letters += Sum(Ones) + Sum(Teens) + Sum(Tens) + Sum(Hundreds);

            foreach (int ten in Tens.Skip(1))
            {
                foreach (int one in Ones) { letters += ten + one; }
            }

            foreach (int hundred in Hundreds)
            {
                foreach (int one in Ones) { letters += hundred + 3 + one; }
                letters += hundred + 3 + Tens[0];
                foreach (int teen in Teens) { letters += hundred + 3 + teen; }
                foreach (int ten in Tens.Skip(1))
                {
                    letters += hundred + 3 + ten;
                    foreach (int one in Ones) { letters += hundred + 3 + ten + one; }
                }
            }

            letters += 11; // one thousand

            return letters;
        }

        static void Main(string[] args)
        {
            Stopwatch Timer = new Stopwatch();
            Timer.Start();
            int Solution = Problem17();
            Timer.Stop();
            Console.WriteLine($"{Solution} found in {Timer.Elapsed} time.");
            // 21124 found in 00:00:00.0055345 time.
        }
    }
}
