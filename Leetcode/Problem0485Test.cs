namespace Leetcode;

public class Problem0485Test
{
    private readonly Solution485 _solution = new();

    [Theory]
    [InlineData(new[] { 1, 1, 0, 1, 1, 1 }, 3)]
    [InlineData(new[] { 1, 0, 1, 1, 0, 1 }, 2)]
    public void TestForN(int[] input, int target)
    {
        var result = _solution.FindMaxConsecutiveOnes(input);

        Assert.Equal(target, result);
    }
}

public class Solution485
{
    public void Solve()
    {
        var res = FindMaxConsecutiveOnes([]);
        Console.WriteLine(res);
    }
    public int FindMaxConsecutiveOnes(int[] nums) {
        var max = 0;

        var len = 0;
        foreach (var num in nums)
        {
            if (num == 1)
            {
                len++;
                max = Math.Max(max, len);
            }
            else
                len = 0;
        }

        return max;
    }
}