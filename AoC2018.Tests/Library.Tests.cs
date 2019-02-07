using System.Collections.Generic;
using System.Linq;
using Advent2018.Model;
using Xunit;
using static Advent2018.Solutions.Library;

namespace Advent2018.Tests
{
    public class LibraryTests
    {
        [Fact]
        public void RunTest()
        {
            // AreCharsEqual
            Assert.True(AreCharsEqual('A', 'A'));
            Assert.True(AreCharsEqual('A', 'a'));
            Assert.False(AreCharsEqual('A', 'b'));
            Assert.False(AreCharsEqual('A', 'B'));
            
            
            // FullyReactPolymer
            var polymerToReact = "dabAcCaCBAcCcaDA".ToList();
            Assert.Equal("dabCBAcaDA", FullyReactPolymer(polymerToReact));
            
            //
            var stepsList = new Dictionary<char, Step>
            {
                {'A', new Step('A')},
                { 'B', new Step('B') }
            };
            
            var resultList = new List<char>
            {
                'A'
            };
        }
    }
}