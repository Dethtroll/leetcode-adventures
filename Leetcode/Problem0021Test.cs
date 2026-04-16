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
        var dummy1 = new Solution21.ListNode();
        var current = dummy1;
        foreach (var item in input1)
        {
            current.next = new Solution21.ListNode(item);
            current = current.next;
        }
        
        var dummy2 = new Solution21.ListNode();
        current = dummy2;
        foreach (var item in input2)
        {
            current.next = new Solution21.ListNode(item);
            current = current.next;
        }

        var result = _solution.MergeTwoLists(dummy1.next!, dummy2.next!);

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