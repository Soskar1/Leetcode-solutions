//Problem: https://leetcode.com/problems/remove-outermost-parentheses/

using System.Text;

public class Solution
{
    public string RemoveOuterParentheses(string s)
    {
        StringBuilder sb = new StringBuilder();
        int openBracketsCount = 0;
        int startIndex = 0;

        for (int i = 0; i < s.Length; ++i) 
        {
            sb.Append(s[i]);

            if (s[i] == '(')
            {
                ++openBracketsCount;

                if (openBracketsCount == 1)
                    startIndex = sb.Length - 1;
            }
            else
            {
                --openBracketsCount;

                if (openBracketsCount == 0)
                {
                    sb.Remove(sb.Length - 1, 1);
                    sb.Remove(startIndex, 1);
                }
            }
        }

        return sb.ToString();
    }
}