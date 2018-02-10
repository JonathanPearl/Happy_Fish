using System;
using System.Collections.Generic;

namespace Common
{
    public static class Frequencies
    {
        public const string Freq0 = "Hourly";
        public const string Freq1 = "Daily";
        public const string Freq2 = "Weekly";
        public const string Freq3 = "Monthly";
        public const string Freq4 = "Quarterly";
        public const string Freq5 = "Yearly";
        public const string Freq6 = "Biennially";
        public const string Freq7 = "Lifetime";

        public static readonly List<string> List = new List<string>
        {
            { Freq3 },
            { Freq5 },
            { Freq4 },
            { Freq6 },
            { Freq7 },
            { Freq1 },
            { Freq0 },
            { Freq2 },
        };

        public static Tuple<DateTime, TimeSpan> FutureDateTimeAndDifference(string Frequency, DateTime InitialDateTime)
        {
            DateTime DT;

            switch (Frequency)
            {
                case Freq0:
                    DT = InitialDateTime.AddHours(1);
                    break;

                case Freq1:
                    DT = InitialDateTime.AddDays(1);
                    break;

                case Freq2:
                    DT = InitialDateTime.AddDays(7);
                    break;

                case Freq3:
                    DT = InitialDateTime.AddMonths(1);
                    break;

                case Freq4:
                    DT = InitialDateTime.AddMonths(3);
                    break;

                case Freq5:
                    DT = InitialDateTime.AddYears(1);
                    break;

                case Freq6:
                    DT = InitialDateTime.AddYears(2);
                    break;

                case Freq7:
                    DT = InitialDateTime.AddYears(24);
                    break;

                default:
                    return new Tuple<DateTime, TimeSpan>(InitialDateTime, new TimeSpan(0, 0, 0));
            }

            return new Tuple<DateTime, TimeSpan>(DT, DT - InitialDateTime);
        }
    }
}