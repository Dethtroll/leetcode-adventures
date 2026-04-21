using Leetcode.Common;
using Leetcode.Helpers;

namespace Leetcode;

public class Problem0199Test
{
    private readonly Solution199 _solution = new();
    
    [Fact]
    public void WideTest()
    {
        int?[] input = [1, 2, 3, null, 5, null, 4];

        var result = _solution.RightSideView(input.ToBinTree()!);
        
        Assert.Equal([1,3,4], result);
    }
    
    [Fact]
    public void HighTest()
    {
        int?[] input = [1,2,3,4,null,null,null,5];

        var result = _solution.RightSideView(input.ToBinTree()!);
        
        Assert.Equal([1,3,4,5], result);
    }

    [Fact]
    public void ShortTest()
    {
        int?[] input = [1,null,3];

        var result = _solution.RightSideView(input.ToBinTree()!);
        
        Assert.Equal([1,3], result);
    }

    [Fact]
    public void EmptyTest()
    {
        int?[] input = [];

        var result = _solution.RightSideView(input.ToBinTree()!);
        
        Assert.Equal([], result);
    }
}

public class Solution199 {
    public IList<int> RightSideView(TreeNode? root)
    {
        var result = new List<int>();
        if (root == null)
            return result;
        
        Builder(0, root, result);

        return result;
    }

    private void Builder(int level, TreeNode node, List<int> result)
    {
        if (result.Count == level)
            result.Add(node.val);
        else
            result[level] = node.val;
        
        if (node.left != null)
            Builder(level + 1, node.left, result);
        if (node.right != null)
            Builder(level + 1, node.right, result);
    }
}