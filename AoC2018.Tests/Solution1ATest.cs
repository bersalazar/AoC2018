using System.Collections.Generic;
using Advent2018.Solutions;
using Xunit;

namespace Advent2018.Tests
{
    public class Solution1ATest
    
    {
        [Fact]
        public void RunTests()
        {
            var input = new List<string>()
            {
                "+1",
                "-2",
                "+3",
                "+1"
            };
            
            Assert.Equal("3", new Solution1A(input).Answer);
        }
    }
}