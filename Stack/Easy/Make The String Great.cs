//Problem: https://leetcode.com/problems/make-the-string-great/

using System.Text;

public class Solution
{
    public string MakeGood(string s)
    {
        Stack<char> stack = new Stack<char>();
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < s.Length; ++i)
        {
            sb.Append(s[i]);

            if (stack.Count > 0 &&
                ((Char.IsUpper(stack.Peek()) && Char.IsLower(s[i]) && Char.ToUpper(s[i]) == stack.Peek()) ||
                (Char.IsLower(stack.Peek()) && Char.IsUpper(s[i]) && Char.ToLower(s[i]) == stack.Peek())))
            {
                sb.Remove(sb.Length - 2, 2);
                stack.Pop();
            }
            else
            {
                stack.Push(s[i]);
            }
        }

        return sb.ToString();
    }
}