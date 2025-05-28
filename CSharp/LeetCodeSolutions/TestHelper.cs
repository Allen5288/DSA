using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeSolutions
{
    /// <summary>
    /// 测试辅助类，提供常用的测试方法
    /// </summary>
    public static class TestHelper
    {
        /// <summary>
        /// 比较两个数组是否相等
        /// </summary>
        public static bool ArrayEquals<T>(T[] arr1, T[] arr2)
        {
            if (arr1 == null && arr2 == null) return true;
            if (arr1 == null || arr2 == null) return false;
            if (arr1.Length != arr2.Length) return false;
            
            for (int i = 0; i < arr1.Length; i++)
            {
                if (!arr1[i].Equals(arr2[i]))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 比较两个List是否相等
        /// </summary>
        public static bool ListEquals<T>(List<T> list1, List<T> list2)
        {
            if (list1 == null && list2 == null) return true;
            if (list1 == null || list2 == null) return false;
            return list1.SequenceEqual(list2);
        }

        /// <summary>
        /// 打印测试结果
        /// </summary>
        public static void PrintTestResult(string testName, bool passed, object expected = null, object actual = null)
        {
            Console.WriteLine($"[{(passed ? "PASS" : "FAIL")}] {testName}");
            if (!passed && expected != null && actual != null)
            {
                Console.WriteLine($"  Expected: {expected}");
                Console.WriteLine($"  Actual: {actual}");
            }
        }

        /// <summary>
        /// 运行单个测试用例
        /// </summary>
        public static void RunTest<T>(string testName, T expected, T actual)
        {
            bool passed = expected.Equals(actual);
            PrintTestResult(testName, passed, expected, actual);
        }

        /// <summary>
        /// 打印数组
        /// </summary>
        public static string ArrayToString<T>(T[] array)
        {
            if (array == null) return "null";
            return "[" + string.Join(", ", array) + "]";
        }

        /// <summary>
        /// 打印List
        /// </summary>
        public static string ListToString<T>(List<T> list)
        {
            if (list == null) return "null";
            return "[" + string.Join(", ", list) + "]";
        }
    }
}
