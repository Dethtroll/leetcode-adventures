namespace Leetcode;

public class Solution228
{
    public void Solve()
    {
        var res = SummaryRanges([0, 1, 2, 4, 5, 7]);
        Console.WriteLine(string.Join(',', res));
        
        res = SummaryRanges([0,2,3,4,6,8,9]);
        Console.WriteLine(string.Join(',', res));
    }
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