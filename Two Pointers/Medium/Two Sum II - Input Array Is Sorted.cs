//Problem: https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/

public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        int i = 0;
        int j = numbers.Length - 1;
        int sum = 0;

        while (i < j)
        {
            sum = numbers[i] + numbers[j];

            if (sum == target)
                break;

            if (sum < target)
                ++i;

            if (sum > target)
                --j;
        }

        return new int[] { i + 1, j + 1 };
    }
}