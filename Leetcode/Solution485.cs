namespace Leetcode;

public class Solution485
{
    public void Solve()
    {
        var res = FindMaxConsecutiveOnes([1, 1, 0, 1, 1, 1]);
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