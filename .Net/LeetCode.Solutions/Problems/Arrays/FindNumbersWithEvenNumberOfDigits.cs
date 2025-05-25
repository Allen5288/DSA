using LeetCode.Solutions.Common;

namespace LeetCode.Solutions.Problems.Arrays;

/// <summary>
/// 1295. Find Numbers with Even Number of Digits
/// https://leetcode.com/problems/find-numbers-with-even-number-of-digits/
/// 
/// Given an array nums of integers, return how many of them contain an even number of digits.
/// </summary>
public class FindNumbersWithEvenNumberOfDigits : LeetCodeProblemBase<int[], int>
{
    public override int ProblemNumber => 1295;
    public override string Title => "Find Numbers with Even Number of Digits";
    public override Difficulty Difficulty => Difficulty.Easy;

    /// <summary>
    /// Count numbers with even number of digits
    /// Time Complexity: O(n * log m) where n is array length, m is average number value
    /// Space Complexity: O(1)
    /// </summary>
    public override int Solve(int[] nums)
    {
        if (nums == null) return 0;
        
        int count = 0;
        foreach (int num in nums)
        {
            if (CountDigits(num) % 2 == 0)
            {
                count++;
            }
        }
        return count;
    }

    /// <summary>
    /// Alternative solution using string conversion
    /// Time Complexity: O(n * log m)
    /// Space Complexity: O(log m) for string conversion
    /// </summary>
    public int SolveWithString(int[] nums)
    {
        if (nums == null) return 0;
        
        return nums.Count(num => num.ToString().Length % 2 == 0);
    }

    private int CountDigits(int num)
    {
        if (num == 0) return 1;
        
        num = Math.Abs(num);
        int digits = 0;
        while (num > 0)
        {
            digits++;
            num /= 10;
        }
        return digits;
    }
}
