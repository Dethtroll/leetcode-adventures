using Leetcode.Common;
using Leetcode.Helpers;

namespace Leetcode;

public class Problem0021Test
{
    private readonly Solution21 _solution = new();

    [Theory]
    [InlineData(new[] { 1, 2, 4 }, new[] { 1, 3, 4 }, new[] { 1, 1, 2, 3, 4, 4 })]
    [InlineData(new int[0], new int[0], new int[0])]
    [InlineData(new int[0], new[] { 0 }, new[] { 0 })]
    [InlineData(new[] { 2 }, new[] { 1 }, new[] { 1, 2 })]
    public void TestForN(int[] input1, int[] input2, int[] output)
    {
        var list1 = input1.ToLinkedList();
        var list2 = input2.ToLinkedList();
        
        var result = _solution.MergeTwoLists(list1!, list2!);

        foreach (var val in output)
        {
            Assert.Equal(result.val, val);
            result = result.next;
        }

        Assert.Null(result);
    }
}

public class Solution21
{
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        var dummy = new ListNode();

        var head = dummy;
        while (list1 != null || list2 != null)
        {
            if (list2 == null || list1?.val < list2.val)
            {
                head.next = list1;
                list1 = list1.next;
            }
            else
            {
                head.next = list2;
                list2 = list2.next;
            }
            head = head.next;
        }

        return dummy.next!;
    }
}