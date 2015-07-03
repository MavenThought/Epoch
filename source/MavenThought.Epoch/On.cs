using System;

namespace MavenThought.Epoch
{
    public static class On
    {
        public static DateTime Jan(int day, int? year = null)
        {
            return CreateDate(day, 01, year);
        }
        public static DateTime Feb(int day, int? year = null)
        {
            return CreateDate(day, 02, year);
        }

        public static DateTime Mar(int day, int? year = null)
        {
            return CreateDate(day, 03, year);
        }
        public static DateTime Apr(int day, int? year = null)
        {
            return CreateDate(day, 04, year);
        }
        public static DateTime May(int day, int? year = null)
        {
            return CreateDate(day, 05, year);
        }
        public static DateTime Jun(int day, int? year = null)
        {
            return CreateDate(day, 06, year);
        }
        public static DateTime Jul(int day, int? year = null)
        {
            return CreateDate(day, 07, year);
        }
        public static DateTime Aug(int day, int? year = null)
        {
            return CreateDate(day, 08, year);
        }
        public static DateTime Sep(int day, int? year = null)
        {
            return CreateDate(day, 09, year);
        }
        public static DateTime Oct(int day, int? year = null)
        {
            return CreateDate(day, 10, year);
        }

        public static DateTime Nov(int day, int? year = null)
        {
            return CreateDate(day, 11, year);
        }

        public static DateTime Dec(int day, int? year = null)
        {
            return CreateDate(day, 12, year);
        }

        private static DateTime CreateDate(int day, int month, int? year = null)
        {
            var theYear = year ?? DateTime.Today.Year;

            return new DateTime(theYear, month, day);
        }
    }
}
