//Problem: https://leetcode.com/problems/find-the-k-beauty-of-a-number/

public class Solution
{
    public int DivisorSubstrings(int num, int k)
    {
        string strNum = num.ToString();
        int output = 0;

        for (int i = 0; i + k <= strNum.Length; ++i)
        {
            string substring = strNum.Substring(i, k);
            int tmp = Int32.Parse(substring);

            if (tmp == 0)
                continue;

            if (num % tmp == 0)
                ++output;
        }

        return output;
    }
}