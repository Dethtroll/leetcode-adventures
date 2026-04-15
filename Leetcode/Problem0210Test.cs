namespace Leetcode;

public class Problem0210Test
{
    private readonly Solution210 _solution = new();

    [Fact]
    public void PositiveTest()
    {
        int[][] source = [[1, 0], [2, 0], [3, 1], [3, 2]];

        var res = _solution.FindOrder(4, source);

        Assert.Equivalent(new[] { 0, 2, 1, 3 }, res);
    }
    [Fact]
    public void EasyTest()
    {
        int[][] source = [[1, 0]];

        var res = _solution.FindOrder(2, source);

        Assert.Equivalent(new[] { 0, 1 }, res);
    }
    [Fact]
    public void NegativeTest()
    {
        int[][] source = [];

        var res = _solution.FindOrder(1, source);

        Assert.Equivalent(new[] { 0 }, res);
    }
}

//time: O(max(numCourses, len(prerequisites)))
//mem: O(max(numCourses, len(prerequisites)))
public class Solution210
{
    public void Solve()
    {
        var res = FindOrder(4, [[1, 0], [2, 0], [3, 1], [3, 2]]);
        Console.WriteLine(string.Join(',', res));
        
        res = FindOrder(2, [[0,1]]);
        Console.WriteLine(string.Join(',', res));
    }

    private enum Color { Unvisited, Visiting, Visited }
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        var adjacency = new List<int>[numCourses];
        for (var i = 0; i < numCourses; i++) 
            adjacency[i] = [];
        foreach (var prerequisite in prerequisites)
        {
            adjacency[prerequisite[1]].Add(prerequisite[0]);
        }
        
        var result = new Stack<int>();
        Span<Color> colors = stackalloc Color[numCourses];
        for (int i = 0; i < numCourses; i++)
        {
            if (HasCycle(i, colors, adjacency, result))
                return [];
        }
        
        return result.ToArray();
    }

    private bool HasCycle(int i, Span<Color> colors, List<int>[] adjacency, Stack<int> result)
    {
        if (colors[i] == Color.Visiting)
            return true;
        if (colors[i] == Color.Visited)
            return false;

        colors[i] = Color.Visiting;
        foreach (var next in adjacency[i])
        {
            if(HasCycle(next, colors, adjacency, result))
                return true;
        }
        result.Push(i);
        colors[i] = Color.Visited;

        return false;
    }
}