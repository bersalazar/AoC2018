using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Advent2018.Solutions;

namespace Advent2018
{
    internal static class Program
    {
        private static void Main(string[] args)
        {    
            var both = new List<string>()
            {
                "b"
            };
            
            both.ForEach(grdt =>
            {
                Console.WriteLine($"Answer 1-A: {Day1.GetAnswerA(GetInput($"./Inputs/{grdt}/1.input"))}");
                Console.WriteLine($"Answer 1-B: {Day1.GetAnswerB(GetInput($"./Inputs/{grdt}/1.input"))}");
                Console.WriteLine($"Answer 2-A: {Day2.GetAnswerA(GetInput($"./Inputs/{grdt}/2.input"))}");
                Console.WriteLine($"Answer 2-B: {Day2.GetAnswerB(GetInput($"./Inputs/{grdt}/2.input"))}");
                Console.WriteLine($"Answer 3-A: {Day3.GetAnswerA(GetInput($"./Inputs/{grdt}/3.input"))}");
                Console.WriteLine($"Answer 3-B: {Day3.GetAnswerB(GetInput($"./Inputs/{grdt}/3.input"))}");
                Console.WriteLine($"Answer 4-A: {Day4.GetAnswerA(GetInput($"./Inputs/{grdt}/4.input"))}");
                Console.WriteLine($"Answer 4-B: {Day4.GetAnswerB(GetInput($"./Inputs/{grdt}/4.input"))}");
                Console.WriteLine($"Answer 5-A: {Day5.GetAnswerA(GetInputString($"./Inputs/{grdt}/5.input"))}");
                //Console.WriteLine($"Answer 5-B: {Day5.GetAnswerB(GetInputString($"./Inputs/{grdt}/5.input"))}");
                Console.WriteLine($"Answer 7-A: {Day7.GetAnswerA(GetInput($"./Inputs/{grdt}/7.input"))}");
                Console.WriteLine($"Answer 7-B: {Day7.GetAnswerB(GetInput($"./Inputs/{grdt}/7.input"))}");
            });
        }

        private static IEnumerable<string> GetInput(string path)
        {
            var lines = File.ReadAllLines(path);
            return lines;
        }
        
        private static string GetInputString(string path)
        {
            var lines = File.ReadAllLines(path).First();
            return lines;
        }        
    }
}
