
using System;
using System.Collections.Generic;
using System.Linq;
using Advent2018.Model;

namespace Advent2018.Solutions
{
    public class Solution4B : Solution
    {
        public Solution4B(IEnumerable<string> input)
        {
            //ID * highest sleep minute
            var answer = Library.ProcessEntries(input.ToList());
            var mostFrequentMinute = int.Parse((string) answer["mostFrequentMinute"]);
            var mostFrequentMinuteGuardId = int.Parse((string) answer["mostFrequentMinuteGuardId"]);

            Answer = Convert.ToString(mostFrequentMinuteGuardId * mostFrequentMinute);
        }
    }
}