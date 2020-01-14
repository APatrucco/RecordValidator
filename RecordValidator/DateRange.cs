using System;

namespace RecordValidator
{
    public class DateRange
    {
        public DateRange()
        {

        }
        public DateRange(DateTime beginDate, DateTime endDate)
        {
            BeginDate = beginDate;
            EndDate = endDate;
        }

        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
