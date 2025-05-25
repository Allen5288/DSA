using LeetCode.Solutions.Problems.Sorting;
using LeetCode.Solutions.Common;

namespace LeetCode.Solutions;

class Program
{
    static void Main(string[] args)
    {        // Check if this is a generate command
        if (args.Length > 0 && args[0] == "generate")
        {
            ProblemGenerator.GenerateCommand(args);
            return;
        }

        Console.WriteLine("🚀 LeetCode Solutions in C#");
        Console.WriteLine(new string('=', 40));

        // Example: Running Sort Colors problem
        RunSortColorsExample();

        Console.WriteLine("\n✅ All examples completed!");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static void RunSortColorsExample()
    {
        Console.WriteLine("\n📝 Problem 75: Sort Colors");
        Console.WriteLine(new string('-', 30));

        var solution = new SortColors();
        
        // Test case 1
        int[] input1 = { 2, 0, 2, 1, 1, 0 };
        Console.WriteLine($"Input:  [{string.Join(", ", input1)}]");
        
        var result1 = solution.Solve((int[])input1.Clone());
        Console.WriteLine($"Output: [{string.Join(", ", result1)}]");
        
        // Test case 2
        int[] input2 = { 2, 0, 1 };
        Console.WriteLine($"\nInput:  [{string.Join(", ", input2)}]");
        
        var result2 = solution.Solve((int[])input2.Clone());
        Console.WriteLine($"Output: [{string.Join(", ", result2)}]");

        Console.WriteLine($"\n🔗 Problem URL: {solution.Url}");
        Console.WriteLine($"📊 Difficulty: {solution.Difficulty}");
    }
}
