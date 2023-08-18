//Problem: https://leetcode.com/problems/min-stack/

public class MinStack
{
    private List<int> _stack;
    private List<int> _minStack;

    public MinStack()
    {
        _stack = new List<int>();
        _minStack = new List<int>();
    }

    public void Push(int val)
    {
        _stack.Add(val);
        _minStack.Add(val);
        _minStack.Sort();
    }

    public void Pop()
    {
        _minStack.Remove(Top());
        _stack.RemoveAt(_stack.Count - 1);
    }

    public int Top()
    {
        return _stack[_stack.Count - 1];
    }

    public int GetMin()
    {
        return _minStack.First();
    }
}