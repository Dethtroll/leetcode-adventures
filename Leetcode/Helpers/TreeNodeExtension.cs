using Leetcode.Common;

namespace Leetcode.Helpers;

public static class TreeNodeExtension
{
    public static TreeNode? ToTree(this int?[] data)
    {
        return GetNode(0, data);
    }
    
    private static TreeNode? GetNode(int index, int?[] values)
    {
        if (index >= values.Length)
            return null;
        var value = values[index];
        if (value == null)
            return null;
        
        var left = GetNode(index*2 + 1, values);
        var right = GetNode(index*2 + 2, values);

        return new TreeNode(value.Value, left, right);
    }
}