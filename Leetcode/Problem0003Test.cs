namespace Leetcode;

public class Problem0003Test
{
    private readonly Solution3 _solution = new();

    [Theory]
    [InlineData(3, "abcabcbb")]
    [InlineData(1, "bbbbb")]
    [InlineData(3, "pwwkew")]
    public void Test(int target, string input)
    {
        var res = _solution.LengthOfLongestSubstring(input);
        
        Assert.Equal(target, res);
    }
}

public class Solution3
{
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length == 0)
            return 0;
        var max = 1;

        var left = 0;
        var right = 0;
        var set = new HashSet<char> { s[0] };

        while (left < s.Length)
        {
            while (right + 1 < s.Length && set.Add(s[right + 1]))
            {
                right++;
            }

            max = Math.Max(max, right - left + 1);

            set.Remove(s[left]);
            left++;
        }

        return max;
    }
}