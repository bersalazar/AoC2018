using System.Collections.Generic;
using Advent2018.Solutions;
using Xunit;

namespace Advent2018.Tests
{
    public class Solution2ATest
    {
        [Fact]
        public void RunTests()
        {
            var input = new List<string>()
            {
                "abcdef",
                "bababc",
                "abbcde",
                "abcccd",
                "aabcdd",
                "abcdee",
                "ababab"
            };
            
            Assert.Equal("12", new Solution2A(input).Answer);
        }
    }
}