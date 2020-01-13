using System;
using System.Collections.Generic;
using System.IO;

namespace RecordValidator
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamReader reader = new StreamReader("C:/Users/alex.patrucco/source/repos/RecordValidator/RecordValidator/CSV_Files/dates.csv");

            var data = reader.ReadLine().Split(',');

            List<DateTime> unsortedDates = new List<DateTime> { };

            foreach (var item in data)
            {
                var splitData = item.Split('/');
                var year = int.Parse(splitData[2]);
                var month = int.Parse(splitData[0]);
                var day = int.Parse(splitData[1]);

                unsortedDates.Add(new DateTime(year, month, day));
            }

            static List<DateRange> SortDates(List<DateTime> unsortedDates)
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

            List<DateRange> sortedDates = SortDates(unsortedDates);

            foreach (var date in sortedDates)
            {
                Console.WriteLine($"Start: {date.beginDate.ToShortDateString()} \t End: {date.endDate.ToShortDateString()}");
            }
        }
    }
}
