using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2.PhoneNums
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = @"(\+359)(?<separator>[\s-])(2)\k<separator>(\d{3})\k<separator>()\d{4}\b";
            var phones = Console.ReadLine();
            var phoneMatches = Regex.Matches(phones, regex);
            var matchedPhones = phoneMatches.Cast<Match>()
                .Select(a => a.Value.Trim())
                .ToArray();

            Console.WriteLine(string.Join(", ", matchedPhones));
        }
    }
}
