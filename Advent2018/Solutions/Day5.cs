using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2018.Solutions
{
    public static class Day5
    {
        private static bool Test = false;
        public static string TestInput = "dabAcCaCBAcCcaDA";

        public static string GetAnswerA(string input)
        {
            var entryAsList = Test ? TestInput.ToList() : input.ToList();
            return Convert.ToString(FullyReactPolymer(entryAsList).Count);
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
        
        private static List<char> SimpleReactPolymer(List<char> polymer, char unitType)
        {
            var initialSize = polymer.Count;
            for (var i = 0; i < polymer.Count-1; i++)
            {
                if (!AreCharsEqual(polymer[i], unitType)) continue;
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

        public static string GetAnswerB(string input)
        {
            var entryAsList = Test ? TestInput.ToList() : input.ToList();
            var fullyReactedList = new List<int>();
            var uniqueUnitTypes = 
                entryAsList
                    .GroupBy(Char.ToLower)
                    .Select(grp => grp)
                    .ToList();
            
            uniqueUnitTypes.ForEach(ut =>
            {
                var originalEntryList = new List<char>(entryAsList);
                originalEntryList.RemoveAll(eal => char.ToLowerInvariant(eal).Equals(ut.Key));
                var fullyReacted = FullyReactPolymer(originalEntryList);
                fullyReactedList.Add(fullyReacted.Count);
            });
            
            return Convert.ToString(fullyReactedList.Min());
        }
    }
}