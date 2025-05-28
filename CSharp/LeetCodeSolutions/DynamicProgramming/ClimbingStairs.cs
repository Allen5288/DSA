using System;

namespace LeetCodeSolutions.DynamicProgrammings
{
    /// <summary>
    /// LeetCode 70. Climbing Stairs
    /// 
    /// 假设你正在爬楼梯。需要 n 阶你才能到达楼顶。
    /// 每次你可以爬 1 或 2 个台阶。你有多少种不同的方法可以爬到楼顶呢？
    /// 
    /// 示例 1：
    /// 输入：n = 2
    /// 输出：2
    /// 解释：有两种方法可以爬到楼顶。
    /// 1. 1 阶 + 1 阶
    /// 2. 2 阶
    /// 
    /// 示例 2：
    /// 输入：n = 3
    /// 输出：3
    /// 解释：有三种方法可以爬到楼顶。
    /// 1. 1 阶 + 1 阶 + 1 阶
    /// 2. 1 阶 + 2 阶
    /// 3. 2 阶 + 1 阶
    /// </summary>
    public class ClimbingStairs
    {
        /// <summary>
        /// 方法一：动态规划
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(n)
        /// </summary>
        public int ClimbStairsDP(int n)
        {
            if (n <= 2) return n;
            
            int[] dp = new int[n + 1];
            dp[1] = 1;
            dp[2] = 2;
            
            for (int i = 3; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            
            return dp[n];
        }

        /// <summary>
        /// 方法二：动态规划优化（滚动数组）
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// </summary>
        public int ClimbStairsOptimized(int n)
        {
            if (n <= 2) return n;
            
            int prev2 = 1; // dp[i-2]
            int prev1 = 2; // dp[i-1]
            
            for (int i = 3; i <= n; i++)
            {
                int current = prev1 + prev2;
                prev2 = prev1;
                prev1 = current;
            }
            
            return prev1;
        }

        /// <summary>
        /// 方法三：递归（会超时，仅作演示）
        /// 时间复杂度：O(2^n)
        /// 空间复杂度：O(n)
        /// </summary>
        public int ClimbStairsRecursive(int n)
        {
            if (n <= 2) return n;
            return ClimbStairsRecursive(n - 1) + ClimbStairsRecursive(n - 2);
        }

        /// <summary>
        /// 方法四：记忆化递归
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(n)
        /// </summary>
        public int ClimbStairsMemo(int n)
        {
            int[] memo = new int[n + 1];
            return ClimbStairsMemoHelper(n, memo);
        }
        
        private int ClimbStairsMemoHelper(int n, int[] memo)
        {
            if (n <= 2) return n;
            if (memo[n] != 0) return memo[n];
            
            memo[n] = ClimbStairsMemoHelper(n - 1, memo) + ClimbStairsMemoHelper(n - 2, memo);
            return memo[n];
        }

        /// <summary>
        /// 测试方法
        /// </summary>
        public static void RunTests()
        {
            Console.WriteLine("=== LeetCode 70. Climbing Stairs 测试 ===");
            
            ClimbingStairs solution = new ClimbingStairs();
            
            // 测试用例1
            int n1 = 2;
            int expected1 = 2;
            int result1 = solution.ClimbStairsOptimized(n1);
            TestHelper.RunTest("Test Case 1 (n=2)", expected1, result1);
            
            // 测试用例2
            int n2 = 3;
            int expected2 = 3;
            int result2 = solution.ClimbStairsOptimized(n2);
            TestHelper.RunTest("Test Case 2 (n=3)", expected2, result2);
            
            // 测试用例3
            int n3 = 5;
            int expected3 = 8;
            int result3 = solution.ClimbStairsOptimized(n3);
            TestHelper.RunTest("Test Case 3 (n=5)", expected3, result3);
            
            // 测试不同方法的一致性
            int n4 = 10;
            int result4_dp = solution.ClimbStairsDP(n4);
            int result4_opt = solution.ClimbStairsOptimized(n4);
            int result4_memo = solution.ClimbStairsMemo(n4);
            TestHelper.RunTest("Method Consistency (DP vs Optimized)", result4_dp, result4_opt);
            TestHelper.RunTest("Method Consistency (DP vs Memo)", result4_dp, result4_memo);
            
            Console.WriteLine();
        }
    }
}
