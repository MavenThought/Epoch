using System;
using System.Collections;
using System.Collections.Generic;

namespace MavenThought.Epoch
{
    public class DateRange : IEnumerable<DateTime>, IEquatable<DateRange>
    {
        public DateRange(DateTime startingAt, DateTime endingAt)
        {
            this.StartDate = startingAt.Date;
            this.EndDate = endingAt.Date;
        }

        public DateRange(DateTime startingAt, TimeSpan span)
            : this(startingAt, startingAt + span)
        { }

        public DateTime StartDate { get; private set; }

        public DateRange NotInclusive
        {
            get { return new DateRange(this.StartDate, this.EndDate.AddDays(-1)); }
        }

        public DateTime EndDate { get; private set; }

        public bool Includes(DateTime date)
        {
            return this.StartDate <= date && date <= this.EndDate;
        }

        public bool Overlaps(DateRange range)
        {
            return
                (this.StartDate >= range.StartDate && this.StartDate < range.EndDate) ||
                (range.StartDate >= this.StartDate && range.StartDate < this.EndDate);
        }

        public IEnumerator<DateTime> GetEnumerator()
        {
            var counter = this.StartDate;

            while (counter <= this.EndDate)
            {
                yield return counter;
                counter = counter.AddDays(1);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            return obj is DateRange && Equals((DateRange)obj);
        }

        public override int GetHashCode()
        {
            return this.StartDate.GetHashCode() | this.EndDate.GetHashCode();
        }

        public bool Equals(DateRange other)
        {
            return other.StartDate == this.StartDate && other.EndDate == this.EndDate;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.StartDate, this.EndDate);
        }
    }
}