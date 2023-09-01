//Problem: https://leetcode.com/problems/substrings-of-size-three-with-distinct-characters/

public class Solution
{
    private const int WINDOW_SIZE = 3;

    public int CountGoodSubstrings(string s)
    {
        if (s.Length < WINDOW_SIZE)
            return 0;

        Dictionary<char, int> freqMap = new Dictionary<char, int>();
        int substringCount = 0;
        int validCharacterCount = 0;

        for (int i = 0; i < WINDOW_SIZE; i++)
        {
            if (!freqMap.ContainsKey(s[i]))
            {
                ++validCharacterCount;
                freqMap.Add(s[i], 1);
            }
            else
            {
                ++freqMap[s[i]];

                if (freqMap[s[i]] > 1)
                    --validCharacterCount;
            }
        }

        if (validCharacterCount == WINDOW_SIZE)
            ++substringCount;

        for (int i = 0; i + WINDOW_SIZE < s.Length; ++i)
        {
            --freqMap[s[i]];

            if (freqMap[s[i]] >= 1)
                ++validCharacterCount;
            else
                --validCharacterCount;

            int rightIndex = i + WINDOW_SIZE;
            if (!freqMap.ContainsKey(s[rightIndex]))
            {
                ++validCharacterCount;
                freqMap.Add(s[rightIndex], 1);
            }
            else
            {
                ++freqMap[s[rightIndex]];

                if (freqMap[s[rightIndex]] > 1)
                    --validCharacterCount;
                else
                    ++validCharacterCount;
            }

            if (validCharacterCount == WINDOW_SIZE)
                ++substringCount;
        }

        return substringCount;
    }
}