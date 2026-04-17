using Leetcode.Common;

namespace Leetcode;

public class Problem0141Test
{
    private readonly Solution141 _solution = new();

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

        var result = _solution.HasCycle(dummy.next!);

        Assert.Equal(pos >= 0, result);
    }
}

public class Solution141
{
    public bool HasCycle(ListNode head)
    {
        var slow = head;
        var fast = head?.next?.next;

        while (fast != null)
        {
            if (fast==slow)
                return true;
            
            slow = slow!.next;
            fast = fast.next?.next;
        }
        
        return false;
    }
}