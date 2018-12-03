using System;
using System.Collections.Generic;
using System.IO;

namespace Advent2018
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            for (var day = 1; day <= 24; day++)
            {
                var path = $"./Inputs/{day}.input";
                var input = GetInput(path);
                Console.WriteLine($"Answer {day.ToString()}-A: {GetAnswer1A(input)}");
                Console.WriteLine($"Answer {day.ToString()}-B: {GetAnswer1B(input)}");
            }
        }

        private static IEnumerable<string> GetInput(string path)
        {
            var lines = File.ReadAllLines(path);
            return lines;
        }

        private static string GetAnswer1A(IEnumerable<string> input)
        {
            var frequencies = 0;
            foreach (var value in input)
            {
                frequencies = frequencies + int.Parse(value);
            }
            return frequencies.ToString();
        }

        private static string GetAnswer1B(IEnumerable<string> input)
        {
            var frequency = 0;
            var frequenciesList = new HashSet<int>();
            var flag = true;

            while (flag) { 
                foreach(var value in input)
                {
                    frequency += int.Parse(value);
                    if (frequenciesList.Contains(frequency))
                    {
                        flag = false;
                        break;
                    }
                    frequenciesList.Add(frequency);
                }
            }
            return frequency.ToString();
        }
    }
}
