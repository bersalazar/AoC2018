using System;
using System.Collections.Generic;
using System.IO;

namespace Advent2018
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var day = 1; day <= 24; day++)
            {
                var path = $"./Inputs/{day}.input";
                var input = GetInput(path);
                Console.WriteLine($"Answer {day.ToString()}-A: {GetAnswer1A(input)}");
                Console.WriteLine($"Answer {day.ToString()}-B: {GetAnswer1B(input)}");
            }
        }

        private static IEnumerable<String> GetInput(string path)
        {
            var lines = File.ReadAllLines(path);
            return lines;
        }

        private static String GetAnswer1A(IEnumerable<String> input)
        {
            var frequencies = 0;
            foreach (String value in input)
            {
                frequencies = frequencies + Int32.Parse(value);
            }
            return frequencies.ToString();
        }

        private static String GetAnswer1B(IEnumerable<String> input)
        {
            var frequency = 0;
            var frecuenciesList = new HashSet<int>();
            var flag = true;

            while (flag) { 
                foreach(var value in input)
                {
                    frequency += Int32.Parse(value);
                    if (frecuenciesList.Contains(frequency))
                    {
                        Console.WriteLine($"First frecuency reached twice is: {frequency}");
                        flag = false;
                        break;
                    }
                    frecuenciesList.Add(frequency);
                }
            }
            return frequency.ToString();

        }
    }
}
