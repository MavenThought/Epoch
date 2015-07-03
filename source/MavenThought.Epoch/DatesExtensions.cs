using System;

namespace MavenThought.Epoch
{
    public static class DatesExtensions
    {
        public static DateTime At(this DateTime time, int hours, int minutes = 0)
        {
            return time.Date + hours.Hours().Span + minutes.Minutes().Span;
        }
        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday;
        }

        public static DateTime EndOfDay(this DateTime date)
        {
            return date.BeginningOfDay().AddDays(1).AddMilliseconds(-1);
        }

        public static DateTime BeginningOfDay(this DateTime date)
        {
            return date.Date;
        }

        public static DateTimeBuilder Hour(this int number)
        {
            return number.Hours();
        }
        public static DateTimeBuilder Hours(this int number)
        {
            return new DateTimeBuilder(number, (d, hours) => d.AddHours(hours));
        }

        public static DateTimeBuilder Minute(this int number)
        {
            return number.Minutes();
        }

        public static DateTimeBuilder Minutes(this int number)
        {
            return new DateTimeBuilder(number, (d, minutes) => d.AddMinutes(minutes));
        }

        public static DateTimeBuilder Second(this int number)
        {
            return 1.Seconds();
        }

        public static DateTimeBuilder Seconds(this int number)
        {
            return new DateTimeBuilder(number, (d, seconds) => d.AddSeconds(seconds));
        }

        public static DateTimeBuilder Day(this int number)
        {
            return 1.Days();
        }

        public static DateTimeBuilder Days(this int number)
        {
            return new DateTimeBuilder(number, (d, i) => d.AddDays(i));
        }

        public static DateTimeBuilder Week(this int number)
        {
            return number.Weeks();
        }

        public static DateTimeBuilder Weeks(this int number)
        {
            return (number*7).Days();
        }
        
        public static DateTimeBuilder Month(this int number)
        {
            return 1.Months();
        }

        public static DateTimeBuilder Months(this int number)
        {
            return new DateTimeBuilder(number, (d, i) => d.AddMonths(i));
        }

        public static DateTimeBuilder Year(this int number)
        {
            return 1.Years();
        }

        public static DateTimeBuilder Years(this int number)
        {
            return new DateTimeBuilder(number, (d, i) => d.AddYears(i));
        }

    }

    public class DateTimeBuilder
    {
        private readonly int _number;
        private readonly Func<DateTime, int, DateTime> _adjustFunc;

        public DateTimeBuilder(int number, Func<DateTime, int, DateTime> adjustFunc)
        {
            _number = number;
            _adjustFunc = adjustFunc;
        }

        public DateTime Ago
        {
            get { return _adjustFunc(DateTime.Now, -_number); }
        }

        public DateTime FromNow
        {
            get { return _adjustFunc(DateTime.Now, _number); }
        }

        public static implicit operator TimeSpan(DateTimeBuilder builder)
        {
            return builder.Span;
        }

        public TimeSpan Span
        {
            get { return FromNow - DateTime.Now; }
        }
    }
}
