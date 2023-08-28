//Problem: https://leetcode.com/problems/minimum-recolors-to-get-k-consecutive-black-blocks/

public class Solution
{
    private const char _WHITE_ = 'W';

    public int MinimumRecolors(string blocks, int k)
    {
        int current = 0;
        int min;

        for (int i = 0; i < k; ++i)
            if (blocks[i] == _WHITE_)
                ++current;

        min = current;

        if (min == 0)
            return min;

        for (int i = 0; i < blocks.Length - k; ++i)
        {
            if (blocks[i] == _WHITE_)
                --current;

            if (blocks[i + k] == _WHITE_)
                ++current;

            min = Math.Min(min, current);

            if (min == 0)
                break;
        }

        return min;
    }
}