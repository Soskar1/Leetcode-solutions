//Problem: https://leetcode.com/problems/permutation-in-string/

public class Solution
{
    public bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length)
            return false;

        Dictionary<char, int> s1Freq = new Dictionary<char, int>();
        Dictionary<char, int> s2Freq = new Dictionary<char, int>();

        for (int i = 0; i < s1.Length; ++i)
        {
            if (!s1Freq.ContainsKey(s1[i]))
                s1Freq.Add(s1[i], 1);
            else
                ++s1Freq[s1[i]];

            if (!s2Freq.ContainsKey(s2[i]))
                s2Freq.Add(s2[i], 1);
            else
                ++s2Freq[s2[i]];
        }

        if (s1Freq.OrderBy(key => key.Key).SequenceEqual(s2Freq.OrderBy(key => key.Key)))
            return true;

        for (int i = 0; i + s1.Length < s2.Length; ++i)
        {
            --s2Freq[s2[i]];
            if (s2Freq[s2[i]] == 0)
                s2Freq.Remove(s2[i]);

            int rightIndex = i + s1.Length;

            if (!s2Freq.ContainsKey(s2[rightIndex]))
                s2Freq.Add(s2[rightIndex], 1);
            else
                ++s2Freq[s2[rightIndex]];

            if (s1Freq.OrderBy(key => key.Key).SequenceEqual(s2Freq.OrderBy(key => key.Key)))
                return true;
        }

        return false;
    }
}