using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using Advent2018.Solutions;

namespace Advent2018
{
    internal static class Program
    {
        private static readonly List<string> Participants = new List<string>() {"b"};
        private static readonly IEnumerable<int> AdventOfCodeDays = Enumerable.Range(1, 24);
        private static readonly List<char> Sections = new List<char>() { 'A', 'B' };
        private static void Main()
        {   
            AdventOfCodeDays.ToList()
            .ForEach(day =>
            {
                Participants.ForEach(participant =>
                {
                    Sections.ForEach(section =>
                    {
                        GetAnswerFor(participant, day, section);
                        Console.WriteLine($"Day {day}-{section}: {GetAnswerFor(participant, day, section)}");
                    });
                });    
            });
        }

        private static string GetAnswerFor(string participant, int day, char section)
        {
            return new SolutionFactory(participant, day, section).GetSolution();
        }
        private static string GetInputString(string path)
        {
            var lines = File.ReadAllLines(path).First();
            return lines;
        }        
    }

    
}
