using Leetcode.Common;
using Leetcode.Helpers;

namespace Leetcode;

public class Problem0102Test
{
    private readonly Solution102 _solution = new();

    private void BaseTest(int?[] input, List<List<int>> expected)
    {
        var tree = input.ToTree();
        
        var result = _solution.LevelOrder(tree!);
        
        Assert.Equal(expected, result);
    }

    [Fact]
    public void LongTest()
    {
        int?[] input = [3, 9, 20, null, null, 15, 7];
        List<List<int>> result = [[3], [9, 20], [15, 7]]; 
        
        BaseTest(input, result);
    }

    [Fact]
    public void ShortTest()
    {
        int?[] input = [1];
        List<List<int>> result = [[1]]; 
        
        BaseTest(input, result);
    }

    [Fact]
    public void EmptyTest()
    {
        int?[] input = [];
        List<List<int>> result = []; 
        
        BaseTest(input, result);
    }
}

public class Solution102 {
    public IList<IList<int>> LevelOrder(TreeNode? root)
    {
        var result = new List<IList<int>>();
        if (root == null) {
            return result;
        }

        Build(root, 0, result);
        
        return result;
    }

    private void Build(TreeNode node, int level, List<IList<int>> result)
    {
        if (level == result.Count)
        {
            result.Add(new List<int>());
        }
        result[level].Add(node.val);
        
        if(node.left != null)
            Build(node.left, level + 1, result);
        if (node.right != null)
            Build(node.right, level + 1, result);
    }
}