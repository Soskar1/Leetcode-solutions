//Problem: https://leetcode.com/problems/top-k-frequent-elements/

public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> frequency = new Dictionary<int, int>();
        List<int> output = new List<int>();

        for (int i = 0; i < nums.Length; ++i)
        {
            if (!frequency.ContainsKey(nums[i]))
                frequency.Add(nums[i], 1);
            else
                ++frequency[nums[i]];
        }

        for (int i = 0; i < k; ++i)
        {
            var mostFrequentValue = frequency.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            output.Add(mostFrequentValue);
            frequency.Remove(mostFrequentValue);
        }

        return output.ToArray();
    }
}