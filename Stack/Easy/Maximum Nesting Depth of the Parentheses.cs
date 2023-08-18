//Problem: https://leetcode.com/problems/maximum-nesting-depth-of-the-parentheses/

public class Solution
{
    public int MaxDepth(string s)
    {
        Stack<char> openBrackets = new Stack<char>();
        int maxDepth = 0;

        foreach (char c in s)
        {
            if (c == '(')
            {
                openBrackets.Push(c);

                if (maxDepth < openBrackets.Count)
                    maxDepth = openBrackets.Count;
            }
            else if (c == ')')
            {
                if (openBrackets.Count == 0)
                    continue;

                openBrackets.Pop();
            }
        }

        if (openBrackets.Count > 0)
            return 0;

        return maxDepth;
    }
}