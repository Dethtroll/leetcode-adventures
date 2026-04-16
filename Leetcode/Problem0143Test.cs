namespace Leetcode;

public class Problem0143Test
{
    private readonly Solution143 _solution = new();

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4 }, new[] { 1, 4, 2, 3 })]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 1, 5, 2, 4, 3 })]
    public void TestForN(int[] input, int[] output)
    {
        var dummy = new Solution143.ListNode();
        var current = dummy;
        foreach (var item in input)
        {
            current.next = new Solution143.ListNode(item);
            current = current.next;
        }

        _solution.ReorderList(dummy.next!);

        var result = dummy.next;
        foreach (var val in output)
        {
            Assert.Equal(result.val, val);
            result = result.next;
        }

        Assert.Null(result);
    }
}

public class Solution143 {
    public void ReorderList(ListNode head) {
        var middle = GetMiddle(head);
        var tail = Reverse(middle);

        while (tail != null)
        {
            var nextHead = head.next;
            var nextTail = tail.next;

            head.next = tail;
            tail.next = nextHead;


            head = nextHead;
            tail = nextTail;
        }

        head?.next = null;
    }

    private ListNode GetMiddle(ListNode head)
    {
        var fast = head;
        var slow = head;

        while (fast?.next != null)
        {
            fast = fast.next?.next;
            slow = slow.next;
        }

        return slow;
    }

    private ListNode Reverse(ListNode current)
    {
        ListNode? prev = null;
        while (current != null)
        {
            var next = current.next;
            current.next = prev;

            prev = current;
            current = next;
        }

        return prev;
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