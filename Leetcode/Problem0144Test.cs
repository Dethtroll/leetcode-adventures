using Leetcode.Common;
using Leetcode.Helpers;

namespace Leetcode;

public class Problem0144Test
{
    private readonly Solution144 _solution = new();

    private void BaseTest(int?[] input, int[] expected)
    {
        var tree = input.ToTree();
        
        var resultStack = _solution.PreorderTraversal(tree);
        var resultRecursive = _solution.PreorderTraversalRecursive(tree);
        
        Assert.Equal(expected, resultStack.ToArray());
        Assert.Equal(expected, resultRecursive.ToArray());
    }

    [Fact]
    public void LongTest()
    {
        BaseTest([1, 2, 3, 4, 5, null, 8, null, null, 6, 7, null, null, 9], [1, 2, 4, 5, 6, 7, 3, 8, 9]);
    }
    [Fact]
    public void ShortTest()
    {
        BaseTest([ 1, null, 2, null, null, 3 ], [ 1, 2, 3 ]);
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

public class Solution144
{
    public IList<int> PreorderTraversal(TreeNode? root)
    {
        var result = new List<int>();
        if (root == null)
            return result;

        var queue = new Stack<TreeNode>();
        queue.Push(root);

        while (queue.Count > 0)
        {
            var node = queue.Pop();
            result.Add(node.val);
            
            if (node.right != null)
                queue.Push(node.right);
            if (node.left != null)
                queue.Push(node.left);
        }
        
        return result;
    }
    
    public IList<int> PreorderTraversalRecursive(TreeNode? root) {
        var result = new List<int>();

        FillNode(root, result);

        return result;
    }

    private void FillNode(TreeNode? node, List<int> result) {
        if (node == null) {
            return;
        }

        result.Add(node.val);
        FillNode(node.left, result);
        FillNode(node.right, result);
    }
}