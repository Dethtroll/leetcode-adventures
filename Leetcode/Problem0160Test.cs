namespace Leetcode;

public class Problem0160Test
{
    private readonly Solution160 _solution = new();

    [Theory]
    [InlineData(new[] { 4,1,8,4,5 }, 2, new[] { 5,6,1,8,4,5 }, 3)]
    [InlineData(new[] { 1,9,1,2,4 }, 3, new[] { 3,2,4 }, 1)]
    [InlineData(new[] { 2,6,4 }, 3, new[] { 1,5 }, 2)]
    public void TestForN(int[] listA, int skipA, int[] listB, int skipB)
    {
        var dummyA = new Solution160.ListNode(0);
        var currentA = dummyA;
        foreach (var item in listA.Take(skipA))
        {
            currentA.next = new Solution160.ListNode(item);
            currentA = currentA.next;
        }

        var dummyB = new Solution160.ListNode(0);
        var currentB = dummyB;
        foreach (var item in listB.Take(skipB))
        {
            currentB.next = new Solution160.ListNode(item);
            currentB = currentB.next;
        }

        Solution160.ListNode? intersect = null;
        Solution160.ListNode? common = null;
        if (listA.Length > skipA)
        {
            foreach (var item in listA.Skip(skipA))
            {
                if (intersect == null)
                {
                    intersect = new Solution160.ListNode(item);

                    currentA.next = intersect;
                    currentB.next = intersect;
                    common = intersect;
                }
                else
                {
                    common.next = new Solution160.ListNode(item);
                    common = common.next;
                }
            }
        }

        var result = _solution.GetIntersectionNode(dummyA.next!, dummyB.next!);

        Assert.Same(intersect, result);
    }
}
public class Solution160 {
    public ListNode? GetIntersectionNode(ListNode headA, ListNode headB) {
        var pointerA = headA;
        var pointerB = headB;
        var changed = false;

        while (pointerA != pointerB)
        {
            if (pointerA.next == null)
            {
                if (changed)
                    return null;
                changed = true;
                pointerA = headB;
            }
            else
                pointerA = pointerA.next;

            pointerB = pointerB.next != null ? pointerB.next : headA;
        }

        return pointerA;
    }

    public class ListNode
    {
        public int val;
        public ListNode? next;

        public ListNode(int x)
        {
            val = x;
        }
    }
}