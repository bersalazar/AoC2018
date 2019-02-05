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
            Answer = Convert.ToString(FullyReactPolymer(enumerable).Count);
        }
        private static List<char> FullyReactPolymer(List<char> polymer)
        {
            var initialSize = polymer.Count;
            for (var i = 0; i < polymer.Count-1; i++)
            {
                if (!AreCharsEqual(polymer[i + 1], polymer[i])) continue;
                if (char.IsLower(polymer[i]) && char.IsUpper(polymer[i + 1]))
                {
                    polymer.RemoveAt(i);
                    polymer.RemoveAt(i);
                }
                else if (char.IsUpper(polymer[i]) && char.IsLower(polymer[i + 1]))
                {
                    polymer.RemoveAt(i);
                    polymer.RemoveAt(i);
                }
            }

            if (polymer.Count < initialSize)
            {
                FullyReactPolymer(polymer);                
            }
            
            return polymer;
        }
        private static bool AreCharsEqual(char s1, char s2)
        {
            return char.ToUpperInvariant(s1).Equals(char.ToUpperInvariant(s2));
        }
    }
}