using System;
using System.Text.RegularExpressions;

namespace _2.Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = @"\b(?<day>\d{2})(?<sep>[-.\/])(?<month>[A-Z][a-z]{2})\k<sep>(?<year>\d{4})\b";
            var datesStrings = Console.ReadLine();
            var dates = Regex.Matches(datesStrings, regex);
            //string input = Console.ReadLine();
            //Regex regex = new Regex(pattern);
            //MatchCollection dates = Regex.Matches(Console.ReadLine(), @"\b(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\2(?<year>\d{4})\b");

            foreach (Match date in dates)
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }

        }
    }
}
