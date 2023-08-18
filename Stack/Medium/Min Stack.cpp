//Problem: https://leetcode.com/problems/min-stack/

#include <iostream>
#include <vector>
#include <set>

using namespace std;

class MinStack {
private:
    multiset<int> m_MinStack;
    vector<int> m_Stack;

public:

    MinStack() {
        m_Stack = vector<int>();
        m_MinStack = multiset<int>();
    }

    void push(int val) {
        m_Stack.push_back(val);
        m_MinStack.insert(val);
    }

    void pop() {
        m_MinStack.erase(m_MinStack.lower_bound(top()));
        m_Stack.pop_back();
    }

    int top() {
        return m_Stack[m_Stack.size() - 1];
    }

    int getMin() {
        return *m_MinStack.begin();
    }
};