using System.Collections.Generic;
using Advent2018.Model;

namespace Advent2018.Solutions
{
    public class Solution3B : Solution
    {
        public Solution3B(IEnumerable<string> input)
        {
            var matrix = new string[1000, 1000];
            var claims = new List<Claim>();
            
            foreach (var entry in input)
            {
                claims.Add(new Claim(entry));
            }

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

            foreach (var claim in claims)
            {
                //Height
                for (int i = claim.PositionY; i < claim.PositionY + claim.Height; i++)
                {
                    //Width
                    for (int j = claim.PositionX; j < claim.PositionX + claim.Width; j++)
                    {
                        if (matrix[i,j] == "X")
                        {
                            claim.Touched = true;
                        }
                    }
                }
            }

            Answer = claims.Find(claim => !claim.Touched).Id;
        }
    }
}