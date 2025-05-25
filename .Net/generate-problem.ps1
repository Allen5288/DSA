param(
    [Parameter(Mandatory=$true)]
    [int]$Number,
    
    [Parameter(Mandatory=$true)]
    [string]$Title,
    
    [Parameter(Mandatory=$true)]
    [ValidateSet("Easy", "Medium", "Hard")]
    [string]$Difficulty,
    
    [Parameter(Mandatory=$true)]
    [ValidateSet("Arrays", "Strings", "LinkedLists", "Trees", "Graphs", "DynamicProgramming", 
                 "Sorting", "Searching", "Math", "Greedy", "Backtracking", "TwoPointers", 
                 "SlidingWindow", "Stack", "Queue", "Heap", "HashTable", "BinarySearch", "Bit")]
    [string]$Category
)

# Convert title to class name (remove spaces and special characters)
$ClassName = $Title -replace '[^a-zA-Z0-9]', ''

# Convert title to URL slug
$UrlSlug = $Title.ToLower() -replace '[^a-z0-9]', '-' -replace '--+', '-' -replace '^-|-$', ''

$SolutionDir = "LeetCode.Solutions\Problems\$Category"
$TestDir = "LeetCode.Tests\Problems\$Category"

# Create directories if they don't exist
New-Item -ItemType Directory -Path $SolutionDir -Force | Out-Null
New-Item -ItemType Directory -Path $TestDir -Force | Out-Null

# Generate solution file
$SolutionContent = @"
using LeetCode.Solutions.Common;

namespace LeetCode.Solutions.Problems.$Category;

/// <summary>
/// $Number. $Title
/// https://leetcode.com/problems/$UrlSlug/
/// 
/// TODO: Add problem description here
/// </summary>
public class $ClassName : LeetCodeProblemBase<object, object>
{
    public override int ProblemNumber => $Number;
    public override string Title => "$Title";
    public override Difficulty Difficulty => Difficulty.$Difficulty;

    /// <summary>
    /// Solve the problem
    /// Time Complexity: O(?)
    /// Space Complexity: O(?)
    /// </summary>
    public override object Solve(object input)
    {
        // TODO: Implement solution
        throw new NotImplementedException();
    }
}
"@

# Generate test file
$TestContent = @"
using Xunit;
using LeetCode.Solutions.Problems.$Category;

namespace LeetCode.Tests.Problems.$Category;

public class $($ClassName)Tests
{
    private readonly $ClassName _solution;

    public $($ClassName)Tests()
    {
        _solution = new $ClassName();
    }

    [Theory]
    [InlineData(/* Add test cases here */)]
    public void Solve_ValidInput_ReturnsExpected(object input, object expected)
    {
        // Arrange
        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ProblemInfo_ShouldHaveCorrectMetadata()
    {
        // Assert
        Assert.Equal($Number, _solution.ProblemNumber);
        Assert.Equal("$Title", _solution.Title);
        Assert.Equal(Difficulty.$Difficulty, _solution.Difficulty);
        Assert.Contains("leetcode.com", _solution.Url);
    }
}
"@

# Write files
$SolutionPath = "$SolutionDir\$ClassName.cs"
$TestPath = "$TestDir\$($ClassName)Tests.cs"

$SolutionContent | Out-File -FilePath $SolutionPath -Encoding UTF8
$TestContent | Out-File -FilePath $TestPath -Encoding UTF8

Write-Host "✅ Generated files:" -ForegroundColor Green
Write-Host "   📝 $SolutionPath" -ForegroundColor Yellow
Write-Host "   🧪 $TestPath" -ForegroundColor Yellow
Write-Host ""
Write-Host "Next steps:" -ForegroundColor Cyan
Write-Host "1. Update the input/output types in both files"
Write-Host "2. Add the problem description"
Write-Host "3. Implement the solution"
Write-Host "4. Add test cases"
Write-Host "5. Run: dotnet test --filter `"FullyQualifiedName~$ClassName`""

# Usage example
Write-Host ""
Write-Host "Example usage:" -ForegroundColor Magenta
Write-Host ".\generate-problem.ps1 -Number 1 -Title `"Two Sum`" -Difficulty Easy -Category Arrays"
