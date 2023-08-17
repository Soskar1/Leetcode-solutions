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
        Stack<char> openParentheses = new Stack<char>();

        foreach (char c in s)
        {
            if (validParentheses.ContainsKey(c))
            {
                if (openParentheses.Count == 0)
                    return false;

                char bracket = openParentheses.Pop();

                if (bracket != validParentheses[c])
                    return false;
            }
            else
            {
                openParentheses.Push(c);
            }
        }

        if (openParentheses.Count > 0)
            return false;

        return true;
    }
}