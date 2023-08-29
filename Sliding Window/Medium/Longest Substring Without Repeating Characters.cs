//Problem: https://leetcode.com/problems/longest-substring-without-repeating-characters/

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        int start = 0;
        int maxLength = 0;
        Dictionary<char, int> charactersInWindow = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; ++i)
        {
            if (!charactersInWindow.ContainsKey(s[i]))
            {
                charactersInWindow.Add(s[i], i);
            }
            else
            {
                maxLength = Math.Max(maxLength, i - start);

                if (charactersInWindow[s[i]] >= start)
                    start = charactersInWindow[s[i]] + 1;

                charactersInWindow[s[i]] = i;
            }
        }

        maxLength = Math.Max(maxLength, s.Length - start);

        return maxLength;
    }
}