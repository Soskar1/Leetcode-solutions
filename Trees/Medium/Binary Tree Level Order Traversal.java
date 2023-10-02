//Problem: https://leetcode.com/problems/binary-tree-level-order-traversal/

import java.util.ArrayList;
import java.util.List;

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
    public List<List<Integer>> levelOrder(TreeNode root) {
        List<List<Integer>> levelOrderList = new ArrayList<>();
        levelOrder(root, 0, levelOrderList);
        return levelOrderList;
    }

    private void levelOrder(TreeNode root, int layerIndex, List<List<Integer>> levelOrderList) {
        if (root == null) {
            return;
        }

        if (layerIndex >= levelOrderList.size()) {
            levelOrderList.add(new ArrayList<>());
        }

        levelOrderList.get(layerIndex).add(root.val);

        levelOrder(root.left, layerIndex + 1, levelOrderList);
        levelOrder(root.right, layerIndex + 1, levelOrderList);
    }
}