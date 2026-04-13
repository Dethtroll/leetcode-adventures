namespace Leetcode;

//time: O(n)
//mem: O(n)
public class Solution207
{
    public void Solve()
    {
        var res = CanFinish(2, [[1, 0], [0, 1]]);
        res = CanFinish(2, [[1, 0]]);
        Console.WriteLine(res);
    }

    private enum Color { Unvisited, Visiting, Visited }
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        var adjacency = new List<int>[numCourses];
        for (var i = 0; i < numCourses; i++)
            adjacency[i] = [];
        foreach (var prerequisite in prerequisites) 
            adjacency[prerequisite[1]].Add(prerequisite[0]);
        
        Span<Color> colors=stackalloc Color[numCourses];
        for (var i = 0; i < numCourses; i++)
            if (HasCycle(i, colors, adjacency))
                return false;

        return true;
    }

    private bool HasCycle(int courseNumber, Span<Color> colors, List<int>[] matrix)
    {
        if (colors[courseNumber] == Color.Visiting)
            return true;
        if (colors[courseNumber] == Color.Visited)
            return false;

        //Не посещали
        colors[courseNumber] = Color.Visiting;
        foreach (var nextCourse in matrix[courseNumber])
            if (HasCycle(nextCourse, colors, matrix))
                return true;
        colors[courseNumber] = Color.Visited;

        return false;
    }
}