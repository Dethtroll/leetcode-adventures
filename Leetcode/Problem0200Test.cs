namespace Leetcode;

public class Problem0200Test
{
    private readonly Solution200 _solution = new();

    [Fact]
    public void DifficultIslandTest()
    {
        char[][] map =
        [
            ['1', '1', '1', '1', '0'],
            ['1', '1', '0', '1', '0'],
            ['1', '1', '0', '0', '0'],
            ['0', '0', '0', '0', '0']
        ];

        var res = _solution.NumIslands(map);

        Assert.Equal(1, res);
    }

    [Fact]
    public void ManyIslandsTest()
    {
        char[][] map =
        [
            ['1', '1', '0', '0', '0'],
            ['1', '1', '0', '0', '0'],
            ['0', '0', '1', '0', '0'],
            ['0', '0', '0', '1', '1']
        ];

        var res = _solution.NumIslands(map);

        Assert.Equal(3, res);
    }
}

public class Solution200
{
    public bool InBounds(int i, int j, char[][] grid)
    {
        if (i < 0 || j < 0 || i >= grid.Length || j >= grid[i].Length)
            return false;

        return true;
    }

    public void BFS(int i, int j, char[][] grid)
    {
        if (!InBounds(i, j, grid))
            return;
        if (grid[i][j] == '0' || grid[i][j] == '#')
            return;

        grid[i][j] = '#';
        
        BFS(i, j+1, grid);
        BFS(i-1, j, grid);
        BFS(i, j-1, grid);
        BFS(i+1, j, grid);
    }

    public int NumIslands(char[][] grid) {
        var m = grid.Length;
        var n = grid[0].Length;

        var result = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == '0' || grid[i][j] == '#')
                    continue;

                BFS(i, j, grid);
                result++;
            }
        }

        return result;
    }
}