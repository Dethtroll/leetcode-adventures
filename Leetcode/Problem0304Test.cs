namespace Leetcode;

public class Problem0304Test
{
    [Theory]
    [InlineData(new int[] { 2, 1, 4, 3 }, 8)]
    [InlineData(new int[] {1, 1, 2, 2 }, 11)]
    [InlineData(new int[] { 1, 2, 2, 4 }, 12)]
    public void PositiveTest(int[] points, int target)
    {
        int[][] matrix = [
            [3, 0, 1, 4, 2], 
            [5, 6, 3, 2, 1], 
            [1, 2, 0, 1, 5], 
            [4, 1, 0, 1, 7], 
            [1, 0, 3, 0, 5]
        ];
        var solution = new NumMatrix(matrix);
        
        var result = solution.SumRegion(points[0], points[1], points[2], points[3]);
        
        Assert.Equal(target, result);
    }
}

public class NumMatrix
{
    private readonly int[,] _prefixSum;
    public NumMatrix(int[][] matrix) {
        _prefixSum = new int[matrix.Length + 1, matrix[0].Length + 1];

        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[0].Length; j++)
            {
                _prefixSum[i + 1, j + 1] = matrix[i][j]
                    + _prefixSum[i, j + 1]
                    + _prefixSum[i + 1, j]
                    - _prefixSum[i, j];
            }
        }
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2)
    {
        return _prefixSum[row2 + 1, col2 + 1]
               - _prefixSum[row1, col2 + 1]
               - _prefixSum[row2 + 1, col1]
               + _prefixSum[row1, col1];
    }
}