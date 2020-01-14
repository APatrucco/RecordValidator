using System;
using System.Collections.Generic;

namespace RecordValidator
{
    class FormatDates
    {
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
