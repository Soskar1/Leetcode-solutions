//Problem: https://leetcode.com/problems/car-fleet/
//The solution is borrowed from: https://leetcode.com/problems/car-fleet/solutions/3615219/monotonic-stack/

public class Solution
{
    public int CarFleet(int target, int[] position, int[] speed)
    {
        Stack<double> stack = new Stack<double>();
        Array.Sort(position, speed);

        for (int i = 0; i < position.Length; ++i)
        {
            double time = (double)(target - position[i]) / speed[i];

            while (stack.Any() && time >= stack.Peek())
                stack.Pop();

            stack.Push(time);
        }

        return stack.Count;
    }
}