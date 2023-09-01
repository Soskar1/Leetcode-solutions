//Problem: https://leetcode.com/problems/longest-repeating-character-replacement/

public class Solution
{
    public int CharacterReplacement(string s, int k)
    {
        int maxCount = 0;
        Dictionary<char, int> dictionary = new Dictionary<char, int>();

        int start = 0;
        int end = 0;
        int maxLength = 0;

        while (end < s.Length)
        {
            if (!dictionary.ContainsKey(s[end]))
                dictionary.Add(s[end], 1);
            else
                ++dictionary[s[end]];

            maxCount = Math.Max(maxCount, dictionary[s[end]]);

            if (end - start + 1 - maxCount > k)
            {
                --dictionary[s[start]];
                ++start;
            }

            maxLength = Math.Max(maxLength, end - start + 1);

            ++end;
        }

        return maxLength;
    }
}