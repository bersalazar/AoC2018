using System.Collections.Generic;

namespace Advent2018.Model
{
    public class Step
    {
        public readonly char Id;
        public bool IsAvailable;
        public List<char> Precedents { get; } = new List<char>();

        public Step(char stepId)
        {
            Id = stepId;
        }
    }
}