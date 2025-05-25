using System;

namespace LeetCode.Solutions.Problems.HashTable;

public class Solution
{
    public int LongestPalindrome(string[] words)
    {
        var visited = new int[26, 26];  // Frequency of pairs (first_char, second_char)
        int count = 0;                  // Total length of palindrome (in characters)

        foreach (var word in words)
        {
            int c1 = word[0] - 'a';     // Convert char to 0-25 index
            int c2 = word[1] - 'a';

            if (visited[c2, c1] > 0)
            {  // Check if reversed pair exists
                count += 4;             // Form a palindrome pair (2 words × 2 chars each)
                visited[c2, c1]--;
            }
            else
            {
                visited[c1, c2]++;      // Add current word to visited
            }
        }

        // Check for a leftover palindromic word (like "gg") to place in the middle
        for (int i = 0; i < 26; i++)
        {
            if (visited[i, i] > 0)
            {
                count += 2;             // Add 2 chars for middle palindrome word
                break;                  // Only one such word can be in the middle
            }
        }

        return count;
    }

    public static void Main(string[] args)
    {
        // Test the solution directly
        var solution = new Solution();

        // Test case 1
        string[] words1 = { "lc", "cl", "gg" };
        int result1 = solution.LongestPalindrome(words1);
        Console.WriteLine($"Test 1: [{string.Join(", ", words1)}] -> Expected: 6, Got: {result1}");

        // Test case 2
        string[] words2 = { "ab", "ty", "yt", "lc", "cl", "ab" };
        int result2 = solution.LongestPalindrome(words2);
        Console.WriteLine($"Test 2: [{string.Join(", ", words2)}] -> Expected: 8, Got: {result2}");

        // Test case 3
        string[] words3 = { "cc", "ll", "xx" };
        int result3 = solution.LongestPalindrome(words3);
        Console.WriteLine($"Test 3: [{string.Join(", ", words3)}] -> Expected: 2, Got: {result3}");

        // Test case 4
        string[] words4 = { "dd", "aa", "bb", "dd", "aa", "dd" };
        int result4 = solution.LongestPalindrome(words4);
        Console.WriteLine($"Test 4: [{string.Join(", ", words4)}] -> Expected: 8, Got: {result4}");
    }
}
