using System;
using System.Diagnostics;

namespace problem4
{
    // A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
    // Find the largest palindrome made from the product of two 3-digit numbers.

    class Program
    {
        public static string ReverseString(string astring)
        {
            char[] charArray = astring.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static Boolean IsPalindrome(string astring)
        {
            return astring == ReverseString(astring);
        }

        public static int Problem4()
        {
            int largest_palindrome = 0;
            for (int i = 999; i > 100; i--)
            {
                for (int j = i; j > 100; j--)
                {
                    int number = i * j;
                    if (number < largest_palindrome) { break; }
                    if (number % 11 != 0) { continue; }
                    if (IsPalindrome(number.ToString())) { largest_palindrome = number; }
                }
            }
            return largest_palindrome;
        }

        static void Main(string[] args)
        {
            Stopwatch Timer = new Stopwatch();
            Timer.Start();
            long Solution = Problem4();
            Timer.Stop();
            Console.WriteLine($"{Solution} found in {Timer.Elapsed} time.");
            // 906609 found in 00:00:00.0013374 time.
        }
    }
}
