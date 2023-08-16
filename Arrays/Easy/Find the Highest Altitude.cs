//Problem: https://leetcode.com/problems/find-the-highest-altitude/

public class Solution
{
    public int LargestAltitude(int[] gain)
    {
        int max = 0;
        int currentAltitude = 0;

        for (int i = 0; i < gain.Length; ++i)
        {
            currentAltitude += gain[i];

            if (max < currentAltitude)
                max = currentAltitude;
        }

        return max;
    }
}