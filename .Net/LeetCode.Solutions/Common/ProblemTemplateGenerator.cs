using System.Text;

namespace LeetCode.Solutions.Common;

/// <summary>
/// Helper class to generate template files for new LeetCode problems
/// </summary>
public static class ProblemTemplateGenerator
{
    /// <summary>
    /// Generate a problem class template
    /// </summary>
    public static string GenerateProblemTemplate(
        int problemNumber,
        string title,
        string difficulty,
        string category,
        string description = "",
        string inputType = "int[]",
        string outputType = "int")
    {
        var className = GetClassName(title);
        var namespaceName = $"LeetCode.Solutions.Problems.{category}";
        var urlSlug = GetUrlSlug(title);

        var sb = new StringBuilder();
        sb.AppendLine("using LeetCode.Solutions.Common;");
        sb.AppendLine();
        sb.AppendLine($"namespace {namespaceName};");
        sb.AppendLine();
        sb.AppendLine("/// <summary>");
        sb.AppendLine($"/// {problemNumber}. {title}");
        sb.AppendLine($"/// https://leetcode.com/problems/{urlSlug}/");
        sb.AppendLine("/// ");
        sb.AppendLine($"/// {description}");
        sb.AppendLine("/// </summary>");
        sb.AppendLine($"public class {className} : LeetCodeProblemBase<{inputType}, {outputType}>");
        sb.AppendLine("{");
        sb.AppendLine($"    public override int ProblemNumber => {problemNumber};");
        sb.AppendLine($"    public override string Title => \"{title}\";");
        sb.AppendLine($"    public override Difficulty Difficulty => Difficulty.{difficulty};");
        sb.AppendLine();
        sb.AppendLine("    /// <summary>");
        sb.AppendLine("    /// Solve the problem");
        sb.AppendLine("    /// Time Complexity: O(?)");
        sb.AppendLine("    /// Space Complexity: O(?)");
        sb.AppendLine("    /// </summary>");
        sb.AppendLine($"    public override {outputType} Solve({inputType} input)");
        sb.AppendLine("    {");
        sb.AppendLine("        // TODO: Implement solution");
        sb.AppendLine("        throw new NotImplementedException();");
        sb.AppendLine("    }");
        sb.AppendLine("}");
        
        return sb.ToString();
    }

    /// <summary>
    /// Generate a test class template
    /// </summary>
    public static string GenerateTestTemplate(
        int problemNumber,
        string title,
        string category,
        string inputType = "int[]",
        string outputType = "int")
    {
        var className = GetClassName(title);
        var namespaceName = $"LeetCode.Tests.Problems.{category}";

        var sb = new StringBuilder();
        sb.AppendLine("using Xunit;");
        sb.AppendLine($"using LeetCode.Solutions.Problems.{category};");
        sb.AppendLine();
        sb.AppendLine($"namespace {namespaceName};");
        sb.AppendLine();
        sb.AppendLine($"public class {className}Tests");
        sb.AppendLine("{");
        sb.AppendLine($"    private readonly {className} _solution;");
        sb.AppendLine();
        sb.AppendLine($"    public {className}Tests()");
        sb.AppendLine("    {");
        sb.AppendLine($"        _solution = new {className}();");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    [Theory]");
        sb.AppendLine("    [InlineData(/* Add test cases here */)]");
        sb.AppendLine($"    public void Solve_ValidInput_ReturnsExpected({inputType} input, {outputType} expected)");
        sb.AppendLine("    {");
        sb.AppendLine("        // Arrange");
        sb.AppendLine("        // Act");
        sb.AppendLine("        var result = _solution.Solve(input);");
        sb.AppendLine();
        sb.AppendLine("        // Assert");
        sb.AppendLine("        Assert.Equal(expected, result);");
        sb.AppendLine("    }");
        sb.AppendLine();
        sb.AppendLine("    [Fact]");
        sb.AppendLine("    public void ProblemInfo_ShouldHaveCorrectMetadata()");
        sb.AppendLine("    {");
        sb.AppendLine("        // Assert");
        sb.AppendLine($"        Assert.Equal({problemNumber}, _solution.ProblemNumber);");
        sb.AppendLine($"        Assert.Equal(\"{title}\", _solution.Title);");
        sb.AppendLine("        Assert.Contains(\"leetcode.com\", _solution.Url);");
        sb.AppendLine("    }");
        sb.AppendLine("}");
        
        return sb.ToString();
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

    private static string GetUrlSlug(string title)
    {
        return title.ToLower()
            .Replace(" ", "-")
            .Replace(".", "")
            .Replace(",", "")
            .Replace("'", "")
            .Replace("(", "")
            .Replace(")", "")
            .Replace(":", "")
            .Replace("/", "");
    }
}
