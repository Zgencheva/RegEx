using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string validation = @">>(?<furniture>[A-Za-z\s]+)<<(?<price>\d+(\.?\d*?))!(?<quantity>\d+)";
            double totalMoney = 0.0;
            List<string> furnitures = new List<string>();
            bool isThereValidFurniture = false;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Purchase")
                {
                    break;
                }
                Regex regex = new Regex(validation);
                if (regex.IsMatch(input))
                {
                    isThereValidFurniture = true;
                    var matches = regex.Match(input);
                    string furniture = matches.Groups["furniture"].Value;
                    double price = double.Parse(matches.Groups["price"].Value);
                    int quantity = int.Parse(matches.Groups["quantity"].Value);
                    totalMoney += price * quantity;
                    furnitures.Add(furniture);
                }
            }
            Console.WriteLine("Bought furniture:");
            if (isThereValidFurniture)
            {
                
                Console.WriteLine(string.Join(Environment.NewLine, furnitures));
                

            }
            Console.WriteLine($"Total money spend: {totalMoney:f2}");

        }
    }
}
