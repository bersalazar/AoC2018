using System;
using System.Collections.Generic;
using System.Linq;
using Advent2018.Model;

namespace Advent2018.Solutions
{
    public class Solution5A : Solution
    {
        public Solution5A(IEnumerable<string> input)
        {
            var enumerable = input.First().ToList();
            Answer = Convert.ToString(Library.FullyReactPolymer(enumerable).Count);
        }
    }
}