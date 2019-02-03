using System.Collections.Generic;

namespace Advent2018.Solutions
{
    public class Solution1B : Solution
    {
        private readonly string _answer;

        public Solution1B(IEnumerable<string> input)
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
            _answer = frequency.ToString();
        }

        public override string GetAnswer()
        {
            return _answer;
        }
    }
}