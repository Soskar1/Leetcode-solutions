//Problem: https://leetcode.com/problems/valid-palindrome/

public class Solution
{
    public bool IsPalindrome(string s)
    {
        int i = 0;
        int j = s.Length - 1;

        while (i < j)
        {
            while (!Char.IsLetterOrDigit(s[i]))
            {
                ++i;

                if (i > j)
                    break;
            }

            while (!Char.IsLetterOrDigit(s[j]))
            {
                --j;

                if (i > j)
                    break;
            }

            if (i < j && Char.ToLower(s[i]) != Char.ToLower(s[j]))
                return false;

            ++i;
            --j;
        }

        return true;
    }
}