using System;
using System.Collections.Generic;

namespace LeetCodeSolutions.Arrays
{
    /// <summary>
    /// LeetCode 1. Two Sum
    /// 
    /// 给定一个整数数组 nums 和一个整数目标值 target，请你在该数组中找出 和为目标值 target 的那 两个 整数，并返回它们的数组下标。
    /// 你可以假设每种输入只会对应一个答案。但是，数组中同一个元素在答案里不能重复出现。
    /// 你可以按任意顺序返回答案。
    /// 
    /// 示例 1：
    /// 输入：nums = [2,7,11,15], target = 9
    /// 输出：[0,1]
    /// 解释：因为 nums[0] + nums[1] == 9 ，返回 [0, 1] 。
    /// </summary>
    public class TwoSum
    {
        /// <summary>
        /// 方法一：暴力解法
        /// 时间复杂度：O(n²)
        /// 空间复杂度：O(1)
        /// </summary>
        public int[] TwoSumBruteForce(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[0];
        }

        /// <summary>
        /// 方法二：哈希表
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(n)
        /// </summary>
        public int[] TwoSumHashMap(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };
                }
                map[nums[i]] = i;
            }
            
            return new int[0];
        }

        /// <summary>
        /// 测试方法
        /// </summary>
        public static void RunTests()
        {
            Console.WriteLine("=== LeetCode 1. Two Sum 测试 ===");
            
            TwoSum solution = new TwoSum();
            
            // 测试用例1
            int[] nums1 = { 2, 7, 11, 15 };
            int target1 = 9;
            int[] expected1 = { 0, 1 };
            int[] result1 = solution.TwoSumHashMap(nums1, target1);
            TestHelper.RunTest("Test Case 1", TestHelper.ArrayToString(expected1), TestHelper.ArrayToString(result1));
            
            // 测试用例2
            int[] nums2 = { 3, 2, 4 };
            int target2 = 6;
            int[] expected2 = { 1, 2 };
            int[] result2 = solution.TwoSumHashMap(nums2, target2);
            TestHelper.RunTest("Test Case 2", TestHelper.ArrayToString(expected2), TestHelper.ArrayToString(result2));
            
            // 测试用例3
            int[] nums3 = { 3, 3 };
            int target3 = 6;
            int[] expected3 = { 0, 1 };
            int[] result3 = solution.TwoSumHashMap(nums3, target3);
            TestHelper.RunTest("Test Case 3", TestHelper.ArrayToString(expected3), TestHelper.ArrayToString(result3));
            
            Console.WriteLine();
        }
    }
}
