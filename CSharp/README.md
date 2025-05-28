# LeetCode C# Solutions

## 📁 项目结构

```
LeetCodeCSharp/
├── LeetCodeCSharp.sln                 # Visual Studio Solution文件
└── LeetCodeSolutions/                 # 主项目文件夹
    ├── LeetCodeSolutions.csproj       # 项目文件
    ├── Program.cs                     # 主程序入口
    ├── TestHelper.cs                  # 测试辅助类
    ├── Array/                         # 数组相关题目
    │   └── TwoSum.cs                  # 示例：两数之和
    ├── String/                        # 字符串相关题目
    │   └── ReverseString.cs           # 示例：反转字符串
    ├── Tree/                          # 树相关题目
    │   └── MaximumDepthOfBinaryTree.cs # 示例：二叉树最大深度
    ├── LinkedList/                    # 链表相关题目
    ├── DynamicProgramming/            # 动态规划题目
    ├── Backtracking/                  # 回溯算法题目
    ├── BinarySearch/                  # 二分搜索题目
    ├── Graph/                         # 图论题目
    ├── Greedy/                        # 贪心算法题目
    ├── HashTable/                     # 哈希表题目
    ├── Math/                          # 数学题目
    ├── Stack/                         # 栈相关题目
    ├── Queue/                         # 队列相关题目
    ├── TwoPointers/                   # 双指针题目
    ├── Sorting/                       # 排序算法题目
    └── Simulation/                    # 模拟题目
```

## 🚀 运行项目

### 方法1：使用Visual Studio
1. 打开 `LeetCodeCSharp.sln`
2. 设置 `LeetCodeSolutions` 为启动项目
3. 按 F5 运行

### 方法2：使用命令行
```bash
cd LeetCodeSolutions
dotnet run
```

## 📝 添加新题目

1. 确定题目类型，选择对应的文件夹
2. 在文件夹中创建新的 `.cs` 文件，建议命名格式：`题目英文名.cs`
3. 按照示例模板编写代码

### 题目文件模板

```csharp
using System;

namespace LeetCodeSolutions.[命名空间]
{
    /// <summary>
    /// LeetCode [题目编号]. [题目名称]
    /// 
    /// [题目描述]
    /// 
    /// 示例：
    /// [示例输入输出]
    /// </summary>
    public class [题目类名]
    {
        /// <summary>
        /// 解法描述
        /// 时间复杂度：O(?)
        /// 空间复杂度：O(?)
        /// </summary>
        public [返回类型] [方法名]([参数])
        {
            // 解题代码
        }

        /// <summary>
        /// 测试方法
        /// </summary>
        public static void RunTests()
        {
            Console.WriteLine("=== LeetCode [编号]. [题目名] 测试 ===");
            
            [题目类名] solution = new [题目类名]();
            
            // 测试用例
            // TestHelper.RunTest("Test Case 1", expected, actual);
            
            Console.WriteLine();
        }
    }
}
```

### 快速添加新题目示例

假设要添加一个二分搜索题目 "LeetCode 704. Binary Search"：

1. 在 `BinarySearch` 文件夹下创建 `BinarySearch.cs`
2. 使用命名空间 `LeetCodeSolutions.BinarySearchs`
3. 在主程序中添加测试调用：

```csharp
// 在 Program.cs 中添加
using LeetCodeSolutions.BinarySearchs;

// 在 Main 方法中添加
BinarySearch.RunTests();
```

## 🛠️ 测试辅助工具

项目包含 `TestHelper` 类，提供了常用的测试方法：

- `ArrayEquals<T>()` - 比较两个数组
- `ListEquals<T>()` - 比较两个List  
- `RunTest<T>()` - 运行单个测试用例
- `ArrayToString<T>()` - 数组转字符串
- `ListToString<T>()` - List转字符串

## 🎯 设计理念

- **轻便清晰**：最小化项目结构，专注于算法实现
- **分类清晰**：按LeetCode常见分类组织代码
- **自包含测试**：每个题目文件都包含自己的测试方法
- **易于扩展**：添加新题目只需创建新的.cs文件
- **无额外依赖**：只使用.NET标准库，无需外部包

## 📋 分类说明

| 文件夹 | 命名空间 | 说明 | 常见题目类型 |
|--------|----------|------|-------------|
| Array | Arrays | 数组 | 双指针、滑动窗口、前缀和 |
| String | Strings | 字符串 | 字符串匹配、回文、子串 |
| LinkedList | LinkedLists | 链表 | 反转、合并、环检测 |
| Tree | Trees | 树 | 遍历、路径、BST |
| DynamicProgramming | DynamicProgrammings | 动态规划 | 背包、路径、子序列 |
| Backtracking | Backtrackings | 回溯 | 排列组合、N皇后 |
| BinarySearch | BinarySearchs | 二分搜索 | 查找、边界 |
| Graph | Graphs | 图 | BFS、DFS、最短路径 |
| Greedy | Greedys | 贪心 | 区间、调度 |
| HashTable | HashTables | 哈希表 | 查找、计数 |
| Math | Maths | 数学 | 数论、几何 |
| Stack | Stacks | 栈 | 单调栈、表达式 |
| Queue | Queues | 队列 | BFS、优先队列 |
| TwoPointers | TwoPointers | 双指针 | 快慢指针、对撞指针 |
| Sorting | Sortings | 排序 | 各种排序算法 |
| Simulation | Simulations | 模拟 | 按题意模拟过程 |

## 💡 使用建议

1. **先理解题意**：仔细阅读题目，理解输入输出
2. **分析复杂度**：考虑时间和空间复杂度
3. **多种解法**：尝试不同的解决方案
4. **编写测试**：验证解法的正确性
5. **添加注释**：说明算法思路和关键步骤
