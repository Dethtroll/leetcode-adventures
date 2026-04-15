namespace Leetcode;

public class Problem0849Test
{
    private readonly Solution849 _solution = new();

    [Theory]
    [InlineData(new int[] { 1, 0, 0, 0, 1, 0, 1 }, 2)]
    [InlineData(new int[] { 1,0,0,0 }, 3)]
    [InlineData(new int[] { 0,1 }, 1)]
    public void TestForN(int[] input, int target)
    {
        var result = _solution.MaxDistToClosest(input);
        
        Assert.Equal(target, result);
    }
}

public class Solution849
{
    public int MaxDistToClosest(int[] seats)
    {
        var res = 0;
        var left = 0;

        while (left < seats.Length)
        {
            while (left < seats.Length && seats[left] == 1)
            {
                left++;
            }

            var right = left;
            while (right + 1 < seats.Length && seats[right + 1] == 0)
            {
                right++;
            }
            if (right >= seats.Length)
                break;

            if (left == 0 || right == seats.Length - 1)
                res = Math.Max(res, right - left + 1);
            else
                res = Math.Max(res, (right - left) / 2 + 1);
            
            left = right + 1;
        }

        return res;
    }
}