using LeetCode.Solutions.Common;

namespace LeetCode.Solutions;

/// <summary>
/// Helper program to generate new LeetCode problem templates
/// </summary>
public static class ProblemGenerator
{
    public static void GenerateCommand(string[] args)
    {
        if (args.Length < 4)
        {
            Console.WriteLine("Usage: dotnet run --project LeetCode.Solutions -- generate <number> <title> <difficulty> <category>");
            Console.WriteLine("Example: dotnet run --project LeetCode.Solutions -- generate 1007 \"Minimum Domino Rotations For Equal Row\" Medium Arrays");
            return;
        }

        if (args[0] != "generate")
        {
            Console.WriteLine("Unknown command. Use 'generate' to create new problems.");
            return;
        }

        int number = int.Parse(args[1]);
        string title = args[2];
        string difficulty = args[3];
        string category = args[4];

        GenerateNewProblem(number, title, difficulty, category);
    }

    public static void GenerateNewProblem(int number, string title, string difficulty, string category)
    {
        try
        {
            // Generate problem template
            string problemTemplate = ProblemTemplateGenerator.GenerateProblemTemplate(
                number, title, difficulty, category, 
                "TODO: Add problem description here",
                "object", "object");

            // Generate test template
            string testTemplate = ProblemTemplateGenerator.GenerateTestTemplate(
                number, title, category, "object", "object");

            // Create file paths
            string className = GetClassName(title);
            string solutionDir = $"Problems/{category}";
            string testDir = $"../LeetCode.Tests/Problems/{category}";

            Directory.CreateDirectory(solutionDir);
            Directory.CreateDirectory(testDir);

            string solutionPath = Path.Combine(solutionDir, $"{className}.cs");
            string testPath = Path.Combine(testDir, $"{className}Tests.cs");

            // Write files
            File.WriteAllText(solutionPath, problemTemplate);
            File.WriteAllText(testPath, testTemplate);

            Console.WriteLine("✅ Generated files:");
            Console.WriteLine($"   📝 {solutionPath}");
            Console.WriteLine($"   🧪 {testPath}");
            Console.WriteLine();
            Console.WriteLine("Next steps:");
            Console.WriteLine("1. Update the input/output types in both files");
            Console.WriteLine("2. Add the problem description");
            Console.WriteLine("3. Implement the solution");
            Console.WriteLine("4. Add test cases");
            Console.WriteLine($"5. Run: dotnet test --filter \"FullyQualifiedName~{className}\"");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error generating problem: {ex.Message}");
        }
    }

    private static string GetClassName(string title)
    {
        return title
            .Replace(" ", "")
            .Replace("-", "")
            .Replace(".", "")
            .Replace(",", "")
            .Replace("'", "")
            .Replace("(", "")
            .Replace(")", "")
            .Replace(":", "")
            .Replace("/", "");
    }
}
