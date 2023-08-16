//Problem: https://leetcode.com/problems/group-anagrams/

public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        IList<IList<string>> list = new List<IList<string>>();
        Dictionary<string, List<string>> anagrams = new Dictionary<string, List<string>>();

        for (int i = 0; i < strs.Length; ++i)
        {
            string tmpString = String.Concat(strs[i].OrderBy(x => x));
            if (anagrams.ContainsKey(tmpString))
                anagrams[tmpString].Add(strs[i]);
            else
                anagrams.Add(tmpString, new List<string>() { strs[i] });
        }

        foreach (string key in anagrams.Keys)
        {
            List<string> group = anagrams[key];
            list.Add(group);
        }

        return list;
    }
}