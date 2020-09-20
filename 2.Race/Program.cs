using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;

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
                StringBuilder name = new StringBuilder();
                int distance = 0;
                for (int i = 0; i < command.Length; i++)
                {
                    if (char.IsLetter(command[i]))
                    {
                        name.Append(command[i]);
                    }
                    else if (char.IsDigit(command[i]))
                    {
                        distance += int.Parse(command[i].ToString());
                    }
                }
                if (participants.ContainsKey(name.ToString()))
                {
                    participants[name.ToString()] += distance;
                }
            }
            int counter = 1;
            foreach (var pair in participants.OrderByDescending(x => x.Value))
            {
                if (counter == 1)
                {
                    Console.WriteLine($"1st place: {pair.Key}");
                }
                else if (counter == 2)
                {
                    Console.WriteLine($"2nd place: {pair.Key}");
                }
                else if (counter == 3)
                {
                    Console.WriteLine($"3rd place: {pair.Key}");
                }
                else
                {
                    break;
                }
                counter++;
                
            }
        }
    }
}
