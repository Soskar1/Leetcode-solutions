//Problem: https://leetcode.com/problems/3sum/

public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        IList<IList<int>> output = new List<IList<int>>();

        Array.Sort(nums);

        int j;
        int k;
        int tmpSum;
        int previousNum = 0;
        for (int i = 0; i < nums.Length; ++i)
        {
            if (i > 0 && nums[i] == previousNum)
                continue;

            j = i + 1;
            k = nums.Length - 1;

            while (j < k)
            {
                tmpSum = nums[i] + nums[j] + nums[k];

                if (tmpSum == 0)
                {
                    IList<int> sequence = new List<int>() { nums[i], nums[j], nums[k] } ;

                    if (!ContainsSequence(output, sequence))
                        output.Add(sequence);

                    ++j;
                    --k;
                }
                else if (tmpSum < 0)
                {
                    ++j;
                }
                else
                {
                    --k;
                }
            }

            previousNum = nums[i];
        }

        return output;
    }

    private bool ContainsSequence(IList<IList<int>> sequences, IList<int> list)
    {
        foreach (var sequence in sequences)
        {
            if (sequence[0] == list[0] &&
                sequence[1] == list[1] &&
                sequence[2] == list[2])
                return true;
        }

        return false;
    }
}