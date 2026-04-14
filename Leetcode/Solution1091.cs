namespace Leetcode;

public class Solution1091
{
    public void Solve()
    {
        var res = ShortestPathBinaryMatrix([[0, 0, 0], [1, 1, 0], [1, 1, 0]]);
        Console.WriteLine(res);
    }

    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        var n = grid.Length;
        if (grid[0][0] != 0 || grid[n - 1][n - 1] != 0)
            return -1;
        if (n == 1)
            return 1;

        var queue = new Queue<(int len, int x, int y)>();
        var visited = new HashSet<(int, int)>();
        var steps = new (int, int)[]
        {
            (0, 1), //вправо
            (0, -1), //влево
            (1, 0), //вниз
            (-1, 0), //вверх
            (-1, -1), //вверх и влево
            (-1, 1), //вверх и вправо
            (1, 1), //вниз и вправо
            (1, -1), //вниз и влево
        };

        queue.Enqueue((1, 0, 0));
        visited.Add((0, 0));

        while (queue.Count > 0)
        {
            var (pathLen, x, y) = queue.Dequeue();
            if (x == n - 1 && y == n - 1)
                return pathLen;

            foreach (var step in steps)
            {
                var nextX = x + step.Item2;
                var nextY = y + step.Item1;

                if (nextX < 0 || nextX >= n || nextY < 0 || nextY >= n)
                    continue;
                if (grid[nextY][nextX] == 1)
                    continue;
                if (!visited.Add((nextX, nextY)))
                    continue;

                queue.Enqueue((pathLen + 1, nextX, nextY));
            }
        }

        return -1;
    }
}