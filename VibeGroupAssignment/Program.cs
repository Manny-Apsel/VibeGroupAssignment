using VibeGroupAssignment.Classes;

namespace VibeGroupAssignment;
class Program
{
    static void Main(string[] args)
    {
        byte length;
        
        Console.WriteLine($"Give number for length of word combinations within range {byte.MinValue} and {byte.MaxValue} (default: 6) ");
        if (byte.TryParse(Console.ReadLine(), out length))
        {
            Console.WriteLine($"Finding results for length {length}");
        }
        else
        {
            Console.WriteLine("No correct number chosen thus default 6 has been chosen");
            length = 6;
        }

        var SA = new SortingAlghorithm(ReadText.readText(), length);
        SA.FindCombinations();
        SA.showResults();
    }
}
