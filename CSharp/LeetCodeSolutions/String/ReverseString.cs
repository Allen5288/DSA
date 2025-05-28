using System;
using System.Text;

namespace LeetCodeSolutions.Strings
{
    /// <summary>
    /// LeetCode 344. Reverse String
    /// 
    /// 编写一个函数，其作用是将输入的字符串反转过来。输入字符串以字符数组 s 的形式给出。
    /// 不要给另外的数组分配额外的空间，你必须原地修改输入数组、使用 O(1) 的额外空间解决这一问题。
    /// 
    /// 示例 1：
    /// 输入：s = ['h','e','l','l','o']
    /// 输出：['o','l','l','e','h']
    /// </summary>
    public class ReverseString
    {
        /// <summary>
        /// 双指针法
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// </summary>
        public void ReverseStringTwoPointers(char[] s)
        {
            int left = 0;
            int right = s.Length - 1;
            
            while (left < right)
            {
                // 交换字符
                char temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                
                left++;
                right--;
            }
        }

        /// <summary>
        /// 递归方法
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(n) - 递归调用栈
        /// </summary>
        public void ReverseStringRecursive(char[] s)
        {
            ReverseHelper(s, 0, s.Length - 1);
        }
        
        private void ReverseHelper(char[] s, int left, int right)
        {
            if (left >= right) return;
            
            // 交换字符
            char temp = s[left];
            s[left] = s[right];
            s[right] = temp;
            
            // 递归处理内部字符
            ReverseHelper(s, left + 1, right - 1);
        }

        /// <summary>
        /// 测试方法
        /// </summary>
        public static void RunTests()
        {
            Console.WriteLine("=== LeetCode 344. Reverse String 测试 ===");
            
            ReverseString solution = new ReverseString();
            
            // 测试用例1
            char[] s1 = { 'h', 'e', 'l', 'l', 'o' };
            char[] expected1 = { 'o', 'l', 'l', 'e', 'h' };
            solution.ReverseStringTwoPointers(s1);
            TestHelper.RunTest("Test Case 1", new string(expected1), new string(s1));
            
            // 测试用例2
            char[] s2 = { 'H', 'a', 'n', 'n', 'a', 'h' };
            char[] expected2 = { 'h', 'a', 'n', 'n', 'a', 'H' };
            solution.ReverseStringTwoPointers(s2);
            TestHelper.RunTest("Test Case 2", new string(expected2), new string(s2));
            
            // 测试递归方法
            char[] s3 = { 'a', 'b', 'c' };
            char[] expected3 = { 'c', 'b', 'a' };
            solution.ReverseStringRecursive(s3);
            TestHelper.RunTest("Test Case 3 (Recursive)", new string(expected3), new string(s3));
            
            Console.WriteLine();
        }
    }
}
