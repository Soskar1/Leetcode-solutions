//Problem: https://leetcode.com/problems/sliding-window-maximum/

#include <iostream>
#include <vector>
#include <deque>

using namespace std;

class Solution {
public:
    vector<int> maxSlidingWindow(vector<int> nums, int k) {
        deque<int> dq = deque<int>();
        vector<int> maxWindow = vector<int>();

        for (int i = 0; i < k; ++i)
        {
            if (dq.empty())
            {
                dq.push_front(i);
                continue;
            }

            if (nums[dq.front()] > nums[i])
            {
                while (nums[dq.back()] < nums[i])
                    dq.pop_back();

                dq.push_back(i);
            }
            else if (nums[dq.front()] <= nums[i])
            {
                dq.clear();
                dq.push_front(i);
            }
        }

        for (int i = 0; i + k < nums.size(); ++i)
        {
            maxWindow.push_back(nums[dq.front()]);

            if (i == dq.front())
                dq.pop_front();

            int endIndex = i + k;

            if (dq.empty())
            {
                dq.push_front(endIndex);
                continue;
            }

            if (nums[dq.front()] > nums[endIndex])
            {
                while (nums[dq.back()] < nums[endIndex])
                    dq.pop_back();

                dq.push_back(endIndex);
            }
            else
            {
                dq.clear();
                dq.push_front(endIndex);
            }
        }

        maxWindow.push_back(nums[dq.front()]);

        return maxWindow;
    }
};

int main()
{
    Solution solution = Solution();
    vector<int> maxWindow = solution.maxSlidingWindow(vector<int>({ 1,3,-1,-3,5,3,6,7 }), 3);

    for (auto num : maxWindow)
        cout << num << " ";

    return 0;
}