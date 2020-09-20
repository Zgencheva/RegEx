using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _5.NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<double>> demons = new SortedDictionary<string, List<double>>();
            string[] input = Console.ReadLine().Split(new string[] {",", ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string regexHelth = @"[^\d\/\*\-\+\.]";
            for (int i = 0; i < input.Length; i++)
            {
                string currentDemon = input[i].Trim();
                var matches = Regex.Matches(currentDemon, regexHelth).ToArray();
                int health = 0;
                foreach (Match match in matches)
                {
                    var currentNum = match.Value.ToCharArray();
                    foreach (var item in currentNum)
                    {
                        health += (int)item;
                    }
                }
                string regexNum = @"(?<num>[\+\-]?\d*\.?\d+)";
                var numMatches = Regex.Matches(currentDemon, regexNum);
                double damage = 0;
                foreach (Match numMatch in numMatches)
                {
                    damage += double.Parse(numMatch.Value);

                }
                for (int j = 0; j < currentDemon.Length; j++)
                {
                    if (currentDemon[j] == '/')
                    {
                        damage /= 2;
                    }
                    else if (currentDemon[j] == '*')
                    {
                        damage *= 2;
                    }
                }
                demons.Add(currentDemon, new List<double>());
                demons[currentDemon].Add(health);
                demons[currentDemon].Add(damage);
            }

            foreach (var pair in demons)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value[0]} health, {pair.Value[1]:f2} damage");
            }
        }
    }
}
