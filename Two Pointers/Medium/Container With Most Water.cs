//Problem: https://leetcode.com/problems/container-with-most-water/

public class Solution
{
    public int MaxArea(int[] height)
    {
        int maxArea = 0;
        int left = 0;
        int right = height.Length - 1;

        while (left < right)
        {
            if (height[left] <= height[right])
            {
                maxArea = Math.Max(maxArea, (right - left) * height[left]);
                ++left;
            }
            else
            {
                maxArea = Math.Max(maxArea, (right - left) * height[right]);
                --right;
            }
        }

        return maxArea;
    }
}