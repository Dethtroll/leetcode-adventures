using Leetcode.Common;

namespace Leetcode;

public class Problem0142Test
{
    private readonly Solution142 _solution = new();

    [Theory]
    [InlineData(new[] { 3, 2, 0, -4 }, 1)]
    [InlineData(new[] { 1, 2 }, 0)]
    [InlineData(new[] { 1 }, -1)]
    public void TestForN(int[] head, int pos)
    {
        var dummy = new ListNode(0);
        var current = dummy;
        ListNode? cycle = null;
        for (var index = 0; index < head.Length; index++)
        {
            var item = head[index];

            current.next = new ListNode(item);
            current = current.next;

            if (index == pos)
                cycle = current;
        }
        current.next = cycle;

        var result = _solution.DetectCycle(dummy.next!);

        Assert.Equal(cycle, result);
    }
}

public class Solution142
{
    public ListNode? DetectCycle(ListNode? head)
    {
        if (head == null || head.next == null) {
            return null;
        }
        if (head == head.next) {
            return head;
        }

        var slow = head;
        var fast= head;

        while (fast?.next != null) {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast) {
                break;
            }
        }

        if (fast?.next == null || slow != fast) {
            return null;
        }

        while (head != fast) {
            head = head.next;
            fast = fast.next;
        }

        return head;
    }
}