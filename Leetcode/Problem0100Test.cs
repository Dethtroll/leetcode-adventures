using Leetcode.Common;
using Leetcode.Helpers;

namespace Leetcode;

public class Problem0100Test
{
    private readonly Solution100 _solution = new();

    private void BaseTest(int?[] left, int?[] right, bool target)
    {
        var result = _solution.IsSameTree(left.ToBinTree()!, right.ToBinTree()!);
        
        Assert.Equal(target, result);
    }

    [Fact]
    public void PositiveTest()
    {
        BaseTest([1, 2, 3], [1, 2, 3], true);
    }

    [Fact]
    public void NegativeTest()
    {
        BaseTest([1,2,1], [1, 1, 2], false);
    }

    [Fact]
    public void SymetricTest()
    {
        BaseTest([1,2], [1, null, 2], false);
    }
}
public class Solution100 {
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        return Compare(p, q);
    }
    
    public bool Compare(TreeNode? left, TreeNode? right)
    {
        if (left is null && right is null)
            return true;
        
        if (left?.val != right?.val)
            return false;
        
        return Compare(left?.left, right?.left)
               && Compare(left?.right, right?.right);
    }
}