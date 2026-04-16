namespace Leetcode;

public class Problem0023Test
{
    private readonly Solution23 _solution = new();

    private void BaseTest(int[][] inputs, int[] output)
    {
        var list = new List<Solution23.ListNode>(); 
        foreach (var input in inputs)
        {
            var dummy = new Solution23.ListNode();
            var current = dummy;
            foreach (var item in input)
            {
                current.next = new Solution23.ListNode(item);
                current = current.next;
            }

            list.Add(dummy.next!);
        }

        var result = _solution.MergeKLists(list.ToArray());

        foreach (var val in output)
        {
            Assert.Equal(result.val, val);
            result = result.next;
        }

        Assert.Null(result);
    }
    
    [Fact]
    public void TestFor3Way()
    {
        int[][] inputs = [[1, 4, 5], [1, 3, 4], [2, 6]];
        int[] output = [1, 1, 2, 3, 4, 4, 5, 6];
        
        BaseTest(inputs, output);
    }
    [Fact]
    public void TestForEmpty()
    {
        int[][] inputs = [];
        int[] output = [];
        
        BaseTest(inputs, output);
    }
    [Fact]
    public void TestForEmpty2()
    {
        int[][] inputs = [[]];
        int[] output = [];
        
        BaseTest(inputs, output);
    }
}

public class Solution23 {
    public ListNode MergeKLists(ListNode[] lists) {
        var dummy = new ListNode();
        var current = dummy;
        var pq = new PriorityQueue<ListNode, int>();
        
        foreach (var list in lists)
        {
            if (list != null)
                pq.Enqueue(list, list.val);
        }

        while (pq.TryDequeue(out var node, out var priority))
        {
            current.next = node;
            current = current.next;
            if (node.next != null)
                pq.Enqueue(node.next, node.next.val);
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