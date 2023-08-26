//Problem: https://leetcode.com/problems/reverse-words-in-a-string-iii/

using System.Text;

public class Solution
{
    public string ReverseWords(string s)
    {
        StringBuilder sb = new StringBuilder();
        string[] words = s.Split(' ');

        foreach (string word in words)
        {
            char[] tmp = word.ToCharArray();
            Array.Reverse(tmp);
            sb.Append(new string(tmp));
            sb.Append(' ');
        }

        sb.Remove(sb.Length - 1, 1);

        return sb.ToString();
    }
}