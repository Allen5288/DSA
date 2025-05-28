using System;
using LeetCodeSolutions.Arrays;
using LeetCodeSolutions.Strings;
using LeetCodeSolutions.Trees;
using LeetCodeSolutions.DynamicProgrammings;
using LeetCodeSolutions.LinkedLists;

namespace LeetCodeSolutions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🚀 LeetCode C# Solutions 测试运行器");
            Console.WriteLine("======================================");
            Console.WriteLine();
            
            // 运行Array类题目测试
            TwoSum.RunTests();
            
            // 运行String类题目测试
            ReverseString.RunTests();
              // 运行Tree类题目测试
            MaximumDepthOfBinaryTree.RunTests();
            
            // 运行Dynamic Programming类题目测试
            ClimbingStairs.RunTests();
            
            // 运行LinkedList类题目测试
            ReverseLinkedList.RunTests();
            
            Console.WriteLine("✅ 所有测试完成！");
            Console.WriteLine("📝 要添加新题目，只需在对应分类文件夹下创建新的.cs文件");
            Console.WriteLine("🔧 每个题目文件都包含解题代码和测试方法");
            
            Console.WriteLine("\n按任意键退出...");
            Console.ReadKey();
        }
    }
}
