#!/bin/bash

# LeetCode Problem Generator Script
# Usage: ./generate-problem.sh <number> <title> <difficulty> <category>
# Example: ./generate-problem.sh 1 "Two Sum" Easy Arrays

if [ $# -ne 4 ]; then
    echo "Usage: $0 <number> <title> <difficulty> <category>"
    echo "Example: $0 1 \"Two Sum\" Easy Arrays"
    echo ""
    echo "Available categories:"
    echo "  Arrays, Strings, LinkedLists, Trees, Graphs, DynamicProgramming,"
    echo "  Sorting, Searching, Math, Greedy, Backtracking, TwoPointers,"
    echo "  SlidingWindow, Stack, Queue, Heap, HashTable, BinarySearch, Bit"
    exit 1
fi

NUMBER=$1
TITLE=$2
DIFFICULTY=$3
CATEGORY=$4

# Convert title to class name (remove spaces and special characters)
CLASS_NAME=$(echo "$TITLE" | sed 's/[^a-zA-Z0-9]//g')

# Convert title to URL slug
URL_SLUG=$(echo "$TITLE" | tr '[:upper:]' '[:lower:]' | sed 's/[^a-z0-9]/-/g' | sed 's/--*/-/g' | sed 's/^-\|-$//g')

SOLUTION_DIR="LeetCode.Solutions/Problems/$CATEGORY"
TEST_DIR="LeetCode.Tests/Problems/$CATEGORY"

# Create directories if they don't exist
mkdir -p "$SOLUTION_DIR"
mkdir -p "$TEST_DIR"

# Generate solution file
cat > "$SOLUTION_DIR/$CLASS_NAME.cs" << EOF
using LeetCode.Solutions.Common;

namespace LeetCode.Solutions.Problems.$CATEGORY;

/// <summary>
/// $NUMBER. $TITLE
/// https://leetcode.com/problems/$URL_SLUG/
/// 
/// TODO: Add problem description here
/// </summary>
public class $CLASS_NAME : LeetCodeProblemBase<object, object>
{
    public override int ProblemNumber => $NUMBER;
    public override string Title => "$TITLE";
    public override Difficulty Difficulty => Difficulty.$DIFFICULTY;

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
EOF

# Generate test file
cat > "$TEST_DIR/${CLASS_NAME}Tests.cs" << EOF
using Xunit;
using LeetCode.Solutions.Problems.$CATEGORY;

namespace LeetCode.Tests.Problems.$CATEGORY;

public class ${CLASS_NAME}Tests
{
    private readonly $CLASS_NAME _solution;

    public ${CLASS_NAME}Tests()
    {
        _solution = new $CLASS_NAME();
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
        Assert.Equal($NUMBER, _solution.ProblemNumber);
        Assert.Equal("$TITLE", _solution.Title);
        Assert.Equal(Difficulty.$DIFFICULTY, _solution.Difficulty);
        Assert.Contains("leetcode.com", _solution.Url);
    }
}
EOF

echo "✅ Generated files:"
echo "   📝 $SOLUTION_DIR/$CLASS_NAME.cs"
echo "   🧪 $TEST_DIR/${CLASS_NAME}Tests.cs"
echo ""
echo "Next steps:"
echo "1. Update the input/output types in both files"
echo "2. Add the problem description"
echo "3. Implement the solution"
echo "4. Add test cases"
echo "5. Run: dotnet test --filter \"FullyQualifiedName~$CLASS_NAME\""
