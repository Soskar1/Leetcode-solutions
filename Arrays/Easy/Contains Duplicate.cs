//Problem: https://leetcode.com/problems/contains-duplicate/

using System.Linq;

public class Solution
{
    public bool ContainsDuplictate(int[] nums)
    {
        Dictionary<int, bool> dic = new Dictionary<int, bool>();

        foreach (int num in nums)
        {
            if (dic.ContainsKey(num))
                return true;

            dic.Add(num, false);
        }

        return false;
    }
}