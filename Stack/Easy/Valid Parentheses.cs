//Problem: https://leetcode.com/problems/valid-parentheses/

public class Solution
{
    Dictionary<char, char> validParentheses = new Dictionary<char, char>
    {
        { ')', '(' },
        { '}', '{' },
        { ']', '[' },
    };

    public bool IsValid(string s)
    {
        Stack<char> openBrackets = new Stack<char>();

        foreach (char c in s)
        {
            if (validParentheses.ContainsKey(c))
            {
                if (openBrackets.Count == 0)
                    return false;

                char bracket = openBrackets.Pop();

                if (bracket != validParentheses[c])
                    return false;
            }
            else
            {
                openBrackets.Push(c);
            }
        }

        if (openBrackets.Count > 0)
            return false;

        return true;
    }
}