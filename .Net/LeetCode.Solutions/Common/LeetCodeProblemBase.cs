using LeetCode.Solutions.Common;

namespace LeetCode.Solutions.Common;

/// <summary>
/// Base abstract class for LeetCode problems
/// </summary>
/// <typeparam name="TInput">Input parameter type</typeparam>
/// <typeparam name="TOutput">Output result type</typeparam>
public abstract class LeetCodeProblemBase<TInput, TOutput> : ILeetCodeProblem<TInput, TOutput>
{
    public abstract int ProblemNumber { get; }
    public abstract string Title { get; }
    public abstract Difficulty Difficulty { get; }
    
    public virtual string Url => $"https://leetcode.com/problems/{GetUrlSlug()}/";
    
    public abstract TOutput Solve(TInput input);
    
    /// <summary>
    /// Get the URL slug for the problem (override if needed)
    /// </summary>
    protected virtual string GetUrlSlug()
    {
        return Title.ToLower()
            .Replace(" ", "-")
            .Replace(".", "")
            .Replace(",", "")
            .Replace("'", "")
            .Replace("(", "")
            .Replace(")", "");
    }
    
    /// <summary>
    /// Get formatted problem info
    /// </summary>
    public override string ToString()
    {
        return $"Problem {ProblemNumber}: {Title} ({Difficulty})";
    }
}
