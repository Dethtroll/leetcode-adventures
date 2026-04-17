using Leetcode.Common;
using Leetcode.Helpers;

namespace Leetcode;

public class Problem0145Test
{
    private readonly Solution145 _solution = new();

    private void BaseTest(int?[] input, int[] expected)
    {
        var tree = input.ToTree();
        
        var resultStack = _solution.PostorderTraversal(tree);
        var resultRecursive = _solution.PostorderTraversalRecursive(tree);
        
        Assert.Equal(expected, resultStack.ToArray());
        Assert.Equal(expected, resultRecursive.ToArray());
    }

    [Fact]
    public void LongTest()
    {
        BaseTest([1, 2, 3, 4, 5, null, 8, null, null, 6, 7, null, null, 9], [4, 6, 7, 5, 2, 9, 8, 3, 1]);
    }
    [Fact]
    public void ShortTest()
    {
        BaseTest([ 1, null, 2, null, null, 3 ], [ 3, 2, 1 ]);
    }
    [Fact]
    public void EmptyTest()
    {
        BaseTest([], []);
    }
    [Fact]
    public void SingleTest()
    {
        BaseTest([1], [1]);
    }
}

public class Solution145 {
    public IList<int> PostorderTraversal(TreeNode? root) {
        var result = new List<int>();
        if (root == null)
            return result;

        var stack = new Stack<(TreeNode node, bool processed)>();
        stack.Push((root, false));

        while (stack.Any())
        {
            var data = stack.Pop();
            if (data.processed)
            {
                result.Add(data.node.val);
                continue;
            }

            stack.Push((data.node, true));
            if (data.node.right != null)
                stack.Push((data.node.right, false));
            if (data.node.left != null)
                stack.Push((data.node.left, false));
        }
        
        return result;
    }
    public IList<int> PostorderTraversalRecursive(TreeNode? root) {
        var result = new List<int>();        
        
        FillNode(root, result);
        
        return result;
    }

    private void FillNode(TreeNode? node, List<int> result)
    {
        if (node == null)
            return;
        
        FillNode(node.left, result);
        FillNode(node.right, result);
        result.Add(node.val);
    }
}