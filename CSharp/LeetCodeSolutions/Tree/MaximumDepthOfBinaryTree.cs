using System;
using System.Collections.Generic;

namespace LeetCodeSolutions.Trees
{
    /// <summary>
    /// 二叉树节点定义
    /// </summary>
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    /// <summary>
    /// LeetCode 104. Maximum Depth of Binary Tree
    /// 
    /// 给定一个二叉树，找出其最大深度。
    /// 二叉树的深度为根节点到最远叶子节点的最长路径上的节点数。
    /// 
    /// 示例：
    /// 给定二叉树 [3,9,20,null,null,15,7]，
    ///     3
    ///    / \
    ///   9  20
    ///     /  \
    ///    15   7
    /// 返回它的最大深度 3 。
    /// </summary>
    public class MaximumDepthOfBinaryTree
    {
        /// <summary>
        /// 方法一：递归 (DFS)
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(h) 其中h是树的高度
        /// </summary>
        public int MaxDepthRecursive(TreeNode root)
        {
            if (root == null) return 0;
            
            int leftDepth = MaxDepthRecursive(root.left);
            int rightDepth = MaxDepthRecursive(root.right);
            
            return Math.Max(leftDepth, rightDepth) + 1;
        }

        /// <summary>
        /// 方法二：迭代 (BFS)
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(w) 其中w是树的最大宽度
        /// </summary>
        public int MaxDepthIterative(TreeNode root)
        {
            if (root == null) return 0;
            
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int depth = 0;
            
            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                depth++;
                
                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode node = queue.Dequeue();
                    
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
            }
            
            return depth;
        }

        /// <summary>
        /// 辅助方法：创建测试用的二叉树
        /// </summary>
        private TreeNode CreateTestTree()
        {
            // 创建示例树: [3,9,20,null,null,15,7]
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            return root;
        }

        /// <summary>
        /// 测试方法
        /// </summary>
        public static void RunTests()
        {
            Console.WriteLine("=== LeetCode 104. Maximum Depth of Binary Tree 测试 ===");
            
            MaximumDepthOfBinaryTree solution = new MaximumDepthOfBinaryTree();
            
            // 测试用例1：示例树
            TreeNode root1 = solution.CreateTestTree();
            int expected1 = 3;
            int result1 = solution.MaxDepthRecursive(root1);
            TestHelper.RunTest("Test Case 1 (Recursive)", expected1, result1);
            
            int result1_iter = solution.MaxDepthIterative(root1);
            TestHelper.RunTest("Test Case 1 (Iterative)", expected1, result1_iter);
            
            // 测试用例2：空树
            TreeNode root2 = null;
            int expected2 = 0;
            int result2 = solution.MaxDepthRecursive(root2);
            TestHelper.RunTest("Test Case 2 (Empty Tree)", expected2, result2);
            
            // 测试用例3：单节点树
            TreeNode root3 = new TreeNode(1);
            int expected3 = 1;
            int result3 = solution.MaxDepthRecursive(root3);
            TestHelper.RunTest("Test Case 3 (Single Node)", expected3, result3);
            
            Console.WriteLine();
        }
    }
}
