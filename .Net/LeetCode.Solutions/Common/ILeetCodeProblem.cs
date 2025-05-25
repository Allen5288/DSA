namespace LeetCode.Solutions.Common;

/// <summary>
/// Interface for LeetCode problems
/// </summary>
/// <typeparam name="TInput">Input parameter type</typeparam>
/// <typeparam name="TOutput">Output result type</typeparam>
public interface ILeetCodeProblem<in TInput, out TOutput>
{
    /// <summary>
    /// Problem number from LeetCode
    /// </summary>
    int ProblemNumber { get; }
    
    /// <summary>
    /// Problem title
    /// </summary>
    string Title { get; }
    
    /// <summary>
    /// Problem difficulty level
    /// </summary>
    Difficulty Difficulty { get; }
    
    /// <summary>
    /// Problem URL on LeetCode
    /// </summary>
    string Url { get; }
    
    /// <summary>
    /// Solve the problem
    /// </summary>
    /// <param name="input">Input parameters</param>
    /// <returns>Solution result</returns>
    TOutput Solve(TInput input);
}

/// <summary>
/// Difficulty levels for LeetCode problems
/// </summary>
public enum Difficulty
{
    Easy,
    Medium,
    Hard
}
