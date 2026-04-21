using Leetcode.Common;
using Leetcode.Helpers;

namespace Leetcode;

public class Problem0111Test
{
    private readonly Solution111 _solution = new();

    private void BaseTest(int?[] input, int target)
    {
        var result = _solution.MinDepth(input.ToTree()!);
        
        Assert.Equal(target, result);
    }

    [Fact]
    public void ShortTest()
    {
        BaseTest([3,9,20,null,null,15,7], 2);
    }

    [Fact]
    public void LongTest()
    {
        BaseTest(
        [
            2,
            null, 3,
            null, null, null, 4,
            null, null, null, null, null, null, null, 5,
            null, null, null, null, null, null,null, null, null, null, null, null, null, null, null, 6
        ], 5);
    }
}

public class Solution111 {
    public int MinDepth(TreeNode? root) {
        if (root == null)
            return 0;
        
        if (root.left == null && root.right == null)
        {
            return 1;
        }
        
        var leftMin = root.left != null ? MinDepth(root.left) : int.MaxValue;
        var rightMin = root.right != null ? MinDepth(root.right) : int.MaxValue;
        
        return Math.Min(leftMin, rightMin) + 1;
    }
}