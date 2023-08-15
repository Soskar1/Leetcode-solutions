//Problem: https://leetcode.com/problems/pascals-triangle/

public class Solution
{
    public IList<IList<int>> Generate(int numRows)
    {
        IList<IList<int>> triangle = new List<IList<int>>();
        int elementCount = 1;

        for (int i = 0; i < numRows; ++i)
        {
            int[] row = new int[elementCount];
            row[0] = 1;
            row[elementCount - 1] = 1;

            for (int j = 1; j < elementCount - 1; ++j)
                row[j] = triangle[i - 1][j - 1] + triangle[i - 1][j];

            triangle.Add(row);
            ++elementCount;
        }

        return triangle;
    }
}