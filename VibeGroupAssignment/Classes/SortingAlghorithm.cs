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
            var delDuplicatesInput = input.Distinct();
            this.AllowedCombinations = delDuplicatesInput.Where(x => x.Length == 6).ToHashSet();
            this.Input = delDuplicatesInput.Where(x => x.Length < 6).ToArray();
        }

        public void FindCombinations()
        {
            //Console.WriteLine($"There's currently {this.Input.Length} distinct entries in Input");
            for (int i = 0; i < Input.Length; i++)
            {
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
                    string combinedString = String.Join("", localResult.Values);
                    if (newCount == 0)
                    {
                        // Check the combination
                        
                        if (CheckIfSubstringExist(combinedString, newCount))
                        {
                            this.Results.Add(new List<string>(localResult.Values));
                        }

                    }
                    else
                    {
                        if (CheckIfSubstringExist(combinedString, newCount))
                        {
                            //WriteCurrentWordLoop(localResult);

                            LoopThroughLocalInput(newCount, localResult);
                        }
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

        public bool CheckIfSubstringExist(string input, byte count)
        {
            foreach (var item in this.AllowedCombinations)
            {
                var subStr = item.Substring(0, 6 - count);
                if (input == subStr)
                {
                    return true;
                }
            }
            return false;
        }

        public void WriteCurrentWordLoop(Dictionary<int, string> localResult)
        {
            Console.Write("Currently looping through words { ");
            foreach (var item in localResult)
            {
                Console.Write($"{item.Value} ");
            }
            Console.Write("} with index {");
            foreach (var item in localResult)
            {
                Console.Write($"{item.Key} ");
            }
            Console.WriteLine("}");
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
