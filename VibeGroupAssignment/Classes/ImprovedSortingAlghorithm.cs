using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VibeGroupAssignment.Classes
{
    public class ImprovedSortingAlghorithm
    {
        public string[] Input { get; }
        public HashSet<string> AllowedCombinations { get; }
        public List<List<string>> Results { get; set; } = new List<List<string>>();

        public ImprovedSortingAlghorithm(string[] input)
        {
            this.AllowedCombinations = input.Where(x => x.Length == 6).Distinct().ToHashSet();
            this.Input = input.Where(x => x.Length < 6).Distinct().ToArray();
        }

        // first loop should go through all allowed combinations
        // take first combination and have a counter 

        public void FindCombinations()
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

        public void showResults()
        {
            Console.WriteLine();
            if (this.Results.Count > 0)
            {
                foreach (var res in this.Results)
                {
                    Console.WriteLine($"{String.Join("+", res)} = {String.Join("", res)}");
                }
                Console.WriteLine($"There have been {this.Results.Count} results");
            }
            else
            {
                Console.WriteLine("No results found");
            }
        }



    }
}
