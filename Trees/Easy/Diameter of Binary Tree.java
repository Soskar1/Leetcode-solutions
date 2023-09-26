//Problem: https://leetcode.com/problems/diameter-of-binary-tree/

class TreeNode {
    int val;
    TreeNode left;
    TreeNode right;
    TreeNode() {}
    TreeNode(int val) { this.val = val; }
    TreeNode(int val, TreeNode left, TreeNode right) {
        this.val = val;
       this.left = left;
       this.right = right;
    }
}

class Solution {
    int max = 0;

    public int diameterOfBinaryTree(TreeNode root) {
        calculateDiameter(root);
        return max;
    }

    public int calculateDiameter(TreeNode root) {
        if (root == null) {
            return -1;
        }

        int right = calculateDiameter(root.right);
        int left = calculateDiameter(root.left);

        max = Math.max(left + right + 2, max);

        return Math.max(right, left) + 1;
    }
}