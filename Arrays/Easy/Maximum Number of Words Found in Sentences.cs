//Problem: https://leetcode.com/problems/maximum-number-of-words-found-in-sentences/

public class Solution
{
    public int MostWordsFound(string[] sentences)
    {
        int max = 0;
        int words = 1;

        foreach (string sentence in sentences)
        {
            for (int i = 0; i < sentence.Length; i++)
                if (sentence[i] == ' ')
                    ++words;

            if (words > max)
                max = words;

            words = 1;
        }

        return max;
    }
}