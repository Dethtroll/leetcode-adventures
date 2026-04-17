using Leetcode.Common;

namespace Leetcode.Helpers;

public static class ListNodeExtension
{
    public static ListNode? ToLinkedList(this int[] data)
    {
        var dummy = new ListNode();
        var current = dummy;
        foreach (var item in data)
        {
            current.next = new ListNode(item);
            current = current.next;
        }
        
        return dummy.next;
    }
}