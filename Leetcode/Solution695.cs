namespace Leetcode;

public class Solution695
{
    public void Solve()
    {
        var res = MaxAreaOfIsland([
            [0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0],
            [0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0],
            [0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0],
            [0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0],
            [0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0],
            [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0],
            [0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0],
            [0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0]
        ]);
        Console.WriteLine(res);
    }
    public int MaxAreaOfIsland(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var maxArea = 0;
        var visited = new HashSet<(int, int)>();

        int Bfs(int row, int col)
        {
            if (row < 0 || grid.Length <= row || col < 0 || grid[row].Length <= col)
                return 0;
            if (grid[row][col] == 0)
                return 0;
            if (!visited.Add((row, col)))
                return 0;

            return 1
                   + Bfs(row - 1, col)
                   + Bfs(row + 1, col)
                   + Bfs(row, col - 1)
                   + Bfs(row, col + 1);
        }   
        
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
                if (grid[i][j] == 1)
                    maxArea = Math.Max(maxArea, Bfs(i, j));

        return maxArea;
    }
}