using System.Collections.Generic;
using Advent2018.Solutions;
using Xunit;

namespace Advent2018.Tests
{
    public class Solution5BTest
    {
        [Fact]
        public void RunTests()
        {
            var input = new List<string>()
            {
                "dabAcCaCBAcCcaDA"
            };
            Assert.Equal("4", new Solution5B(input).Answer);
        }
    }
}