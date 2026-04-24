namespace Leetcode;

public class Problem0724Test
{
    private readonly Solution724 _solution = new();
    
    [Theory]
    [InlineData(new[] { 1, 7, 3, 6, 5, 6 }, 3)]
    [InlineData(new[] { 1, 2, 3 }, -1)]
    [InlineData(new[] { 2, 1, -1 }, 0)]
    public void TestForN(int[] input, int target)
    {
        var result = _solution.PivotIndex(input);
        
        Assert.Equal(target, result);
    }
}

public class Solution724
{
    public int PivotIndex(int[] nums)
    {
        var totalSum = nums.Sum();
        var prefixSum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            prefixSum += nums[i];

            if (totalSum == prefixSum)
                return i;
            
            totalSum -= nums[i];
            
        }

        return -1;
    }
}