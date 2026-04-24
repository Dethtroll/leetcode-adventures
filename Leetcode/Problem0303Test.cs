namespace Leetcode;

public class Problem0303Test
{
    [Theory]
    [InlineData(new[] { -2, 0, 3, -5, 2, -1 }, 0, 2, 1)]
    [InlineData(new[] { -2, 0, 3, -5, 2, -1 }, 2, 5, -1)]
    [InlineData(new[] { -2, 0, 3, -5, 2, -1 }, 0, 5, -3)]
    public void TestForN(int[] input, int leftBound, int rightBound, int target)
    {
        var numArray = new NumArray(input);
        var result = numArray.SumRange(leftBound, rightBound);

        Assert.Equal(target, result);
    }
}

public class NumArray
{
    readonly int[] _prefixSum;

    public NumArray(int[] nums)
    {
        _prefixSum = new int[nums.Length + 1];
        for (int i = 0; i < nums.Length; i++)
        {
            _prefixSum[i + 1] = _prefixSum[i] + nums[i];
        }
    }

    public int SumRange(int left, int right)
    {
        return _prefixSum[right + 1] - _prefixSum[left];
    }
}