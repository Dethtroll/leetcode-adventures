namespace Leetcode;

public class Problem0064Test
{
    private readonly Solution64 _solution = new();

    [Fact]
    public void LongTest()
    {
        int[][] input = [[1, 3, 1], [1, 5, 1], [4, 2, 1]];
        
        var result = _solution.MinPathSum(input);
        
        Assert.Equal(7, result);
    }
    [Fact]
    public void ShortTest()
    {
        int[][] input = [[1,2,3],[4,5,6]];
        
        var result = _solution.MinPathSum(input);
        
        Assert.Equal(12, result);
    }
    }

public class Solution64
{
    public int MinPathSum(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var dp = new int[m+1, n+1];
        
        for (int i = 0; i <= m; i++)
        for (int j = 0; j <= n; j++)
            dp[i, j] = int.MaxValue;
        dp[1, 1] = grid[0][0];

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (i==1 && j==1)
                    continue;

                var newValue = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i - 1][j - 1]; 
                dp[i, j] = Math.Min(dp[i, j], newValue);
            }
        }
        
        return dp[m, n];
    }
}