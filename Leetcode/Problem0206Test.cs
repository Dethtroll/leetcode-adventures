using Leetcode.Common;
using Leetcode.Helpers;

namespace Leetcode;

public class Problem0206Test
{
    private readonly Solution206 _solution = new();
    
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 5, 4, 3, 2, 1 })]
    [InlineData(new[] { 1, 2 }, new[] { 2, 1 })]
    public void TestForN(int[] input, int[] output)
    {
        var list = input.ToLinkedList();
        
        var result = _solution.ReverseList(list!);

        foreach (var val in output)
        {
            Assert.Equal(result.val, val);
            result = result.next;
        }

        Assert.Null(result);
    }
}
public class Solution206 {
    public ListNode ReverseList(ListNode head)
    {
        var dummy = new ListNode();
        var current = head;
        
        while (current != null)
        {
            var next = current.next;
            
            current.next = dummy.next;
            dummy.next = current;
            
            current = next;
        }
        
        return dummy.next!;
    }
}