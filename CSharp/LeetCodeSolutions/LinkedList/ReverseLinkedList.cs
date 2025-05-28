using System;

namespace LeetCodeSolutions.LinkedLists
{
    /// <summary>
    /// 链表节点定义
    /// </summary>
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    /// <summary>
    /// LeetCode 206. Reverse Linked List
    /// 
    /// 给你单链表的头节点 head ，请你反转链表，并返回反转后的链表。
    /// 
    /// 示例 1：
    /// 输入：head = [1,2,3,4,5]
    /// 输出：[5,4,3,2,1]
    /// 
    /// 示例 2：
    /// 输入：head = [1,2]
    /// 输出：[2,1]
    /// 
    /// 示例 3：
    /// 输入：head = []
    /// 输出：[]
    /// </summary>
    public class ReverseLinkedList
    {
        /// <summary>
        /// 方法一：迭代
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(1)
        /// </summary>
        public ListNode ReverseListIterative(ListNode head)
        {
            ListNode prev = null;
            ListNode current = head;
            
            while (current != null)
            {
                ListNode nextTemp = current.next;
                current.next = prev;
                prev = current;
                current = nextTemp;
            }
            
            return prev;
        }

        /// <summary>
        /// 方法二：递归
        /// 时间复杂度：O(n)
        /// 空间复杂度：O(n)
        /// </summary>
        public ListNode ReverseListRecursive(ListNode head)
        {
            // 基本情况
            if (head == null || head.next == null)
                return head;
            
            // 递归反转剩余部分
            ListNode newHead = ReverseListRecursive(head.next);
            
            // 反转当前连接
            head.next.next = head;
            head.next = null;
            
            return newHead;
        }

        /// <summary>
        /// 辅助方法：创建链表
        /// </summary>
        private ListNode CreateLinkedList(int[] values)
        {
            if (values == null || values.Length == 0)
                return null;
            
            ListNode head = new ListNode(values[0]);
            ListNode current = head;
            
            for (int i = 1; i < values.Length; i++)
            {
                current.next = new ListNode(values[i]);
                current = current.next;
            }
            
            return head;
        }

        /// <summary>
        /// 辅助方法：链表转数组（用于测试比较）
        /// </summary>
        private int[] LinkedListToArray(ListNode head)
        {
            var result = new System.Collections.Generic.List<int>();
            ListNode current = head;
            
            while (current != null)
            {
                result.Add(current.val);
                current = current.next;
            }
            
            return result.ToArray();
        }

        /// <summary>
        /// 测试方法
        /// </summary>
        public static void RunTests()
        {
            Console.WriteLine("=== LeetCode 206. Reverse Linked List 测试 ===");
            
            ReverseLinkedList solution = new ReverseLinkedList();
            
            // 测试用例1：[1,2,3,4,5]
            int[] input1 = { 1, 2, 3, 4, 5 };
            int[] expected1 = { 5, 4, 3, 2, 1 };
            ListNode head1 = solution.CreateLinkedList(input1);
            ListNode result1 = solution.ReverseListIterative(head1);
            int[] actual1 = solution.LinkedListToArray(result1);
            TestHelper.RunTest("Test Case 1 (Iterative)", TestHelper.ArrayToString(expected1), TestHelper.ArrayToString(actual1));
            
            // 测试用例2：[1,2] (递归方法)
            int[] input2 = { 1, 2 };
            int[] expected2 = { 2, 1 };
            ListNode head2 = solution.CreateLinkedList(input2);
            ListNode result2 = solution.ReverseListRecursive(head2);
            int[] actual2 = solution.LinkedListToArray(result2);
            TestHelper.RunTest("Test Case 2 (Recursive)", TestHelper.ArrayToString(expected2), TestHelper.ArrayToString(actual2));
            
            // 测试用例3：空链表
            ListNode head3 = null;
            ListNode result3 = solution.ReverseListIterative(head3);
            TestHelper.RunTest("Test Case 3 (Empty List)", "null", result3 == null ? "null" : "not null");
            
            // 测试用例4：单节点
            int[] input4 = { 1 };
            int[] expected4 = { 1 };
            ListNode head4 = solution.CreateLinkedList(input4);
            ListNode result4 = solution.ReverseListIterative(head4);
            int[] actual4 = solution.LinkedListToArray(result4);
            TestHelper.RunTest("Test Case 4 (Single Node)", TestHelper.ArrayToString(expected4), TestHelper.ArrayToString(actual4));
            
            Console.WriteLine();
        }
    }
}
