//Problem: https://leetcode.com/problems/maximum-depth-of-binary-tree/

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
    public int maxDepth(TreeNode root) {
        return calculateDepth(root, 0);
    }

    private int calculateDepth(TreeNode node, int currentDepth) {
        if (node == null) {
            return currentDepth;
        }
        ++currentDepth;
        return Math.max(calculateDepth(node.left, currentDepth), calculateDepth(node.right, currentDepth));
    }
}