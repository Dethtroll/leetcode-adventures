namespace InterviewBit;

public class ProblemRepeatAndMissingNumberArrayTest
{
    private readonly SolutionRepeatAndMissingNumberArray _solution = new();
    
    [Theory]
    [InlineData(new[] { 3, 1, 2, 5, 3 }, new[] { 3, 4 })]
    public void TestForN(int[] input, int[] target)
    {
        var result = _solution.repeatedNumber(input.ToList());
        
        Assert.Equal(target.ToList(), result);
    }
}

//slug: repeat-and-missing-number-array
class SolutionRepeatAndMissingNumberArray {
    public List<int> repeatedNumber(List<int> A)
    {
        var result = new[] { -1, -1 };
        var hash = new int[A.Count + 1];
        foreach (var num in A)
        {
            if (hash[num] > 0)
                result[0] = num;

            hash[num]++;
        }

        result[1] = Array.IndexOf(hash, 0, 1);
        
        return result.ToList();
    }
}