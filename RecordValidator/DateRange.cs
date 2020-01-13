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

    }
}
