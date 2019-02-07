using System;
using Advent2018.Model;
using Advent2018.Solutions;

namespace Advent2018
{
    public class SolutionFactory
    {
        private readonly string _participant;

        public SolutionFactory(string participant)
        {
            _participant = participant;
        }

        public Solution ProcessSolution(int day, char section)
        {
            var input = new SolutionInput(_participant, day).ReadInput();
            var daySection = $"{day}{section}";
            switch (daySection)
            {
                case "1A":
                    return new Solution1A(input);
                case "1B":
                    return new Solution1B(input);
                case "2A":
                    return new Solution2A(input);
                case "2B":
                    return new Solution2B(input);
                case "3A":
                    return new Solution3A(input);
                case "3B":
                    return new Solution3B(input);
                case "4A":
                    return new Solution4A(input);
                case "4B":
                    return new Solution4B(input);
                case "5A":
                    return new Solution5A(input);
                case "5B":
                    return new Solution5B(input);
                case "7A":
                    return new Solution7A(input);
                default:
                    throw new Exception($"SolutionNotFoundException");
            }
        }
    }
}