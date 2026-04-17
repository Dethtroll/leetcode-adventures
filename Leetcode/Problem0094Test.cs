using Leetcode.Common;
using Leetcode.Helpers;

namespace Leetcode;

public class Problem0094Test
{
    private readonly Solution94 _solution = new();

    private void BaseTest(int?[] input, int[] expected)
    {
        var tree = input.ToTree();
        
        var resultStack = _solution.InorderTraversal(tree);
        var resultRecursive = _solution.InorderTraversalRecursive(tree);
        
        Assert.Equal(expected, resultStack.ToArray());
        Assert.Equal(expected, resultRecursive.ToArray());
    }

    [Fact]
    public void LongTest()
    {
        BaseTest([1, 2, 3, 4, 5, null, 8, null, null, 6, 7, null, null, 9], [4, 2, 6, 5, 7, 1, 3, 9, 8]);
    }
    [Fact]
    public void ShortTest()
    {
        BaseTest([ 1, null, 2, null, null, 3 ], [ 1, 3, 2 ]);
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

public class Solution94 {
    public IList<int> InorderTraversal(TreeNode? root) {
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

            if (data.node.right != null)
                stack.Push((data.node.right, false));
            stack.Push((data.node, true));
            if (data.node.left != null)
                stack.Push((data.node.left, false));
        }
        
        return result;
    }
    public IList<int> InorderTraversalRecursive(TreeNode? root) {
        var result = new List<int>();        
        
        FillNode(root, result);
        
        return result;
    }

    private void FillNode(TreeNode? node, List<int> result)
    {
        if (node == null)
            return;
        
        FillNode(node.left, result);
        result.Add(node.val);
        FillNode(node.right, result);
    }
}
