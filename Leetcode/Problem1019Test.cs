using Leetcode.Common;
using Leetcode.Helpers;

namespace Leetcode;

public class Problem1019Test
{
    private readonly Solution1019 _solution = new();

    [Theory]
    [InlineData(new[] { 2, 1, 5 }, new[] { 5, 5, 0 })]
    [InlineData(new[] { 2, 7, 4, 3, 5 }, new[] { 7, 0, 5, 5, 0 })]
    public void TestForN(int[] input, int[] target)
    {
        var list = input.ToLinkedList();

        var result = _solution.NextLargerNodes(list);
        var result2 = _solution.NextLargerNodes2(list);
        
        Assert.Equivalent(target, result);
        Assert.Equivalent(target, result2);
    }
}

public class Solution1019
{
    public int[] NextLargerNodes(ListNode? head)
    {
        var result = new List<int>();
        var stack = new Stack<(int index, int value)>();  

        var i = 0;
        while (head != null)
        {
            while (stack.Count > 0 && stack.Peek().value < head.val)
            {
                var (index, value) = stack.Pop();
                result[index] = head.val;
            }
            
            stack.Push((i, head.val));
            result.Add(0);

            head = head.next;
            i++;
        }
        
        return  result.ToArray();
    }

    public int[] NextLargerNodes2(ListNode? head)
    {
        var data = new List<int>();
        while (head != null)
        {
            data.Add(head.val);
            head = head.next;
        }

        var result = new int[data.Count];
        var stack = new Stack<int>();
        for (int i = 0; i < data.Count; i++)
        {
            while (stack.Count > 0 && data[stack.Peek()] < data[i])
                result[stack.Pop()] = data[i];

            stack.Push(i);
        }

        return result;
    }
}