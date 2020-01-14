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

            List<DateTime> unsortedDates = new List<DateTime>();

            try
            {
                foreach (var item in data)
                {
                    if (DateTime.TryParse(item, out DateTime isaDate))
                        unsortedDates.Add(DateTime.Parse(item));
                    else
                        Console.WriteLine($"Unable to convert value \"{item.Trim(' ')}\" to DateTime.");
                }

                List<DateRange> sortedDates = FormatDates.SortDates(unsortedDates);

                foreach (var date in sortedDates)
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
