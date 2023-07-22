using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VibeGroupAssignment.Classes
{
    public class SortingAlghorithm : Alghorithm
    {
        
        public SortingAlghorithm(string[] input, byte length) : base(input, length) { }
        

        public override void FindCombinations()
        {
            for (int i = 0; i < Input.Length; i++)
            {
                var localResult = new Stack<string>();
                localResult.Push(this.Input[i]);
                byte count = (byte)(Input[i].Length);
                
                LoopThroughLocalInput(count, localResult);
            }
        }

        public void LoopThroughLocalInput(byte count, Stack<string> localResult)
        {
            for (int i = 0; i < Input.Length; i++)
            {
                if (count + this.Input[i].Length <= this.MaxLength)
                {
                    localResult.Push(this.Input[i]);

                    byte newCount = (byte)(count + this.Input[i].Length);
                    string combinedString = combineString(localResult);

                    if (CheckIfSubstringExist(combinedString, newCount))
                    {
                        if (newCount == this.MaxLength)
                        {
                            this.Results.Add(new List<string>(localResult.Reverse()));

                        }
                        else
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
                localResult.Pop();

            }
        }

        private string combineString(Stack<string> input)
        {
            string output = "";

            foreach (var item in input)
            {
                output = item + output;

            }

            return output;
        }

        public bool CheckIfSubstringExist(string input, byte count)
        {
            foreach (var item in this.AllowedCombinations)
            {
                var subStr = item.Substring(0, count);
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
    }
}
