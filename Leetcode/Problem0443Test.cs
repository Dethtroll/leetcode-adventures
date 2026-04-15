namespace Leetcode;

public class Problem0443Test
{
    private readonly Solution443 _solution = new();

    [Theory]
    [InlineData(new[]{'a', 'a', 'b', 'b', 'c', 'c', 'c'}, 6, new[]{'a', '2', 'b', '2', 'c', '3'})]
    [InlineData(new[]{'a'}, 1, new[]{'a'})]
    [InlineData(new[]{'a','b','b','b','b','b','b','b','b','b','b','b','b'}, 4, new[]{'a', 'b', '1', '2'})]
    public void TestForN(char[] input, int targetLen, char[] targetValue)
    {
        var result = _solution.Compress(input);

        Assert.Equal(targetLen, result);
        Assert.Equivalent(targetValue, input);
    }
}

public class Solution443
{
    public int Compress(char[] chars) {
        var left = 0;
        var pointer = 0;

        while (left < chars.Length)
        {
            var right = left;
            while (right + 1 < chars.Length && chars[right + 1] == chars[left])
                right++;

            right = right == chars.Length ? chars.Length - 1 : right;

            chars[pointer] = chars[left];
            pointer++;
            if (right - left > 0)
            {
                foreach (var ch in (right - left + 1).ToString())
                {
                    chars[pointer] = ch;
                    pointer++;
                }
            }
            
            left = right + 1;
        }

        return pointer;
    }
}