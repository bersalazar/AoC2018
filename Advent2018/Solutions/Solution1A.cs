using System.Collections.Generic;
using Advent2018.Model;

namespace Advent2018.Solutions
{
    public class Solution1A : Solution
    {
        public Solution1A(IEnumerable<string> input)
        {
            var frequencies = 0;
            foreach (var value in input)
            {
                frequencies = frequencies + int.Parse(value);
            }
            Answer = frequencies.ToString();
        }
    }
}