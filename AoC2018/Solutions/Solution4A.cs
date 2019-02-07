using System;
using System.Collections.Generic;
using System.Linq;
using Advent2018.Model;

namespace Advent2018.Solutions
{
    public class Solution4A : Solution
    {
        public Solution4A(IEnumerable<string> input)
        {
            var answer = Library.ProcessEntries(input.ToList());
            var sleepyGuard = int.Parse((string) answer["sleepyGuard"]);
            var minuteWhereGuardSleptMost = int.Parse((string) answer["minuteWhereGuardSleptMost"]);
            
            Answer = Convert.ToString(sleepyGuard * minuteWhereGuardSleptMost);
        }
    }
}