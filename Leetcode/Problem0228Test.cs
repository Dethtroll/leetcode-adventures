namespace Leetcode;

public class Problem0228Test
{
    private readonly Solution228 _solution = new();

    [Theory]
    [InlineData(new[] { 0, 1, 2, 4, 5, 7 }, new[] { "0->2", "4->5", "7" })]
    [InlineData(new[] { 0, 2, 3, 4, 6, 8, 9 }, new[] { "0", "2->4", "6", "8->9" })]
    public void TestForN(int[] input, IList<string> target)
    {
        var result = _solution.SummaryRanges(input);

        Assert.Equivalent(target, result);
    }
}

public class Solution228
{
    public IList<string> SummaryRanges(int[] nums)
    {
        var res = new List<string>();
        if (nums.Length == 0)
            return res;

        var left = 0;
        var right = 0;
        
        while (left < nums.Length)
        {
            while (right + 1 < nums.Length && nums[right + 1] == nums[right] + 1)
                right++;
            
            res.Add(nums[left] == nums[right] ? nums[left].ToString() : $"{nums[left]}->{nums[right]}");

            left = right + 1;
            right = left;
        }

        return res;
    }
}