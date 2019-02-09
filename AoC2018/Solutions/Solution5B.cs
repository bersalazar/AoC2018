using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                var polymer = string.Join("", entryAsList.ToArray());
                var polymerWithUnitRemoved = polymer
                    .Replace(ut.Key.ToString(), "")
                    .Replace(char.ToUpperInvariant(ut.Key).ToString(), "");
                
                var fullyReacted = Library.FullyReactPolymer(polymerWithUnitRemoved.ToList());
                fullyReactedList.Add(fullyReacted.Count);
            });
            
            Answer = Convert.ToString(fullyReactedList.Min());
        }
    }
}