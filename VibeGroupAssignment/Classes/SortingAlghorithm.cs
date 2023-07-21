using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibeGroupAssignment.Classes
{
    public class SortingAlghorithm
    {
        public string[] Input { get; }
        public HashSet<string> AllowedCombinations { get; }
        public List<List<string>> Results { get; set; } = new List<List<string>>();

        public SortingAlghorithm(string[] input)
        {
            this.AllowedCombinations = input.Where(x => x.Length == 6).Distinct().ToHashSet();
            this.Input = input.Where(x => x.Length < 6).ToArray();
        }

        public void FindCombinations()
        {
            for (int i = 0; i < Input.Length; i++)
            {
                Console.WriteLine($"{Input[i]} with index around {i}");
                var localResult = new Dictionary<int, string>();
                localResult.Add(i, Input[i]);
                byte count = (byte)(6 - Input[i].Length);
                LoopThroughLocalInput(count, localResult);
            }
        }

        public void LoopThroughLocalInput(byte count, Dictionary<int, string> localResult)
        {
            for (int i = 0; i < Input.Length; i++)
            {
                if (localResult.ContainsKey(i))
                {
                    continue;
                }

                if (count - this.Input[i].Length >= 0)
                {
                    localResult.Add(i, this.Input[i]);

                    byte newCount = (byte)(count - this.Input[i].Length);

                    if (newCount == 0)
                    {
                        // Check the combination
                        string combinedString = String.Join("", localResult.Values);
                        if (this.AllowedCombinations.Contains(combinedString))
                        {
                            this.Results.Add(new List<string>(localResult.Values));
                        }

                    }
                    else
                    {
                        LoopThroughLocalInput(newCount, localResult);
                    }
                }
                else
                {
                    continue;
                }
                // after you've added a result you have to remove last entry and continue the loop
                localResult.Remove(localResult.Keys.Last());

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
            }
            else
            {
                Console.WriteLine("No results found");
            }
        }

    }
}
