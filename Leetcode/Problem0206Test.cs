namespace Leetcode;

public class Problem0206Test
{
    private readonly Solution206 _solution = new();
    
    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 5, 4, 3, 2, 1 })]
    [InlineData(new[] { 1, 2 }, new[] { 2, 1 })]
    public void TestForN(int[] input, int[] output)
    {
        var dummy = new Solution206.ListNode();
        var current = dummy;
        foreach (var item in input)
        {
            current.next = new Solution206.ListNode(item);
            current = current.next;
        }

        var result = _solution.ReverseList(dummy.next!);

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
    
    public class ListNode {
        public int val;
        public ListNode? next;
        public ListNode(int val=0, ListNode? next = null) {
            this.val = val;
            this.next = next;
        }
    }
}