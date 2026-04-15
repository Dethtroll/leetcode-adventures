namespace Leetcode;

public class Problem0019Test
{
    private readonly Solution0019 _solution = new();

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 2, new[] { 1, 2, 3, 5 })]
    [InlineData(new[] { 1 }, 1, new int[0])]
    [InlineData(new[] { 1, 2 }, 1, new[] { 1 })]
    public void TestForN(int[] input, int n, int[] output)
    {
        var dummy = new ListNode();
        var current = dummy;
        foreach (var item in input)
        {
            current.next = new ListNode(item);
            current = current.next;
        }

        var result = _solution.RemoveNthFromEnd(dummy.next!, n);

        foreach (var val in output)
        {
            Assert.Equal(result.val, val);
            result = result.next;
        }

        Assert.Null(result);
    }
}

public class Solution0019
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

public class ListNode
{
    public int val;
    public ListNode? next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}