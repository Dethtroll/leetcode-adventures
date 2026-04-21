using Leetcode.Common;
using Leetcode.Helpers;

namespace Leetcode;

public class Problem0112Test
{
    private readonly Solution112 _solution = new();

    private void BaseTest(int?[] input, int sum, bool target)
    {
        var result = _solution.HasPathSum(input.ToTree()!, sum);
        
        Assert.Equal(target, result);
    }
    
    [Fact]
    public void PositiveTest()
    {
        BaseTest([5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1], 22, true);
    }

    [Fact]
    public void NegativeTest()
    {
        BaseTest([1,2,3], 5, false);
    }

    [Fact]
    public void EmptyTest()
    {
        BaseTest([], 0, false);
    }
}

public class Solution112 {
    public bool HasPathSum(TreeNode? root, int targetSum)
    {
        if (root == null)
            return false;

        if (root.val == targetSum && root.left == null && root.right == null)
            return true;
        
        return HasPathSum(root.left, targetSum - root.val)
            || HasPathSum(root.right, targetSum - root.val);
    }
}