//Problem: https://leetcode.com/problems/daily-temperatures/

public class Solution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        Stack<int> monoStack = new Stack<int>();
        int[] daysToWait = new int[temperatures.Length];

        for (int i = 0; i < temperatures.Length; ++i)
        {
            int currentTemperature = temperatures[i];
            int dayDiff = 1;

            while (monoStack.Count > 0 && currentTemperature > monoStack.Peek())
            {
                while (daysToWait[i - dayDiff] != 0)
                    ++dayDiff;

                daysToWait[i - dayDiff] = dayDiff;
                monoStack.Pop();
            }

            monoStack.Push(currentTemperature);
        }

        return daysToWait;
    }
}

//Better solution
public class Solution2
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        Stack<int> monoStack = new Stack<int>();
        int[] output = new int[temperatures.Length];

        for (int i = 0; i < temperatures.Length; ++i)
        {
            int currentTemperature = temperatures[i];

            while (monoStack.Count > 0 && currentTemperature > temperatures[monoStack.Peek()])
            {
                int dayIndex = monoStack.Pop();
                output[dayIndex] = i - dayIndex;
            }

            monoStack.Push(i);
        }

        return output;
    }
}