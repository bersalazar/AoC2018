using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2018.Solutions
{
    public static class Day3
    {
        public static string GetAnswerA(IEnumerable<string> input)
        {

            var matrix = new string[1000, 1000];
            var entries = new List<string>
            {
                "#1 @ 1,3: 4x4",
                "#2 @ 3,1: 4x4",
                "#3 @ 5,5: 2x2"
            };

            var claims = new List<Claim>();
            
            foreach (var entry in input)
            {
               claims.Add(new Claim(entry));
            }

            var inches = 0;
            
            foreach (var claim in claims)
            {
                //Height
                for (int i = claim.PositionY; i < claim.PositionY + claim.Height; i++)
                {
                    //Width
                    for (int j = claim.PositionX; j < claim.PositionX + claim.Width; j++)
                    {
                        if (!string.IsNullOrEmpty(matrix[i, j]))
                        {
                            matrix[i, j] = "X";
                        }
                        else
                        {
                            matrix[i, j] = claim.Id;                           
                        }
                    }
                }
            }

            foreach (var element in matrix)
            {
                if (element == "X") inches++;
            }
            
            return inches.ToString();
        }
        
        public static string GetAnswerB(IEnumerable<string> input)
        {

            var matrix = new string[1000, 1000];
            var entries = new List<string>
            {
                "#1 @ 1,3: 4x4",
                "#2 @ 3,1: 4x4",
                "#3 @ 5,5: 2x2"
            };

            var claims = new List<Claim>();
            
            foreach (var entry in input)
            {
               claims.Add(new Claim(entry));
            }

            var inches = 0;
            var untouchedClaimId = "";
            
            foreach (var claim in claims)
            {
                //Height
                for (int i = claim.PositionY; i < claim.PositionY + claim.Height; i++)
                {
                    //Width
                    for (int j = claim.PositionX; j < claim.PositionX + claim.Width; j++)
                    {
                        if (!string.IsNullOrEmpty(matrix[i, j]))
                        {
                            matrix[i, j] = "X";
                            claim.Touched = true;
                        }
                        else
                        {
                            matrix[i, j] = claim.Id;                           
                        }
                    }
                }

            }

            var untouchedClaim = "";
            foreach (var claim in claims)
            {
                untouchedClaim = !claim.Touched ? claim.Id : "Not found";
            }

            return untouchedClaim;
        }
    }
}