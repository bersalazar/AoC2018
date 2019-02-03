using System.Collections.Generic;
using System.Linq;
using Advent2018.Model;

namespace Advent2018.Solutions
{
    public class Solution2A : Solution
    {
        public Solution2A(IEnumerable<string> input)
        {
            var wordMap = new Dictionary<string, Dictionary<char, int>>();
            
            foreach (var item in input)
            {
                wordMap.Add(item, new Dictionary<char, int>());
                var valueAsCharArray = item.ToCharArray();
                foreach (var character in valueAsCharArray)
                {
                    var charCount = valueAsCharArray.Count(value => value == character);
                    if (charCount == 3 || charCount == 2)
                    {
                        if (wordMap[item].ContainsKey(character))
                        {
                            wordMap[item][character] = charCount;
                            continue;
                        }
                        wordMap[item].Add(character, charCount);
                    }
                }
            }

            var twice = 0;
            var thrice = 0;
            foreach (var word in wordMap)
            {
                var twiceBool = false;
                var thriceBool = false;

                foreach (var letter in word.Value)
                {
                    if (letter.Value == 3) thriceBool = true;
                    if (letter.Value == 2) twiceBool = true;
                }

                if (thriceBool) thrice++;
                if (twiceBool) twice++;
            }

            var checksum = thrice * twice;
            Answer = checksum.ToString();
        }
    }
}