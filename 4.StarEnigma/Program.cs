using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _4.StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> AttackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                StringBuilder output = new StringBuilder();
                string regexMatch = "[SsTtAaRr]";
                MatchCollection matches = Regex.Matches(input, regexMatch);
                for (int j = 0; j < input.Length; j++)
                {
                    output.Append((char)(input[j] - matches.Count));
                }
                string code = output.ToString();
                string reg = @"@(?<planet>[A-Za-z]+)[^\@\-\!\:\>]*?\:(?<population>\d+)[^\@\-\!\:\>]*?\!(?<attack>[AD])\![^\@\-\!\:\>]*?\-\>(?<soldiers>\d+)";
                Match match = Regex.Match(code, reg);
                if (match.Success)
                {
                    if (match.Groups["attack"].ToString() == "A")
                    {
                        AttackedPlanets.Add(match.Groups["planet"].ToString());
                    }
                    else if (match.Groups["attack"].ToString() == "D")
                    {
                        destroyedPlanets.Add(match.Groups["planet"].ToString());
                    }
                }
            }
            if (AttackedPlanets.Count == 0)
            {
                Console.WriteLine("Attacked planets: 0");
            }
            else
            {
                Console.WriteLine($"Attacked planets: {AttackedPlanets.Count}");
                foreach (var item in AttackedPlanets.OrderBy(x=> x))
                {
                    Console.WriteLine($"-> {item}");
                }
            }
            if (destroyedPlanets.Count == 0)
            {
                Console.WriteLine("Destroyed planets: 0");
            }
            else
            {
                Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
                foreach (var item in destroyedPlanets.OrderBy(x=> x))
                {
                    Console.WriteLine($"-> {item}");
                }
            }

        }
    }
}
