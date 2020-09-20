using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _6.ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> emails = new List<string>();
            string pattern = @"(?<=\s)(?<user>[A-Za-z0-9]+[.-]*\w*)*@(?<host>[a-z]+?([.-][a-z]*)*(\.[a-z]{2,}))";

            var matches = Regex.Matches(input, pattern);
            Console.WriteLine(string.Join(Environment.NewLine, matches));
        }
    }
}
