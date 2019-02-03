using System.Collections.Generic;

namespace Advent2018.Solutions
{
    public class Solution1A : Solution
    {
        private readonly string _answer;

        public Solution1A(IEnumerable<string> input)
        {
            var frequencies = 0;
            foreach (var value in input)
            {
                frequencies = frequencies + int.Parse(value);
            }
            _answer = frequencies.ToString();
        }

        public override string GetAnswer()
        {
            return _answer;
        }
    }
}