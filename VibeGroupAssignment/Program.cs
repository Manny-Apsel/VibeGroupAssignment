using VibeGroupAssignment.Classes;

namespace VibeGroupAssignment;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var SA = new SortingAlghorithm(ReadText.readText());
        SA.FindCombinations();
        SA.showResults();
    }
}
