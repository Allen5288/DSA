# 🚀 How to Add New LeetCode Problems - Complete Guide

## 📋 **Quick Reference - 4 Ways to Add Problems**

| Method | Speed | Ease | Best For |
|--------|-------|------|----------|
| PowerShell Script | ⚡ Fastest | 🟢 Easiest | Windows users |
| .NET Command | ⚡ Fast | 🟢 Easy | Cross-platform |
| Manual Creation | 🐌 Slower | 🟡 Medium | Custom implementations |
| Template Class | 🐌 Slowest | 🔴 Advanced | Bulk generation |

---

## 🎯 **Method 1: PowerShell Script (Recommended)**

### Usage:
```bash
cd "/i/00_SoftwareDevopment/LeetCode/.Net"
powershell.exe -File "generate-problem.ps1" -Number <num> -Title "<title>" -Difficulty <level> -Category <category>
```

### Examples from your JS folder:
```bash
# Easy problems
powershell.exe -File "generate-problem.ps1" -Number 1295 -Title "Find Numbers with Even Number of Digits" -Difficulty Easy -Category Arrays
powershell.exe -File "generate-problem.ps1" -Number 1534 -Title "Count Good Triplets" -Difficulty Easy -Category Arrays
powershell.exe -File "generate-problem.ps1" -Number 2942 -Title "Find Words Containing Character" -Difficulty Easy -Category Strings

# Medium problems
powershell.exe -File "generate-problem.ps1" -Number 73 -Title "Set Matrix Zeroes" -Difficulty Medium -Category Arrays
powershell.exe -File "generate-problem.ps1" -Number 1007 -Title "Minimum Domino Rotations For Equal Row" -Difficulty Medium -Category Arrays
powershell.exe -File "generate-problem.ps1" -Number 838 -Title "Push Dominoes" -Difficulty Medium -Category Strings

# Hard problems
powershell.exe -File "generate-problem.ps1" -Number 368 -Title "Largest Divisible Subset" -Difficulty Hard -Category DynamicProgramming
```

### Available Categories:
- `Arrays`, `Strings`, `LinkedLists`, `Trees`, `Graphs`
- `DynamicProgramming`, `Sorting`, `Searching`, `Math`
- `Greedy`, `Backtracking`, `TwoPointers`, `SlidingWindow`
- `Stack`, `Queue`, `Heap`, `HashTable`, `BinarySearch`, `Bit`

---

## 🎯 **Method 2: .NET Command Line**

### Usage:
```bash
cd "/i/00_SoftwareDevopment/LeetCode/.Net"
dotnet run --project LeetCode.Solutions -- generate <number> "<title>" <difficulty> <category>
```

### Examples:
```bash
# Generate problems from your JS folder
dotnet run --project LeetCode.Solutions -- generate 1920 "Build Array from Permutation" Easy Arrays
dotnet run --project LeetCode.Solutions -- generate 790 "Domino and Tromino Tiling" Medium DynamicProgramming
dotnet run --project LeetCode.Solutions -- generate 3068 "Find the Maximum Sum of Node Values" Hard Trees
```

---

## 🎯 **Method 3: Manual Creation**

### Step-by-step:

1. **Create the solution file** in appropriate category folder:
```csharp
// Example: Problems/Arrays/CountGoodTriplets.cs
using LeetCode.Solutions.Common;

namespace LeetCode.Solutions.Problems.Arrays;

/// <summary>
/// 1534. Count Good Triplets
/// https://leetcode.com/problems/count-good-triplets/
/// 
/// Given an array of integers arr, and three integers a, b and c. 
/// You need to find the number of good triplets.
/// </summary>
public class CountGoodTriplets : LeetCodeProblemBase<(int[] arr, int a, int b, int c), int>
{
    public override int ProblemNumber => 1534;
    public override string Title => "Count Good Triplets";
    public override Difficulty Difficulty => Difficulty.Easy;

    /// <summary>
    /// Brute force approach - check all triplets
    /// Time Complexity: O(n³)
    /// Space Complexity: O(1)
    /// </summary>
    public override int Solve((int[] arr, int a, int b, int c) input)
    {
        var (arr, a, b, c) = input;
        int count = 0;
        int n = arr.Length;

        for (int i = 0; i < n - 2; i++)
        {
            for (int j = i + 1; j < n - 1; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    if (Math.Abs(arr[i] - arr[j]) <= a &&
                        Math.Abs(arr[j] - arr[k]) <= b &&
                        Math.Abs(arr[i] - arr[k]) <= c)
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }
}
```

2. **Create the test file**:
```csharp
// Example: LeetCode.Tests/Problems/Arrays/CountGoodTripletsTests.cs
using Xunit;
using LeetCode.Solutions.Problems.Arrays;
using LeetCode.Solutions.Common;

namespace LeetCode.Tests.Problems.Arrays;

public class CountGoodTripletsTests
{
    private readonly CountGoodTriplets _solution = new();

    [Theory]
    [InlineData(new int[] { 3, 0, 1, 1, 9, 7 }, 7, 2, 3, 4)]
    [InlineData(new int[] { 1, 1, 2, 2, 3 }, 0, 0, 1, 0)]
    public void Solve_ValidInput_ReturnsCorrectCount((int[] arr, int a, int b, int c) input, int expected)
    {
        // Act
        var result = _solution.Solve(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ProblemInfo_ShouldHaveCorrectMetadata()
    {
        // Assert
        Assert.Equal(1534, _solution.ProblemNumber);
        Assert.Equal("Count Good Triplets", _solution.Title);
        Assert.Equal(Difficulty.Easy, _solution.Difficulty);
    }
}
```

---

## 🎯 **Method 4: Batch Generation**

For adding multiple problems at once, create a batch script:

```bash
# Create: batch-generate.sh
#!/bin/bash

# Array of problems from your JS folder
problems=(
    "1295:Find Numbers with Even Number of Digits:Easy:Arrays"
    "1534:Count Good Triplets:Easy:Arrays"
    "1550:Three Consecutive Odds:Easy:Arrays"
    "2942:Find Words Containing Character:Easy:Strings"
    "73:Set Matrix Zeroes:Medium:Arrays"
    "75:Sort Colors:Medium:Sorting"
    "838:Push Dominoes:Medium:Strings"
    "368:Largest Divisible Subset:Hard:DynamicProgramming"
)

cd "/i/00_SoftwareDevopment/LeetCode/.Net"

for problem in "${problems[@]}"; do
    IFS=':' read -r number title difficulty category <<< "$problem"
    echo "Generating: $number - $title"
    powershell.exe -File "generate-problem.ps1" -Number "$number" -Title "$title" -Difficulty "$difficulty" -Category "$category"
    echo "---"
done

echo "✅ All problems generated!"
```

---

## 🧪 **Testing Your Solutions**

```bash
# Test a specific problem
dotnet test --filter "FullyQualifiedName~ProblemName"

# Test all problems in a category
dotnet test --filter "FullyQualifiedName~Arrays"

# Test all problems
dotnet test

# Build everything
dotnet build

# Run the demo application
dotnet run --project LeetCode.Solutions
```

---

## 📊 **Input/Output Type Examples**

### Common patterns:
```csharp
// Single array input, single value output
LeetCodeProblemBase<int[], int>

// Two parameters input, array output
LeetCodeProblemBase<(int[] nums, int target), int[]>

// Matrix input, void output (in-place modification)
LeetCodeProblemBase<int[][], int[][]>

// String input, boolean output
LeetCodeProblemBase<string, bool>

// Multiple parameters
LeetCodeProblemBase<(int[] arr, int a, int b, int c), int>
```

---

## 🚀 **Quick Start Examples**

### From your existing JS problems:

```bash
# Generate all counting problems
powershell.exe -File "generate-problem.ps1" -Number 1399 -Title "Count Largest Group" -Difficulty Easy -Category Math
powershell.exe -File "generate-problem.ps1" -Number 2176 -Title "Count Equal and Divisible Pairs in an Array" -Difficulty Easy -Category Arrays
powershell.exe -File "generate-problem.ps1" -Number 2843 -Title "Count Symmetric Integers" -Difficulty Easy -Category Math

# Generate array problems
powershell.exe -File "generate-problem.ps1" -Number 1920 -Title "Build Array from Permutation" -Difficulty Easy -Category Arrays
powershell.exe -File "generate-problem.ps1" -Number 3396 -Title "Minimum Number of Operations to Make Elements in Array Distinct" -Difficulty Medium -Category Arrays

# Generate string problems
powershell.exe -File "generate-problem.ps1" -Number 3335 -Title "Total Characters in String After Transformations I" -Difficulty Medium -Category Strings
```

---

## ✅ **Workflow Summary**

1. **Choose your method** (PowerShell script recommended)
2. **Generate the template** with correct input/output types
3. **Implement the solution** with time/space complexity comments
4. **Add comprehensive test cases**
5. **Run tests** to verify correctness
6. **Add to demo** in Program.cs if desired

This structure makes it easy to organize and maintain your LeetCode solutions! 🎉
