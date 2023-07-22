using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VibeGroupAssignment.Classes
{
    public class ImprovedSortingAlghorithm : Alghorithm
    {
        public ImprovedSortingAlghorithm(string[] input, byte length) : base(input, length) { }

        // first loop should go through all allowed combinations
        // take first combination and have a counter 

        public override void FindCombinations()
        {
            foreach (var item in this.AllowedCombinations)
            {
                var posCombo = new List<string>();
                LoopThroughAllowedCombination(item, posCombo, 0, 1);
            }
        }

        public void LoopThroughAllowedCombination(string input, List<string> posCombo, byte index, byte length)
        {
            var subStr = input.Substring(index, length);

            if (this.Input.Contains(subStr))
            {
                posCombo.Add(subStr);

                byte newIndex = (byte)(index + length);
                byte newLength = 1;

                if (newIndex + newLength > 6)
                {
                    var hardCopy = new List<string>();
                    foreach (var item in posCombo)
                    {
                        hardCopy.Add(item);
                    }
                    this.Results.Add(hardCopy);
                }
                else
                {
                    LoopThroughAllowedCombination(input, posCombo, newIndex, newLength);
                }

                posCombo.RemoveAt(posCombo.Count - 1);
            }

            if (index + length + 1 <= 6)
            {
                LoopThroughAllowedCombination(input, posCombo, index, (byte)(length + 1));
            }
        }
    }
}
