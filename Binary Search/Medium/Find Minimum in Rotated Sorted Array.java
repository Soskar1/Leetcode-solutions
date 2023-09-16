//Problem: https://leetcode.com/problems/find-minimum-in-rotated-sorted-array/

class Solution {
    public int findMin(int[] nums) {
        int min = nums[0];

        int start = 1;
        int end = nums.length - 1;

        while (start <= end) {
            int mid = start + (end - start) / 2;

            if (min > nums[mid]) {
                min = nums[mid];
                end = mid - 1;
            } else {
                start = mid + 1;
            }
        }

        return min;
    }
}