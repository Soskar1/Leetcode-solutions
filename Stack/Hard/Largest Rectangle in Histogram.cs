//Problem: https://leetcode.com/problems/largest-rectangle-in-histogram/

public class Solution
{
    public int LargestRectangleArea(int[] heights)
    {
        Stack<int> left = new Stack<int>();
        Stack<int> right = new Stack<int>();
        int maxArea = 0;
        int previousElement = 0;

        for (int i = 0; i < heights.Length; ++i)
        {
            if (previousElement == heights[i])
                continue;

            int tmpIndex = i;

            while (tmpIndex - 1 >= 0 && heights[tmpIndex - 1] >= heights[i])
            {
                --tmpIndex;
                left.Push(heights[tmpIndex]);
            }

            tmpIndex = i;

            while (tmpIndex + 1 < heights.Length && heights[tmpIndex + 1] >= heights[i])
            {
                ++tmpIndex;
                right.Push(heights[tmpIndex]);
            }

            maxArea = Math.Max(maxArea, Math.Max(heights[i], (left.Count + right.Count + 1) * heights[i]));
            left.Clear();
            right.Clear();

            previousElement = heights[i];
        }

        return maxArea;
    }
}