namespace Leetcode;

public class Problem0560Test
{
    private readonly Solution560 _solution = new();

    [Theory]
    [InlineData(new[] { 1, 1, 1 }, 2, 2)]
    [InlineData(new[] { 1, 2, 3 }, 3, 2)]
    public void TestForN(int[] input, int k, int count)
    {
        var result = _solution.SubarraySum(input, k);

        Assert.Equal(count, result);
    }
}

public class Solution560 {
    public int SubarraySum(int[] nums, int k)
    {
        var count = 0;
        var prefixSum = new Dictionary<int, int>{ { 0, 1 } };
        var currentPrefixSum = 0;

        foreach (var num in nums)
        {
            currentPrefixSum += num;

            var target = currentPrefixSum - k;
            if (prefixSum.TryGetValue(target, out var value)) 
                count += value;

            prefixSum[currentPrefixSum] = prefixSum.GetValueOrDefault(currentPrefixSum, 0) + 1;
        }

        return  count;
    }
}