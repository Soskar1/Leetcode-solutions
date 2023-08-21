//Problem: https://leetcode.com/problems/final-prices-with-a-special-discount-in-a-shop/

public class Solution
{
    public int[] FinalPrices(int[] prices)
    {
        Stack<int> indices = new Stack<int>();

        for (int i = 0; i < prices.Length; ++i)
        {
            while (indices.Count > 0 && prices[indices.Peek()] - prices[i] >= 0)
                prices[indices.Pop()] -= prices[i];

            indices.Push(i);
        }

        return prices;
    }
}