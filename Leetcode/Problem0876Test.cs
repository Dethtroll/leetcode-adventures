namespace Leetcode;

public class Problem0876Test
{
    private readonly Solution876 _solution = new();

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 3, 4, 5 })]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6 }, new[] { 4, 5, 6 })]
    public void TestForN(int[] input, int[] output)
    {
        var dummy = new Solution876.ListNode();
        var current = dummy;
        foreach (var item in input)
        {
            current.next = new Solution876.ListNode(item);
            current = current.next;
        }

        var result = _solution.MiddleNode(dummy.next!);

        foreach (var val in output)
        {
            Assert.Equal(result.val, val);
            result = result.next;
        }

        Assert.Null(result);
    }
}

public class Solution876
{
    public ListNode MiddleNode(ListNode head)
    {
        var fast = head;
        var slow = head;

        while (fast?.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        
        return slow;
    }

    public class ListNode
    {
        public int val;
        public ListNode? next;

        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}