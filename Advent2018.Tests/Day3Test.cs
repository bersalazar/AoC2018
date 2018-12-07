using System.Collections.Generic;
using Advent2018.Solutions;
using Xunit;

namespace Advent2018.Tests
{
    public class Day3Test
    {
        [Fact]
        public void RunTests()
        {
            var input = new List<string>()
            {
                "#1 @ 1,3: 4x4",
                "#2 @ 3,1: 4x4",
                "#3 @ 5,5: 2x2"
            };
            
            Assert.Equal("240", Day3.GetAnswerA(input));
            Assert.Equal("4455", Day3.GetAnswerB(input));
        }
    }
}