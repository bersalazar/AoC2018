using System;
using System.Collections.Generic;
using System.Linq;
using Advent2018.Model;

namespace Advent2018.Solutions
{
    public class Solution5B : Solution
    {
        public Solution5B(IEnumerable<string> input)
        {
            var entryAsList = input.First().ToList();
            var fullyReactedList = new List<int>();
            var uniqueUnitTypes = 
                entryAsList
                    .GroupBy(char.ToLower)
                    .Select(grp => grp)
                    .ToList();
            
            uniqueUnitTypes.ForEach(ut =>
            {
                var originalEntryList = new List<char>(entryAsList);
                originalEntryList.RemoveAll(eal => char.ToLowerInvariant(eal).Equals(ut.Key));
                var fullyReacted = FullyReactPolymer(originalEntryList);
                fullyReactedList.Add(fullyReacted.Count);
            });
            
            Answer = Convert.ToString(fullyReactedList.Min());
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