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

//Stack Solution
public class Solution2
{
    public int LargestRectangleArea(int[] heights)
    {
        Stack<(int, int)> columns = new Stack<(int, int)>();
        int leftBoundary = 0;
        int maxArea = 0;

        for (int i = 0; i < heights.Length; ++i)
        {
            leftBoundary = i;

            while (columns.Any() && columns.Peek().Item2 > heights[i])
            {
                var column = columns.Pop();
                leftBoundary = column.Item1;
                
                maxArea = Math.Max(maxArea, Math.Max(column.Item2, column.Item2 * (i - leftBoundary)));
            }

            columns.Push((leftBoundary, heights[i]));
        }

        while (columns.Any())
        {
            var column = columns.Pop();
            maxArea = Math.Max(maxArea, Math.Max(column.Item2, column.Item2 * (heights.Length - column.Item1)));
        }

        return maxArea;
    }
}