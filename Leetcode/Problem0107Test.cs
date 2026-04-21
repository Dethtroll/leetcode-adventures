using Leetcode.Common;
using Leetcode.Helpers;

namespace Leetcode;

public class Problem0107Test
{
    private readonly Solution107 _solution = new();

    private void BaseTest(int?[] input, int[][] target)
    {
        var result = _solution.LevelOrderBottom(input.ToBinTree());
        
        Assert.Equal(target, result);
    }

    [Fact]
    public void TestForEx1()
    {
        BaseTest([3,9,20,null,null,15,7], [[15,7],[9,20],[3]]);
    }

    [Fact]
    public void TestForEx2()
    {
        BaseTest([1], [[1]]);
    }

    [Fact]
    public void TestForEx3()
    {
        BaseTest([], []);
    }
}

public class Solution107 {
    public IList<IList<int>> LevelOrderBottom(TreeNode? root) {
        var result = new List<IList<int>>();

        BFS(root, 0, result);
        result.Reverse();
        
        return result;
    }

    private void BFS(TreeNode? node, int level, List<IList<int>> result)
    {
        if (node == null)
            return;
        
        if (result.Count == level)
            result.Add(new List<int>());
        
        result[level].Add(node.val);
        BFS(node.left, level + 1, result);
        BFS(node.right, level + 1, result);
    }
}