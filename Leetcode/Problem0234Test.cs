using System.Runtime.InteropServices;

namespace Leetcode;

public class Problem0234Test
{
    
    private readonly Solution234 _solution = new();

    [Theory]
    [InlineData(new[] { 1, 2, 2, 1 }, true)]
    [InlineData(new[] { 1, 2, 3, 2, 1 }, true)]
    [InlineData(new[] { 1, 2 }, false)]
    public void TestForN(int[] input, bool target)
    {
        var dummy = new Solution234.ListNode();
        var current = dummy;
        foreach (var item in input)
        {
            current.next = new Solution234.ListNode(item);
            current = current.next;
        }

        var result = _solution.IsPalindrome(dummy.next);

        Assert.Equal(target, result);
    }
}
public class Solution234 {
    public bool IsPalindrome(ListNode head)
    {
        var middle = GetMiddle(head);
        var tail = Reverse(middle);
        while (tail != null)
        {
            if (head.val != tail.val)
                return false;
            
            head = head.next;
            tail = tail.next;
        }
        
        return true;
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