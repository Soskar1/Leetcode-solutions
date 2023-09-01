//Problem: https://leetcode.com/problems/minimum-window-substring/

public class Solution
{
    public string MinWindow(string s, string t)
    {
        if (s.Length < t.Length)
            return "";

        Dictionary<char, int> sCountDictionary = new Dictionary<char, int>();
        Dictionary<char, int> tCountDictionary = new Dictionary<char, int>();
        int start = 0;
        int end = 0;
        int counter = 0;
        int minSubstring = int.MaxValue;
        string answer = "";

        for (int i = 0; i < t.Length; ++i)
        {
            if (!tCountDictionary.ContainsKey(t[i]))
            {
                tCountDictionary.Add(t[i], 1);
                sCountDictionary.Add(t[i], 0);
            }
            else
            {
                ++tCountDictionary[t[i]];
            }
        }

        while (end < s.Length)
        {
            if (sCountDictionary.ContainsKey(s[end]))
            {
                ++sCountDictionary[s[end]];

                if (sCountDictionary[s[end]] <= tCountDictionary[s[end]])
                    ++counter;

                if (counter == t.Length)
                {
                    while (start < end
                        && (!sCountDictionary.ContainsKey(s[start])
                        || sCountDictionary[s[start]] > tCountDictionary[s[start]]))
                    {
                        if (sCountDictionary.ContainsKey(s[start]) && sCountDictionary[s[start]] > tCountDictionary[s[start]])
                            --sCountDictionary[s[start]];

                        ++start;
                    }

                    int currentLength = end - start + 1;
                    if (minSubstring > currentLength)
                    {
                        minSubstring = currentLength;
                        answer = s.Substring(start, currentLength);
                    }
                }
            }

            ++end;
        }

        return answer;
    }
}