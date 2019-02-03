using System.Collections.Generic;

namespace Advent2018.Solutions
{
    public class Step
    {
        public char Id;
        public int Time;
        public bool IsAvailable;
        public List<char> Precedents { get; } = new List<char>();

        public Step(char stepId, bool isComplete)
        {
            Id = stepId;
        }

        public Step(char stepId)
        {
            Id = stepId;
            Time = 60 + char.ToUpper(Id) - 64; 
        }
    }
}