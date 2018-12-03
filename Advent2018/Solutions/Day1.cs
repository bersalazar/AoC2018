using System.Collections.Generic;

namespace Advent2018.Solutions
{
    public class Day1
    {
        public static string GetAnswerA(IEnumerable<string> input)
        {
            var frequencies = 0;
            foreach (var value in input)
            {
                frequencies = frequencies + int.Parse(value);
            }
            return frequencies.ToString();
        }

        public static string GetAnswerB(IEnumerable<string> input)
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