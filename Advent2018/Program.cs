using System;
using System.Collections.Generic;
using System.IO;
using Advent2018.Solutions;

namespace Advent2018
{
    internal static class Program
    {
        private static void Main(string[] args)
        {    
            //Console.WriteLine($"Answer 1-A: {Day1.GetAnswerA(GetInput($"./Inputs/1.input"))}");
            //Console.WriteLine($"Answer 1-B: {Day1.GetAnswerB(GetInput($"./Inputs/1.input"))}");
            //Console.WriteLine($"Answer 2-A: {Day2.GetAnswerA(GetInput($"./Inputs/2.input"))}");
            //Console.WriteLine($"Answer 2-B: {Day2.GetAnswerB(GetInput($"./Inputs/2.input"))}");
            Console.WriteLine($"Answer 3-A: {Day3.GetAnswerA(GetInput($"./Inputs/3.input"))}");
            Console.WriteLine($"Answer 3-B: {Day3.GetAnswerB(GetInput($"./Inputs/3.input"))}");
            Console.WriteLine($"Answer 4-A: {Day4.GetAnswerA(GetInput($"./Inputs/4.input"))}");
            //Console.WriteLine($"Answer 4-B: {Day4.GetAnswerB(GetInput($"./Inputs/4.input"))}");
        }

        private static IEnumerable<string> GetInput(string path)
        {
            var lines = File.ReadAllLines(path);
            return lines;
        }
    }
}
