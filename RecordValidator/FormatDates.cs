using System;
using System.Collections.Generic;

namespace RecordValidator
{
    class FormatDates
    { 
        public static List<DateRange> Converter(List<DateTime> sortedDates)
        {
            List<DateRange> returnValue = new List<DateRange>();

            for (var i = 0; i < sortedDates.Count; i += 2)
            {
                DateRange pair = new DateRange(sortedDates[i], sortedDates[i + 1]);
                returnValue.Add(pair);
            }

            return returnValue;
        }
    }
}
