//Problem: https://leetcode.com/problems/trapping-rain-water/

public class Solution
{
    public int Trap(int[] height)
    {
        int area = 0;
        int previousMaxLeft = int.MaxValue;
        int previousMaxRight = int.MinValue;

        for (int i = 1; i < height.Length - 1; ++i)
        {
            int maxLeft = 0;
            int maxRight = height.Length - 1;

            if (previousMaxLeft < i && i < previousMaxRight)
            {
                maxLeft = height[i - 1] > height[previousMaxLeft] ? i - 1 : previousMaxLeft;
                previousMaxLeft = maxLeft;

                if (height[i] < height[maxLeft] && height[i] < height[previousMaxRight])
                    area += Math.Min(height[maxLeft], height[previousMaxRight]) - height[i];

                continue;
            }

            int left = i - 1;
            int right = i + 1;

            while (left > 0)
            {
                maxLeft = height[maxLeft] < height[left] ? left : maxLeft;
                --left;
            }

            while (right < height.Length - 1)
            {
                maxRight = height[maxRight] < height[right] ? right : maxRight;
                ++right;
            }

            if (height[i] < height[maxLeft] && height[i] < height[maxRight])
                area += Math.Min(height[maxLeft], height[maxRight]) - height[i];

            previousMaxLeft = maxLeft;
            previousMaxRight = maxRight;
        }

        return area;
    }
}