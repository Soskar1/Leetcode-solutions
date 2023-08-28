//Problem: https://leetcode.com/problems/contains-duplicate-ii/

public class Solution
{
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        if (k == 0)
            return false;

        Dictionary<int, int> amountOfNumbers = new Dictionary<int, int>();

        for (int i = 0; i <= k && i < nums.Length; ++i)
        {
            if (!amountOfNumbers.ContainsKey(nums[i]))
                amountOfNumbers.Add(nums[i], 1);
            else if (amountOfNumbers.ContainsKey(nums[i]))
                return true;
        }

        for (int i = 0; i < nums.Length - k - 1; ++i)
        {
            --amountOfNumbers[nums[i]];

            int rightIndex = i + k + 1;
            if (amountOfNumbers.ContainsKey(nums[rightIndex]))
            {
                ++amountOfNumbers[nums[rightIndex]];
                if (amountOfNumbers[nums[rightIndex]] > 1)
                    return true;
            }
            else
            {
                amountOfNumbers.Add(nums[rightIndex], 1);
            }
        }

        return false;
    }
}