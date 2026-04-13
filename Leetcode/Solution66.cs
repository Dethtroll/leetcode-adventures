namespace Leetcode;

public class Solution66
{
    public void Solve()
    {
        var res = MinPathSum([[1,2,3],[4,5,6]]);
        Console.WriteLine(res);
    }
    
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