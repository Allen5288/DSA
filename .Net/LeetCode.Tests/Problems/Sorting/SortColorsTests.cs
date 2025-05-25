using Xunit;
using LeetCode.Solutions.Problems.Sorting;
using LeetCode.Solutions.Common;

namespace LeetCode.Tests.Problems.Sorting;

public class SortColorsTests
{
    private readonly SortColors _solution;

    public SortColorsTests()
    {
        _solution = new SortColors();
    }

    [Theory]
    [InlineData(new int[] { 2, 0, 2, 1, 1, 0 }, new int[] { 0, 0, 1, 1, 2, 2 })]
    [InlineData(new int[] { 2, 0, 1 }, new int[] { 0, 1, 2 })]
    [InlineData(new int[] { 0 }, new int[] { 0 })]
    [InlineData(new int[] { 1 }, new int[] { 1 })]
    [InlineData(new int[] { 2 }, new int[] { 2 })]
    [InlineData(new int[] { 1, 2, 0 }, new int[] { 0, 1, 2 })]
    public void Solve_ValidInput_ReturnsSortedArray(int[] input, int[] expected)
    {
        // Arrange
        int[] inputCopy = (int[])input.Clone();

        // Act
        var result = _solution.Solve(inputCopy);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { 2, 0, 2, 1, 1, 0 }, new int[] { 0, 0, 1, 1, 2, 2 })]
    [InlineData(new int[] { 2, 0, 1 }, new int[] { 0, 1, 2 })]
    [InlineData(new int[] { 0 }, new int[] { 0 })]
    [InlineData(new int[] { 1 }, new int[] { 1 })]
    [InlineData(new int[] { 2 }, new int[] { 2 })]
    public void SolveWithCounting_ValidInput_ReturnsSortedArray(int[] input, int[] expected)
    {
        // Arrange
        int[] inputCopy = (int[])input.Clone();

        // Act
        var result = _solution.SolveWithCounting(inputCopy);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Solve_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        int[] input = Array.Empty<int>();

        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Empty(result);
    }    [Fact]
    public void Solve_NullInput_ReturnsEmptyArray()
    {
        // Arrange
        int[]? input = null;

        // Act
        var result = _solution.Solve(input!);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void ProblemInfo_ShouldHaveCorrectMetadata()
    {
        // Assert
        Assert.Equal(75, _solution.ProblemNumber);
        Assert.Equal("Sort Colors", _solution.Title);
        Assert.Equal(Difficulty.Medium, _solution.Difficulty);
        Assert.Contains("sort-colors", _solution.Url);
    }
}
