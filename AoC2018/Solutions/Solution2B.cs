using System.Collections.Generic;
using System.Linq;
using System.Text;
using Advent2018.Model;

namespace Advent2018.Solutions
{
    public class Solution2B : Solution
    {
        public Solution2B(IEnumerable<string> input)
        {
            var enumerable = input.ToList();
            var list1 = enumerable;
            var list2 = enumerable;
            var differenceIndex = 0;
            var keyword = "";

            foreach (var id1 in list1)
            {
                foreach (var id2 in list2)
                {
                    if (id1 == id2) break;
                    var count = 0;
                    for (var i = 0; i < id1.Length; i++)
                    {
                        var charsAreEqual = char.ToUpperInvariant(id1[i]) == char.ToUpperInvariant(id2[i]);
                        if (charsAreEqual || count >= 2) continue;
                        count++;
                        differenceIndex = i;
                    }

                    if (count != 1) continue;
                    var sb = new StringBuilder(id1);
                    sb.Remove(differenceIndex, 1);
                    keyword = sb.ToString();
                }
            }
            Answer = keyword;
        }
    }
}