//Problem: https://leetcode.com/problems/longest-consecutive-sequence/

class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        if (nums.Length <= 1)
            return 0;

        int maxCount = 0;
        int currentCount = 1;

        nums = nums.Distinct().OrderBy(x => x).ToArray();

        for (int i = 0; i < nums.Length; ++i)
        {
            if (i + 1 == nums.Length)
                break;

            if (nums[i + 1] - nums[i] == 1)
            {
                ++currentCount;

                if (maxCount < currentCount)
                    maxCount = currentCount;
            }
            else
            {
                currentCount = 1;
            }
        }

        return maxCount;
    }
}