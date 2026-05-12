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
        var slow = 0;
        var fast = 0;

        do
        {
            slow =  nums[slow];
            fast = nums[nums[fast]];
            
        } while (slow != fast);

        slow = 0;
        while (slow != fast)
        {
            slow =  nums[slow];
            fast = nums[fast];
        }
        
        return slow;
    }
}