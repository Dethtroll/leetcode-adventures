namespace Leetcode;

public class Solution207
{
    public void Solve()
    {
        var res = CanFinish(2, [[1, 0], [0, 1]]);
        res = CanFinish(2, [[1, 0]]);
        Console.WriteLine(res);
    }
    
    public enum Color { Unvisited, Visiting, Visited }
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        var adjacency = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++)
        {
            adjacency[i] = new List<int>();
        }
        
        foreach (var prerequisite in prerequisites)
        {
            adjacency[prerequisite[0]].Add(prerequisite[1]);
        }
        
        var colors = new int[numCourses];
        for (int i = 0; i < numCourses; i++)
        {
            if (HasCyrcle(i, colors, adjacency))
                return false;
        }

        return true;
    }

    private bool HasCyrcle(int courseNumber, int[] colors, List<int>[] matrix)
    {
        //серый
        if (colors[courseNumber] == 1)
            return true;
        //черный
        if (colors[courseNumber] == 2)
            return false;

        //Не посещали
        colors[courseNumber] = 1;
        foreach (var nextCourse in matrix[courseNumber])
            if (HasCyrcle(nextCourse, colors, matrix))
                return true;
        colors[courseNumber] = 2;

        return false;
    }
}