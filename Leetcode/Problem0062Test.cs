namespace Leetcode;

public class Problem0062Test
{
    private readonly Solution62 _solution = new();

    [Theory]
    [InlineData(3, 7, 28)]
    [InlineData(3, 2, 3)]
    public void TestForAll(int m, int n, int expected)
    {
        var res = _solution.UniquePaths(m, n);
        
        Assert.Equal(expected, res);
    }
}

public class Solution62
{
    public int UniquePaths(int m, int n) {
        var dp = new int[m+1, n+1];
        dp[1, 1] = 1;

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (i == 1 && j == 1)
                    continue;
                
                dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
            }
        }

        return dp[m, n];
    }
}