using Xunit;
using LeetCode.Solutions.Problems.Arrays;
using LeetCode.Solutions.Common;

namespace LeetCode.Tests.Problems.Arrays;

public class FindNumbersWithEvenNumberOfDigitsTests
{
    private readonly FindNumbersWithEvenNumberOfDigits _solution;

    public FindNumbersWithEvenNumberOfDigitsTests()
    {
        _solution = new FindNumbersWithEvenNumberOfDigits();
    }

    [Theory]
    [InlineData(new int[] { 12, 345, 2, 6, 7896 }, 2)]
    [InlineData(new int[] { 555, 901, 482, 1771 }, 1)]
    [InlineData(new int[] { 1, 22, 333, 4444, 55555 }, 2)]
    [InlineData(new int[] { 100000 }, 1)]
    public void Solve_ValidInput_ReturnsCorrectCount(int[] input, int expected)
    {
        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { 12, 345, 2, 6, 7896 }, 2)]
    [InlineData(new int[] { 555, 901, 482, 1771 }, 1)]
    public void SolveWithString_ValidInput_ReturnsCorrectCount(int[] input, int expected)
    {
        // Act
        var result = _solution.SolveWithString(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Solve_EmptyArray_ReturnsZero()
    {
        // Arrange
        int[] input = Array.Empty<int>();

        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Solve_NullInput_ReturnsZero()
    {
        // Arrange
        int[]? input = null;

        // Act
        var result = _solution.Solve(input!);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void ProblemInfo_ShouldHaveCorrectMetadata()
    {
        // Assert
        Assert.Equal(1295, _solution.ProblemNumber);
        Assert.Equal("Find Numbers with Even Number of Digits", _solution.Title);
        Assert.Equal(Difficulty.Easy, _solution.Difficulty);
        Assert.Contains("find-numbers-with-even-number-of-digits", _solution.Url);
    }
}
