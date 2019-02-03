using System;
using Advent2018.Solutions;

namespace Advent2018
{
    public class SolutionFactory
    {
        private readonly Solution _solution;
        public SolutionFactory(string participant, int day, char section)
        {
            var input = (new SolutionInput(participant, day)).ReadInput();
            var daySection = $"{day}{section}";
            switch (daySection)
            {
                case "1A":
                    _solution = new Solution1A(input);
                    break;
                case "1B":
                    _solution = new Solution1B(input);
                    break;
                case "2A":
                case "2B":
                case "3A":
                case "3B":
                case "4A":
                case "4B":
                case "5A":
                case "5B":
                default:
                    throw new ApplicationException($"An answer has not been implemented for {daySection}");
            }
        }
        public string GetSolution()
        {
            return _solution.GetAnswer();
        }
    }
}