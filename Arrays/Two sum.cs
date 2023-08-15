//Problem: https://leetcode.com/problems/two-sum/

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> d = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; ++i)
        {
            int tmpTarget = target - nums[i];

            if (d.ContainsKey(tmpTarget))
                return new int[] { i, d[tmpTarget]};

            d.Add(i, nums[i]);
        }

        return nums;
    }
}