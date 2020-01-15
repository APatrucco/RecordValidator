using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace RecordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("C:/Users/alex.patrucco/source/repos/RecordValidator/RecordValidator/CSV_Files/dates.csv");

            var data = reader.ReadLine().Split(',');

            List<DateTime> unsortedDates = new List<DateTime>();

            try
            {
                foreach (string item in data)
                {
                    DateTime.TryParse(item, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime returnValue);

                    if (returnValue.CompareTo(DateTime.MinValue) > 0)
                        unsortedDates.Add(returnValue);
                    else
                        Console.WriteLine($"Unable to convert value \"{item.Trim(' ')}\" to DateTime.");
                }

                List<DateTime> sortedDates = unsortedDates.OrderBy(x => x).ToList();

                List<DateRange> sortedDateRanges = FormatDates.Converter(sortedDates);

                foreach (var date in sortedDateRanges)
                {
                    Console.WriteLine($"Start: {date.BeginDate.ToShortDateString()} \t End: {date.EndDate.ToShortDateString()}");
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"CSV file contains invalid entries. \n\n\t Error: {e}");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"CSV file must contain an even number of entries. \n\n\t Error: {e}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
