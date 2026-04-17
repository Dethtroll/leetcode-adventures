using Leetcode.Common;
using Leetcode.Helpers;

namespace Leetcode;

public class Problem0876Test
{
    private readonly Solution876 _solution = new();

    [Theory]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 3, 4, 5 })]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6 }, new[] { 4, 5, 6 })]
    public void TestForN(int[] input, int[] output)
    {
        var list = input.ToLinkedList();

        var result = _solution.MiddleNode(list!);

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
}