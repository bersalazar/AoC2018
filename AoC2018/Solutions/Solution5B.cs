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
                var fullyReacted = Library.FullyReactPolymer(originalEntryList);
                fullyReactedList.Add(fullyReacted.Count);
            });
            
            Answer = Convert.ToString(fullyReactedList.Min());
        }
    }
}