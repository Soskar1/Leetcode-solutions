//Problem: https://leetcode.com/problems/generate-parentheses/

public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        List<string> result = new List<string>();

        AddBrackets("", n, 0, 0, result);

        return result;
    }

    private void AddBrackets(string str, int max, int openBrackets, int closedBrackets, List<string> list)
    {
        if (openBrackets == max && closedBrackets == max)
        {
            list.Add(str);
            return;
        }

        if (openBrackets < max)
            AddBrackets(str + '(', max, openBrackets + 1, closedBrackets, list);

        if (closedBrackets < max && closedBrackets != openBrackets)
            AddBrackets(str + ')', max, openBrackets, closedBrackets + 1, list);
    }
}