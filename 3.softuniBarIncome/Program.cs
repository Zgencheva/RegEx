using System;
using System.Text.RegularExpressions;

namespace _3.softuniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string regexValidation = @"\%(?<customer>[A-Z][a-z]+)\%[^|$%.]*\<(?<product>\w+)\>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>\d+([.]\d+)?)\$";
            double totalIncome = 0;
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "end of shift")
                {
                    break;
                }
                
                Match match = Regex.Match(command, regexValidation);
                if (match.Success)
                {
                    string customer = match.Groups["customer"].ToString();
                    string product = match.Groups["product"].ToString();
                    int cuantity = int.Parse(match.Groups["count"].ToString());
                    double price = double.Parse(match.Groups["price"].ToString());
                    totalIncome += cuantity * price;
                    Console.WriteLine($"{customer}: {product} - {cuantity * price:f2}");

                }
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
