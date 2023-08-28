//Problem: https://leetcode.com/problems/minimum-difference-between-highest-and-lowest-of-k-scores/

public class Solution
{
    public int MinimumDifference(int[] nums, int k)
    {
        int minDiff;
        int currentDiff;

        Array.Sort(nums);

        currentDiff = nums[k - 1] - nums[0];
        minDiff = currentDiff;

        for (int i = 0; i < nums.Length - k; ++i)
        {
            currentDiff = nums[i + k] - nums[i + 1];
            minDiff = Math.Min(minDiff, currentDiff);
        }

        return minDiff;
    }
}