namespace Leetcode;

public class Problem0268Test
{
    private readonly Solution268 _solution = new();

    [Theory]
    [InlineData(new[] { 3,0,1 }, 2)]
    [InlineData(new[] { 0,1 }, 2)]
    [InlineData(new[] { 9,6,4,2,3,5,7,0,1 }, 8)]
    public void TestForN(int[] input, int target)
    {
        var result = _solution.MissingNumber(input);
        
        Assert.Equal(target, result);
    }
}

public class Solution268 {
    public int MissingNumber(int[] nums)
    {
        long top = nums.Length * (1 + nums.Length);
        var sum = top / 2;

        // return (int) nums.Aggregate(sum, (acc, num) => acc - num);
        for (var i = 0; i < nums.Length; i++)
        {
            sum -= nums[i];
        }

        return (int)sum;
    }
}