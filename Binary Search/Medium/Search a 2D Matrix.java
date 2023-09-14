//Problem: https://leetcode.com/problems/search-a-2d-matrix/

class Solution {
    public boolean searchMatrix(int[][] matrix, int target) {
        int start = 0;
        int end = matrix.length - 1;

        while (start <= end) {
            int mid = start + ((end - start) / 2);

            if (matrix[mid][0] == target) {
                return true;
            }

            if (matrix[mid][0] > target) {
                end = mid - 1;
            }

            if (matrix[mid][0] < target) {
                if ((mid + 1 < matrix.length && matrix[mid + 1][0] > target) || mid + 1 == matrix.length) {
                    return binarySearch(matrix[mid], target, 0, matrix[mid].length - 1);
                }

                start = mid + 1;
            }
        }

        return false;
    }

    private boolean binarySearch(int[] nums, int target, int start, int end) {
        if (start > end) {
            return false;
        }

        int mid = start + ((end - start) / 2);

        if (nums[mid] == target) {
            return true;
        }

        if (nums[mid] > target) {
            return binarySearch(nums, target, start, mid - 1);
        }

        return binarySearch(nums, target, mid + 1, end);
    }
}