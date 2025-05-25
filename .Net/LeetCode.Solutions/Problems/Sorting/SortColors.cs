using LeetCode.Solutions.Common;

namespace LeetCode.Solutions.Problems.Sorting;

/// <summary>
/// 75. Sort Colors
/// https://leetcode.com/problems/sort-colors/
/// 
/// Given an array nums with n objects colored red, white, or blue, 
/// sort them in-place so that objects of the same color are adjacent, 
/// with the colors in the order red, white, and blue.
/// 
/// We will use the integers 0, 1, and 2 to represent the color red, white, and blue, respectively.
/// You must solve this problem without using the library's sort function.
/// </summary>
public class SortColors : LeetCodeProblemBase<int[], int[]>
{
    public override int ProblemNumber => 75;
    public override string Title => "Sort Colors";
    public override Difficulty Difficulty => Difficulty.Medium;    /// <summary>
    /// Sort colors using Dutch National Flag algorithm
    /// Time Complexity: O(n) - single pass
    /// Space Complexity: O(1) - in-place sorting
    /// </summary>
    public override int[] Solve(int[] nums)
    {
        if (nums == null || nums.Length <= 1)
            return nums ?? Array.Empty<int>();

        // Dutch national flag algorithm: one-pass solution
        int left = 0;         // pointer for position to place 0s
        int right = nums.Length - 1;  // pointer for position to place 2s
        int current = 0;      // current position being examined

        while (current <= right)
        {
            if (nums[current] == 0)
            {
                // Swap current element with the element at left pointer
                (nums[left], nums[current]) = (nums[current], nums[left]);
                left++;
                current++;
            }
            else if (nums[current] == 2)
            {
                // Swap current element with the element at right pointer
                (nums[right], nums[current]) = (nums[current], nums[right]);
                right--;
                // Don't increment current here because the swapped element needs to be examined
            }
            else
            {
                // nums[current] == 1, just move forward
                current++;
            }
        }

        return nums;
    }    /// <summary>
    /// Alternative solution using counting sort
    /// Time Complexity: O(n) - two passes
    /// Space Complexity: O(1) - only storing counts
    /// </summary>
    public int[] SolveWithCounting(int[] nums)
    {
        if (nums == null || nums.Length <= 1)
            return nums ?? Array.Empty<int>();

        int count0 = 0, count1 = 0, count2 = 0;

        // First pass: count occurrences
        foreach (int num in nums)
        {
            switch (num)
            {
                case 0: count0++; break;
                case 1: count1++; break;
                case 2: count2++; break;
            }
        }

        // Second pass: fill the array
        int index = 0;
        
        // Fill 0s
        for (int i = 0; i < count0; i++)
            nums[index++] = 0;
        
        // Fill 1s
        for (int i = 0; i < count1; i++)
            nums[index++] = 1;
        
        // Fill 2s
        for (int i = 0; i < count2; i++)
            nums[index++] = 2;

        return nums;
    }
}
