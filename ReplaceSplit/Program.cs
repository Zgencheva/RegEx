using System;
using System.Text.RegularExpressions;

namespace ReplaceSplit
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "<div> text </div> <h1>123</h1> tova ne e v html";
            Console.WriteLine(Regex.Replace(text, @"<.*>.*<\/.*>", "*****"));
            
        }
    }
}
