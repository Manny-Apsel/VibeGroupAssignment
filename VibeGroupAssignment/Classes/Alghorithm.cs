using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VibeGroupAssignment.Interface;

namespace VibeGroupAssignment.Classes
{
    public abstract class Alghorithm : IAlghorithm
    {
        public string[] Input { get; }
        public HashSet<string> AllowedCombinations { get; }
        public List<List<string>> Results { get; set; } = new List<List<string>>();
        public byte MaxLength { get; set; }

        public Alghorithm(string[] input, byte length)
        {
            var delDuplicatesInput = input.Distinct();
            this.MaxLength = length;
            this.AllowedCombinations = delDuplicatesInput.Where(x => x.Length == MaxLength).ToHashSet();
            this.Input = delDuplicatesInput.Where(x => x.Length < MaxLength).ToArray();
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

        public abstract void FindCombinations();
    }
}
