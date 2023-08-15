//Problem: https://leetcode.com/problems/valid-anagram/

public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;

        Dictionary<char, int> sCharacterCount = CreateCountDictionary(s);
        Dictionary<char, int> tCharacterCount = CreateCountDictionary(t);

        foreach (var keyValue in sCharacterCount)
        {
            if (!tCharacterCount.ContainsKey(keyValue.Key))
                return false;
            
            if (tCharacterCount.ContainsKey(keyValue.Key) && tCharacterCount[keyValue.Key] != sCharacterCount[keyValue.Key])
                return false;
        }

        return true;
    }

    private Dictionary<char, int> CreateCountDictionary(string str)
    {
        Dictionary<char, int> characterCount = new Dictionary<char, int>();

        foreach (char c in str)
        {
            if (!characterCount.ContainsKey(c))
                characterCount.Add(c, 1);
            else
                ++characterCount[c];
        }

        return characterCount;
    }
}