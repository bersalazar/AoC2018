using System.Collections.Generic;
using System.Linq;
using System.Text;
using Advent2018.Model;

namespace Advent2018.Solutions
{
    public class Solution7A : Solution
    {
        public Solution7A(IEnumerable<string> input)
        {
            var stepsList = new Dictionary<char, Step>(); 
            var allStepsThatHavePrecedent = new List<char>();
            
            // Build each object's precedence list
            foreach (var instruction in input)
            {
                var precedent = instruction[5];
                var subsequent = instruction[36];
                
                allStepsThatHavePrecedent.Add(precedent);
                
                var step = new Step(subsequent);
                step.Precedents.Add(precedent);

                if (!stepsList.ContainsKey(step.Id))
                {
                    stepsList.Add(step.Id, step);
                    continue;
                }
                stepsList[step.Id].Precedents.Add(precedent);
            }

            // Create a list of steps that have no precedence
            var stepsWithNoPrecedence = 
                allStepsThatHavePrecedent
                    .FindAll(step => stepsList.Keys.All(s => s != step));
            
            stepsWithNoPrecedence.Sort();
            
            var uniqueStepsWithNoPrecedence = new HashSet<char>(stepsWithNoPrecedence).ToList();
            
            // Add steps with no precedence to the stepsList
            uniqueStepsWithNoPrecedence.ForEach(initStep => stepsList.Add(initStep, new Step(initStep)));
            
            // Grab the unique initial step
            var initialStep = stepsWithNoPrecedence.First();

            // Add the initial step to the ordered results list
            var resultList = new List<char> {initialStep};

            var count = resultList.Count;
            var totalSteps = stepsList.Keys.Count;
            while (count < totalSteps)
            {
                var nextStep = Library.GetNextStep(stepsList, resultList);
                if (!resultList.Contains(nextStep))
                {
                    resultList.Add(nextStep);
                    stepsList.Remove(nextStep);
                    count++;
                }
            }
            
            var constructedString = new StringBuilder();
            resultList.ForEach(character => constructedString.Append(character));
            Answer = constructedString.ToString();
        }
    }
}