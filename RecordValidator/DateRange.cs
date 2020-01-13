using System;
using System.Collections.Generic;

namespace RecordValidator
{
    public class DateRange
    {
        public DateRange(DateTime beginDate, DateTime endDate)
        {
            this.beginDate = beginDate;
            this.endDate = endDate;
        }

        public DateTime beginDate { get; set; }
        public DateTime endDate { get; set; }

        public static List<DateRange> SortDates(List<DateTime> unsortedDates)
        {
            List<DateRange> sortedDates = new List<DateRange> { };

            unsortedDates.Sort();

            for (var i = 0; i < unsortedDates.Count; i += 2)
            {
                DateRange pair = new DateRange(unsortedDates[i], unsortedDates[i + 1]);
                sortedDates.Add(pair);
            }

            return sortedDates;
        }

    }
}
