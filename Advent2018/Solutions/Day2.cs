using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent2018.Solutions
{
    public class Day2
    {
        public static string GetAnswerA(IEnumerable<string> input)
        {
            var word_map = new Dictionary<string, Dictionary<char, int>>();
            
            foreach (var item in input)
            {
                word_map.Add(item, new Dictionary<char, int>());
                var valueAsCharArray = item.ToCharArray();
                foreach (var character in valueAsCharArray)
                {
                    var charCount = valueAsCharArray.Count(value => value == character);
                    if (charCount == 3 || charCount == 2)
                    {
                        if (word_map[item].ContainsKey(character))
                        {
                            word_map[item][character] = charCount;
                            continue;
                        }
                        word_map[item].Add(character, charCount);
                    }
                }
            }

            var twice = 0;
            var thrice = 0;
            foreach (var word in word_map)
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

            var checksum = (thrice * twice).ToString();
            return checksum;
        }

        public static string GetAnswerB(IEnumerable<string> input)
        {
            var list1 = input;
            var list2 = input;
            var differenceIndex = 0;
            var keyword = "";

            foreach (var id1 in list1)
            {
                foreach (var id2 in list2)
                {
                    if (id1 == id2) break;
                    var count = 0;
                    for (int i = 0; i < id1.Length; i++)
                    {
                        var charsAreEqual = char.ToUpperInvariant(id1[i]) == char.ToUpperInvariant(id2[i]);
                        if (!charsAreEqual && count < 2)
                        {
                            count++;
                            differenceIndex = i;
                        }
                    }

                    if (count == 1)
                    {
                        StringBuilder sb = new StringBuilder(id1);
                        sb.Remove(differenceIndex, 1);
                        keyword = sb.ToString();
                    }
                }
            }

            return keyword;
        }
    }
}