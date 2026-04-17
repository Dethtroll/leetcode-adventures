using Leetcode.Common;
using Leetcode.Helpers;

namespace Leetcode;

public class Problem0019Test
{
    private readonly Solution19 _solution = new();

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 2, new[] { 1, 2, 3, 5 })]
    [InlineData(new[] { 1 }, 1, new int[0])]
    [InlineData(new[] { 1, 2 }, 1, new[] { 1 })]
    public void TestForN(int[] input, int n, int[] output)
    {
        var list = input.ToLinkedList();

        var result = _solution.RemoveNthFromEnd(list!, n);

        foreach (var val in output)
        {
            Assert.Equal(result.val, val);
            result = result.next;
        }

        Assert.Null(result);
    }
}

public class Solution19
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var dummy = new ListNode(0, head);
        var fast = dummy;

        for (var i = 0; i < n; i++)
            fast = fast.next;

        var slow = dummy;
        while (fast?.next != null)
        {
            slow = slow?.next;
            fast = fast?.next;
        }

        slow?.next = slow.next?.next;

        return dummy.next;
    }
}