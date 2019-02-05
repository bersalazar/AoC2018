using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent2018
{
    internal static class Program
    {
        private static readonly List<string> Participants = new List<string>() {"b"};
        private static readonly IEnumerable<int> AdventOfCodeDays = Enumerable.Range(1, 24);
        private static readonly List<char> Sections = new List<char>() { 'A', 'B' };
        private static SolutionFactory _solutionFactory; 
        
        private static void Main()
        {   
            AdventOfCodeDays.ToList()
            .ForEach(day =>
            {
                Participants.ForEach(participant =>
                {
                    _solutionFactory = new SolutionFactory(participant);
                    Sections.ForEach(section =>
                    {
                        var answer = "";
                        try
                        {
                            answer = GetAnswerFor(day, section);
                        }
                        catch (Exception ex) when (string.Equals(ex.Message, "SolutionNotFoundException"))
                        {
                            answer = "A solution was not found";
                        }
                        catch (FileNotFoundException)
                        {
                            answer = "An input file was not found";
                        }
                        Console.WriteLine($"Participant: {participant}. Day {day}-{section}: {answer}");
                    });
                });    
            });
        }

        private static string GetAnswerFor(int day, char section)
        {
            return _solutionFactory
                .ProcessSolution(day, section)
                .Answer;
        }
        private static string GetInputString(string path)
        {
            var lines = File.ReadAllLines(path).First();
            return lines;
        }        
    }

    
}
