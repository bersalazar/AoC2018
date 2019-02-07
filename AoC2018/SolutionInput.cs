using System;
using System.Collections.Generic;
using System.IO;

namespace Advent2018
{
    public class SolutionInput
    {
        private readonly string _participant;
        private readonly int _day;
        private const string DataInputFileExtension = ".input";
        private const string DataInputPath = "./Inputs/";

        public SolutionInput(string participant, int day)
        {
            _participant = participant;
            _day = day;
        }

        public IEnumerable<string> ReadInput()
        {
            var filePath = $"{DataInputPath}{_participant}/{_day}{DataInputFileExtension}";
            return File.ReadAllLines(filePath);
        }
    }
}