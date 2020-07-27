using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace problem19
{

    class Program
    {
        static Boolean IsLeapYear(int year)
        {
            if (year % 400 == 0) { return true; }
            else if (year % 100 == 0) { return false; }
            else { return year % 4 == 0; }
        }

        static Boolean IsSunday(string day)
        {
            return day == "sun";
        }

        static Dictionary<string, int> GetMonths(int year)
        {
            Dictionary<string, int> Months = new Dictionary<string, int>();
            Months.Add("jan", 31);
            if (IsLeapYear(year)) { Months.Add("feb", 29); }
            else { Months.Add("feb", 28); }
            Months.Add("mar", 31);
            Months.Add("apr", 30);
            Months.Add("may", 31);
            Months.Add("jun", 30);
            Months.Add("jul", 31);
            Months.Add("aug", 31);
            Months.Add("sep", 30);
            Months.Add("oct", 31);
            Months.Add("nov", 30);
            Months.Add("dec", 31);
            return Months;
        }

        static string GetLastDayOfMonth(string FirstDay, int DaysInMonth)
        {
            string[] Days = new string[7] { "sun", "mon", "tue", "wed", "thur", "fri", "sat" };
            int start = Array.IndexOf(Days, FirstDay);
            int IndexOfLastDay = DaysInMonth % 7 + start;
            if (IndexOfLastDay >= 0 && IndexOfLastDay < Days.Length)
            {
                return Days[IndexOfLastDay];
            }
            else
            {
                return Days[IndexOfLastDay - 7];
            }
        }

        static string NextFirstDayOfMonth(string PrevFirstDay, int DaysInMonth)
        {
            string LastDayOfMonth = GetLastDayOfMonth(PrevFirstDay, DaysInMonth);
            Dictionary<string, string> NextDay = new Dictionary<string, string>();
            NextDay.Add("sun", "mon");
            NextDay.Add("mon", "tue");
            NextDay.Add("tue", "wed");
            NextDay.Add("wed", "thur");
            NextDay.Add("thur", "fri");
            NextDay.Add("fri", "sat");
            NextDay.Add("sat", "sun");
            return NextDay[LastDayOfMonth];
        }

        static string GetFirstDayOf1901()
        {
            Dictionary<string, int> Months = GetMonths(1900);
            string FirstDay = "mon";
            foreach (var item in Months)
            {
                FirstDay = NextFirstDayOfMonth(FirstDay, item.Value);
            }
            return FirstDay;
        }

        static int Problem19()
        {
            int NumSundays = 0;
            string FirstDay = GetFirstDayOf1901();
            if (IsSunday(FirstDay)) { NumSundays += 1; }

            for (int year = 1901; year <= 2000; year++)
            {
                Dictionary<string, int> Months = GetMonths(year);
                foreach (var item in Months)
                {
                    FirstDay = NextFirstDayOfMonth(FirstDay, item.Value);
                    if (IsSunday(FirstDay)) { NumSundays += 1; }
                }
            }
            return NumSundays;
        }

        static void Main(string[] args)
        {
            Stopwatch Timer = new Stopwatch();
            Timer.Start();
            int Solution = Problem19();
            Timer.Stop();
            Console.WriteLine($"{Solution} found in {Timer.Elapsed} time.");
            // 171 found in 00:00:00.0048203 time.
        }
    }
}
