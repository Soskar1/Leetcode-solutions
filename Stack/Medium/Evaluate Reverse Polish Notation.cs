//Problem: https://leetcode.com/problems/evaluate-reverse-polish-notation/

public class Solution
{
    public int EvalRPN(string[] tokens)
    {
        Stack<string> stack = new Stack<string>();
        string token2;
        string token1;
        string result;

        foreach (string token in tokens)
        {
            switch (token)
            {
                case "+":
                    {
                        token2 = stack.Pop();
                        token1 = stack.Pop();
                        result = ArithmeticOperation(token1, token2, (num1, num2) => num1 + num2);
                        stack.Push(result);
                        break;
                    }
                case "-":
                    {
                        token2 = stack.Pop();
                        token1 = stack.Pop();
                        result = ArithmeticOperation(token1, token2, (num1, num2) => num1 - num2);
                        stack.Push(result);
                        break;
                    }
                case "*":
                    {
                        token2 = stack.Pop();
                        token1 = stack.Pop();
                        result = ArithmeticOperation(token1, token2, (num1, num2) => num1 * num2);
                        stack.Push(result);
                        break; 
                    }
                case "/":
                    {
                        token2 = stack.Pop();
                        token1 = stack.Pop();
                        result = ArithmeticOperation(token1, token2, (num1, num2) => num1 / num2);
                        stack.Push(result);
                        break;
                    }
                default:
                    {
                        stack.Push(token);
                        break;
                    }
            }
        }

        return Int32.Parse(stack.Pop());
    }

    private string ArithmeticOperation(string token1, string token2, Func<int, int, int> func)
    {
        int num1 = Int32.Parse(token1);
        int num2 = Int32.Parse(token2);
        return func(num1, num2).ToString();
    }
}