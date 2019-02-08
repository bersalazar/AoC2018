using System.Collections.Generic;
using Advent2018.Solutions;
using Xunit;

namespace Advent2018.Tests
{
    public class Solution2BTest
    {
        [Fact]
        public void RunTests()
        {
            var input = new List<string>()
            {
                "abcde",
                "fghij",
                "klmno",
                "pqrst",
                "fguij",
                "axcye",
                "wvxyz"
            };
            
            Assert.Equal("fgij", new Solution2B(input).Answer);
        }
    }
}