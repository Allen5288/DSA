# 🚀 LeetCode Solutions in C#

This project contains organized C# solutions for LeetCode problems with a well-structured architecture.

## 📁 Project Structure

```
LeetCode.sln                    # Solution file
├── LeetCode.Solutions/         # Main solutions project
│   ├── Common/                 # Common interfaces and base classes
│   │   ├── ILeetCodeProblem.cs
│   │   ├── LeetCodeProblemBase.cs
│   │   └── ProblemTemplateGenerator.cs
│   ├── Problems/               # Organized by categories
│   │   ├── Arrays/
│   │   ├── Strings/
│   │   ├── LinkedLists/
│   │   ├── Trees/
│   │   ├── Graphs/
│   │   ├── DynamicProgramming/
│   │   ├── Sorting/
│   │   ├── Searching/
│   │   ├── Math/
│   │   ├── Greedy/
│   │   ├── Backtracking/
│   │   ├── TwoPointers/
│   │   ├── SlidingWindow/
│   │   ├── Stack/
│   │   ├── Queue/
│   │   ├── Heap/
│   │   ├── HashTable/
│   │   ├── BinarySearch/
│   │   └── Bit/
│   └── Program.cs              # Main program to run examples
└── LeetCode.Tests/             # Unit tests project
    └── Problems/               # Test files organized by categories
```

## 🏗️ How to Add a New Problem

### Method 1: Manual Creation

1. Create a new class in the appropriate category folder under `Problems/`
2. Inherit from `LeetCodeProblemBase<TInput, TOutput>`
3. Implement the required properties and `Solve` method
4. Create corresponding test file in the `LeetCode.Tests` project

### Method 2: Using Template Generator

You can use the `ProblemTemplateGenerator` class to generate templates:

```csharp
var problemTemplate = ProblemTemplateGenerator.GenerateProblemTemplate(
    problemNumber: 1,
    title: "Two Sum",
    difficulty: "Easy",
    category: "Arrays",
    description: "Find two numbers that add up to target",
    inputType: "(int[] nums, int target)",
    outputType: "int[]"
);

var testTemplate = ProblemTemplateGenerator.GenerateTestTemplate(
    problemNumber: 1,
    title: "Two Sum",
    category: "Arrays",
    inputType: "(int[] nums, int target)",
    outputType: "int[]"
);
```

### Example Problem Implementation

```csharp
using LeetCode.Solutions.Common;

namespace LeetCode.Solutions.Problems.Arrays;

/// <summary>
/// 1. Two Sum
/// https://leetcode.com/problems/two-sum/
/// 
/// Given an array of integers nums and an integer target, 
/// return indices of the two numbers such that they add up to target.
/// </summary>
public class TwoSum : LeetCodeProblemBase<(int[] nums, int target), int[]>
{
    public override int ProblemNumber => 1;
    public override string Title => "Two Sum";
    public override Difficulty Difficulty => Difficulty.Easy;

    public override int[] Solve((int[] nums, int target) input)
    {
        var (nums, target) = input;
        var map = new Dictionary<int, int>();
        
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if (map.ContainsKey(complement))
            {
                return new int[] { map[complement], i };
            }
            map[nums[i]] = i;
        }
        
        throw new ArgumentException("No two sum solution");
    }
}
```

## 🧪 Running Tests

```bash
# Run all tests
dotnet test

# Run tests for a specific category
dotnet test --filter "FullyQualifiedName~Sorting"

# Run tests for a specific problem
dotnet test --filter "FullyQualifiedName~SortColors"
```

## 🏃‍♂️ Running the Application

```bash
# Run the console application
dotnet run --project LeetCode.Solutions

# Build the solution
dotnet build

# Restore packages
dotnet restore
```

## 📊 Problem Categories

- **Arrays**: Array manipulation, searching, sorting
- **Strings**: String processing, pattern matching
- **LinkedLists**: Linked list operations
- **Trees**: Binary trees, BST, tree traversal
- **Graphs**: Graph algorithms, DFS, BFS
- **DynamicProgramming**: DP problems and optimizations
- **Sorting**: Sorting algorithms and related problems
- **Searching**: Binary search and variations
- **Math**: Mathematical problems and number theory
- **Greedy**: Greedy algorithms
- **Backtracking**: Backtracking and recursion
- **TwoPointers**: Two-pointer technique
- **SlidingWindow**: Sliding window problems
- **Stack**: Stack-based solutions
- **Queue**: Queue and deque problems
- **Heap**: Priority queue and heap problems
- **HashTable**: Hash table and hash map solutions
- **BinarySearch**: Binary search variations
- **Bit**: Bit manipulation problems

## 🎯 Features

- ✅ Organized by problem categories
- ✅ Consistent interface for all problems
- ✅ Unit tests for each solution
- ✅ Multiple solution approaches when applicable
- ✅ Time and space complexity documentation
- ✅ Template generator for new problems
- ✅ Easy to run and test individual problems

## 🤝 Contributing

1. Choose a problem category
2. Create the solution class
3. Add comprehensive unit tests
4. Document time/space complexity
5. Add example usage in Program.cs if needed

Happy coding! 🎉
