namespace Leetcode;

public class Problem0063Test
{
    private readonly Solution63 _solution = new();

    [Fact]
    public void LongTest()
    {
        int[][] input = [[0, 0, 0], [0, 1, 0], [0, 0, 0]];
        
        var result = _solution.UniquePathsWithObstacles(input);
        
        Assert.Equal(2, result);
    }

    [Fact]
    public void ShortTest()
    {
        int[][] input = [[0, 1], [0, 0]];
        
        var result = _solution.UniquePathsWithObstacles(input);
        
        Assert.Equal(1, result);
    }
}

public class Solution63
{
    public void Solve()
    {
        var res = UniquePathsWithObstacles([[0,0,0],[0,1,0],[0,0,0]]);

        Console.WriteLine(res);
    }

    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        if (obstacleGrid[0][0] == 1)
            return 0;

        var m = obstacleGrid.Length;
        var n = obstacleGrid[0].Length;
        var dp = new int[m + 1, n + 1];
        dp[1, 1] = 1;

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (i == 1 && j == 1)
                    continue;
                if (obstacleGrid[i - 1][j - 1] == 1)
                    continue;

                dp[i, j] = dp[i, j - 1] + dp[i - 1, j];
            }
        }

        return dp[m, n];
    }
}