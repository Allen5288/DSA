# 🚀 Quick Start Guide - LeetCode .NET Solutions

## 📁 Project Structure Created

Your `.Net` folder now contains a complete, well-organized .NET solution for LeetCode problems:

```
LeetCode.sln                    # Main solution file
├── LeetCode.Solutions/         # Solutions project
│   ├── Common/                 # Base classes and interfaces
│   ├── Problems/               # Organized by categories
│   │   ├── Arrays/
│   │   ├── Strings/
│   │   ├── LinkedLists/
│   │   ├── Trees/
│   │   ├── Graphs/
│   │   ├── DynamicProgramming/
│   │   ├── Sorting/            # Contains SortColors example
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
│   └── Program.cs              # Demo application
├── LeetCode.Tests/             # Unit tests project
├── generate-problem.ps1        # PowerShell script to create new problems
├── generate-problem.sh         # Bash script to create new problems
└── README.md                   # Detailed documentation
```

## 🎯 What's Already Working

✅ **Complete solution with Sort Colors (Problem 75)** - using Dutch National Flag algorithm  
✅ **15 unit tests passing** - comprehensive test coverage  
✅ **Template generators** - for quick problem creation  
✅ **Organized structure** - by problem categories  
✅ **Console demo** - showing example execution  

## 🚀 How to Add New Problems

### Method 1: Using PowerShell Script (Recommended for Windows)

```powershell
# Navigate to the .Net folder
cd "i:\00_SoftwareDevopment\LeetCode\.Net"

# Generate a new problem (example: Two Sum)
.\generate-problem.ps1 -Number 1 -Title "Two Sum" -Difficulty Easy -Category Arrays
```

### Method 2: Using Bash Script

```bash
# Navigate to the .Net folder
cd "/i/00_SoftwareDevopment/LeetCode/.Net"

# Generate a new problem
./generate-problem.sh 1 "Two Sum" Easy Arrays
```

### Method 3: Manual Creation

1. Create a new class in the appropriate category folder under `Problems/`
2. Inherit from `LeetCodeProblemBase<TInput, TOutput>`
3. Implement required properties and `Solve` method
4. Create corresponding test file

## 🏃‍♂️ Common Commands

```bash
# Build the solution
dotnet build

# Run all tests
dotnet test

# Run tests for specific category
dotnet test --filter "FullyQualifiedName~Sorting"

# Run the demo application
dotnet run --project LeetCode.Solutions

# Create a new problem using the generator
dotnet run --project LeetCode.Solutions -- generate 42 "Trapping Rain Water" Hard Arrays
```

## 📝 Example Problem Implementation

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

    /// <summary>
    /// Solve using HashMap approach
    /// Time Complexity: O(n)
    /// Space Complexity: O(n)
    /// </summary>
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

## 🧪 Example Test Implementation

```csharp
using Xunit;
using LeetCode.Solutions.Problems.Arrays;

namespace LeetCode.Tests.Problems.Arrays;

public class TwoSumTests
{
    private readonly TwoSum _solution = new();

    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    public void Solve_ValidInput_ReturnsExpected(int[] nums, int target, int[] expected)
    {
        // Act
        var result = _solution.Solve((nums, target));

        // Assert
        Assert.Equal(expected, result);
    }
}
```

## 🎨 Features

- **Type-safe interfaces** - Generic base classes for different input/output types
- **Automatic URL generation** - Problem URLs generated from titles
- **Metadata tracking** - Problem number, title, difficulty, and URL
- **Multiple solutions** - Support for different approaches to the same problem
- **Comprehensive testing** - Unit tests with multiple test cases
- **Documentation** - XML comments with time/space complexity
- **Template generation** - Quick scaffolding for new problems

## 📊 Next Steps

1. **Add more problems** - Use the generator scripts to add problems from your JS folder
2. **Organize by topics** - Group similar problems together
3. **Add performance benchmarks** - Compare different solution approaches
4. **Create problem sets** - Group problems by difficulty or topic for study sessions

Happy coding! 🎉
