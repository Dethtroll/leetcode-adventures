using Leetcode.Common;
using Leetcode.Helpers;

namespace Leetcode;

public class Problem0437Test
{
    private readonly Solution437 _solution = new();

    private void BaseTest(int?[] input, int sum, int count)
    {
        var result = _solution.PathSum(input.ToBinTree(), sum);
        
        Assert.Equal(count, result);
    }

    [Fact]
    public void TestForEx1()
    {
        BaseTest([10, 5, -3, 3, 2, null, 11, 3, -2, null, 1], 8, 3);
    }
    [Fact]
    public void TestForEx2()
    {
        BaseTest([5,4,8,11,null,13,4,7,2,null,null,null,null,5,1], 22, 3);
    }
    [Fact]
    public void TestForEx3()
    {
        BaseTest([1,2], 2, 1);
    }
    [Fact]
    public void TestForEx4()
    {
        BaseTest([1000000000,1000000000,null,294967296,null,1000000000,null,1000000000,null,1000000000], 0, 0);
    }
}

public class Solution437 {
    public int PathSum(TreeNode? root, int targetSum)
    {
        // key: сумма префиксов, value: количество раз, которое встречается сумма префиксов
        // И инициализируем простым случаем: Префиксная сумма в точности равна targetSum.
        var register = new Dictionary<long, int> { { 0, 1 } };

        return DFS(root, 0, register, targetSum);
    }

    private int DFS(TreeNode? node, long currentSum, Dictionary<long, int> allSums, int targetSum)
    {
        if (node == null)
            return 0;

        currentSum += node.val;

        // 1. Проверяем, есть ли на текущем пути какая-либо точка, сумма значений которой до этой точки точно совпадает с targetSum.
        // CurrentSum - PreviousSum = Target  =>  PreviousSum = CurrentSum - Target
        var count = allSums.GetValueOrDefault(currentSum - targetSum, 0);
        
        // 2. Добавим текущую сумму префикса в allSum для использования дочерними узлами.
        allSums[currentSum] = allSums.GetValueOrDefault(currentSum, 0) + 1;
        
        //3. Рекурсивно обойдем дерево
        count += DFS(node.left, currentSum, allSums, targetSum);
        count += DFS(node.right, currentSum, allSums, targetSum);
        
        //4. [Обратный поиск] При выходе из текущего узла вычтем его префиксную сумму, чтобы она не учитывалась для узлов ближе к корню.
        allSums[currentSum] -= 1;
        
        return count;
    }


    public int PathSum2(TreeNode? root, int targetSum)
    {
        var hashset = new HashSet<int>();
        
        SubPathSum2(root, targetSum, root, targetSum, hashset);

        return hashset.Count;
    }

    private void SubPathSum2(TreeNode? currentNode, int currentSum, TreeNode? startNode, int startSum, HashSet<int> result)
    {
        if (currentNode == null)
            return;
        
        if (currentNode.val == currentSum)
            result.Add(HashCode.Combine(startNode, currentNode));
        
        SubPathSum2(currentNode.left, currentSum - currentNode.val, startNode, startSum, result);
        SubPathSum2(currentNode.right, currentSum - currentNode.val, startNode, startSum, result);
        
        SubPathSum2(currentNode.left, startSum - currentNode.val, currentNode, startSum, result);
        SubPathSum2(currentNode.right, startSum - currentNode.val, currentNode, startSum, result);
    }
}