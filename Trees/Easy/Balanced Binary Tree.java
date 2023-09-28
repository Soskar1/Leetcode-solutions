//Problem: https://leetcode.com/problems/balanced-binary-tree/

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
    public boolean isBalanced(TreeNode root) {
        int balanceFactor = calculateBalanceFactor(root);

        return balanceFactor != -1;
    }

    private int calculateBalanceFactor(TreeNode root) {
        if (root == null) {
            return 0;
        }

        int left = calculateBalanceFactor(root.left);
        int right = calculateBalanceFactor(root.right);

        if (Math.abs(left - right) > 1) {
            return -1;
        }

        if (left == -1 || right == -1) {
            return -1;
        }

        return Math.max(left, right) + 1;
    }
}