using Leetcode.Common;
using Leetcode.Helpers;

namespace Leetcode;

public class Problem0101Test
{
    private readonly Solution101 _solution = new();

    private void BaseTest(int?[] input, bool target)
    {
        var result = _solution.IsSymmetric(input.ToBinTree());
        
        Assert.Equal(target, result);
    }

    [Fact]
    public void PositiveTest()
    {
        int?[] tree = [1, 2, 2, 3, 4, 4, 3];
        
        BaseTest(tree, true);
    }

    [Fact]
    public void NegativeTest()
    {
        int?[] tree = [1,2,2,null,3,null,3];
        
        BaseTest(tree, false);
    }
}
public class Solution101 {
    public bool IsSymmetric(TreeNode? root) {
        return Compare(root?.left, root?.right);
    }
    
    public bool Compare(TreeNode? left, TreeNode? right)
    {
        if (left is null && right is null)
            return true;
        
        if (left?.val != right?.val)
            return false;
        
        return Compare(left?.left, right?.right)
            && Compare(left?.right, right?.left);
    }
}