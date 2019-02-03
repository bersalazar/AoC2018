using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent2018.Solutions
{
    public class Day7
    {
        private const bool IsNotComplete = false;
        private const bool IsComplete = true;
        
        public static string GetAnswerA(IEnumerable<string> input)
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
                var nextStep = GetNextStep(stepsList, resultList);
                if (!resultList.Contains(nextStep))
                {
                    resultList.Add(nextStep);
                    stepsList.Remove(nextStep);
                    count++;
                }
            }
            
            var constructedString = new StringBuilder();
            resultList.ForEach(character => constructedString.Append(character));
            return constructedString.ToString();
        }

        private static char GetNextStep(Dictionary<char, Step> stepsList, List<char> resultList)
        {
            foreach (var step in stepsList.Keys)
            {
                var allPrecedentsAreComplete = stepsList[step].Precedents.TrueForAll(p =>
                {
                    try
                    {
                        return p == resultList.Find(r => r == p);
                    }
                    catch
                    {
                        return false;
                    }
                });

                if (allPrecedentsAreComplete)
                {
                    stepsList[step].IsAvailable = true;
                }
            }
            
            // Sort alphabetically the available steps
            var availableSteps = stepsList.Keys.Where(s => stepsList[s].IsAvailable).ToList();
            availableSteps.Sort();

            // remove values that were already in the result list
            foreach (var result in resultList)
            {
                availableSteps.Remove(result);
            }
            
            return availableSteps.First();
        }

        public static string GetAnswerB(IEnumerable<string> input)
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
                var nextStep = GetNextStep(stepsList, resultList);
                if (!resultList.Contains(nextStep))
                {
                    resultList.Add(nextStep);
                    stepsList.Remove(nextStep);
                    count++;
                }
            }
            
            var constructedString = new StringBuilder();
            resultList.ForEach(character => constructedString.Append(character));
            return constructedString.ToString();
        }
    }
}