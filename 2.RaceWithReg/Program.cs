using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> participants = new Dictionary<string, int>();
            string[] participantsList = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string namePattern = "[A-Za-z]";
            string distancePattern = @"\d";
            for (int i = 0; i < participantsList.Length; i++)
            {
                participants.Add(participantsList[i], 0);
            }
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end of race")
                {
                    break;
                }
                var nameMatch = Regex.Matches(command, namePattern);
                var distanceMatch = Regex.Matches(command, distancePattern);
                string name = string.Concat(nameMatch);
                int sum = distanceMatch.Select(x => int.Parse(x.Value)).Sum();
                if (participants.ContainsKey(name))
                {
                    participants[name] += sum;
                }
            }
            var sorted = participants.OrderByDescending(x => x.Value).Select(x => x.Key).Take(3).ToList();

            Console.WriteLine($"1st place: {sorted[0]}");
            Console.WriteLine($"2nd place: {sorted[1]}");
            Console.WriteLine($"3rd place: {sorted[2]}");
        }
    }
}
