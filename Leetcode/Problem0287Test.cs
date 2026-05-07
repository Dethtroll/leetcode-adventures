namespace Leetcode;

public class Problem0287Test
{
    private readonly Solution287 _solution = new();

    [Theory]
    [InlineData(new[] { 1, 3, 4, 2, 2 }, 2)]
    [InlineData(new[] { 3, 1, 3, 4, 2 }, 3)]
    [InlineData(new[] { 3, 3, 3, 3, 3 }, 3)]
    public void TestForN(int[] input, int target)
    {
        var result = _solution.FindDuplicate(input);
        
        Assert.Equal(target, result);
    }
}

public class Solution287 {
    public int FindDuplicate(int[] nums)
    {
        var hash = new int[nums.Length + 1];
        foreach (var num in nums)
        {
            if (hash[num] > 0)
                return num;

            hash[num]++;
        }
        
        return 0;
    }
}