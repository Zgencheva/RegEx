using System;
using System.Text.RegularExpressions;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\b[A-Z][a-z]+) ([A-Z][a-z]+)\b";
            Regex regex = new Regex(pattern);

            string input = Console.ReadLine();
            //Console.WriteLine(regex.Match(input).Value);
            var matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                Console.Write($"{match.Value} ");
                //Console.WriteLine(match.Index);
                //Console.WriteLine($"Ime: {match.Groups[1].Value}");
                //Console.WriteLine($"Familiq: {match.Groups[2].Value}");
            }
            Console.WriteLine();
        }
    }
}
