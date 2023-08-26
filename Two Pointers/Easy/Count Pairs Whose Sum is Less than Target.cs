//Problem: https://leetcode.com/problems/count-pairs-whose-sum-is-less-than-target/

public class Solution
{
    public int CountPairs(IList<int> nums, int target)
    {
        int output = 0;
        int j;

        for (int i = 0; i < nums.Count - 1; ++i)
        {
            j = nums.Count - 1;

            while (i < j)
            {
                if (nums[i] + nums[j] < target)
                    ++output;

                --j;
            }
        }

        return output;
    }
}