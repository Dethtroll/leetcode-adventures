namespace Leetcode;

public class Solution443
{
    public void Solve()
    {
        char[] input = ['a', 'a', 'b', 'b', 'c', 'c', 'c'];
        Console.WriteLine(string.Join(',', input));
        var res = Compress(input);
        Console.WriteLine(string.Join(',', input.Take(res)));
        Console.WriteLine(res);

        input = ['a'];
        Console.WriteLine(string.Join(',', input));
        res = Compress(input);
        Console.WriteLine(string.Join(',', input.Take(res)));
        Console.WriteLine(res);

        input = ['a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b'];
        Console.WriteLine(string.Join(',', input));
        res = Compress(input);
        Console.WriteLine(string.Join(',', input.Take(res)));
        Console.WriteLine(res);
    }
    public int Compress(char[] chars) {
        var left = 0;
        var pointer = 0;

        while (left < chars.Length)
        {
            var right = left;
            while (right + 1 < chars.Length && chars[right + 1] == chars[left])
                right++;

            right = right == chars.Length ? chars.Length - 1 : right;

            chars[pointer] = chars[left];
            pointer++;
            if (right - left > 0)
            {
                foreach (var ch in (right - left + 1).ToString())
                {
                    chars[pointer] = ch;
                    pointer++;
                }
            }
            
            left = right + 1;
        }

        return pointer;
    }
}