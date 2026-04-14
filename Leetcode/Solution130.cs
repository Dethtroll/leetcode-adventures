namespace Leetcode;

//time: O(m*n)
//mem: O(m*n)
public class Solution130
{
    public void Solve()
    {
        Solve([['X', 'X', 'X', 'X'], ['X', 'O', 'O', 'X'], ['X', 'X', 'O', 'X'], ['X', 'O', 'X', 'X']]);
    }

    public void Solve(char[][] board)
    {
        var m = board.Length;
        var n = board[0].Length;
        var visited = new bool[m, n];

        //помечаем крайние столбцы
        for (int i = 0; i < m; i++)
        {
            Dfs(board, i, 0, visited);
            Dfs(board, i, n - 1, visited);
        }

        //помечаем крайние строки
        for (int j = 0; j < n; j++)
        {
            Dfs(board, 0, j, visited);
            Dfs(board, m - 1, j, visited);
        }

        for (var i = 1; i < m - 1; i++)
            for (var j = 1; j < n - 1; j++)
                if (!visited[i, j])
                    board[i][j] = 'X';
    }
    
    private void Dfs(char[][] board, int row, int col, bool[,] visited)
    {
        if (row < 0 || board.Length <= row || col < 0 || board[row].Length <= col)
            return;

        if (visited[row, col])
            return;

        visited[row, col] = true;
        if (board[row][col] == 'X')
            return;

        board[row][col] = 'X';

        Dfs(board, row - 1, col, visited);
        Dfs(board, row + 1, col, visited);
        Dfs(board, row, col - 1, visited);
        Dfs(board, row, col + 1, visited);
    }
}