//Problem: https://leetcode.com/problems/lru-cache/

import java.util.HashMap;

class ListNode {
    int val;
    int key;
    ListNode right;
    ListNode left;

    ListNode(int val, int key) {
        this.val = val;
        this.key = key;
        right = null;
        left = null;;
    }
}

public class LRUCache {
    private final HashMap<Integer, ListNode> CACHE;
    private final ListNode DUMMY_FIRST;
    private final ListNode DUMMY_LAST;
    private final int CAPACITY;

    public LRUCache(int capacity) {
        CAPACITY = capacity;
        CACHE = new HashMap<>(capacity);

        DUMMY_FIRST = new ListNode(0, 0);
        DUMMY_LAST = new ListNode(0, 0);

        DUMMY_FIRST.right = DUMMY_LAST;
        DUMMY_LAST.left = DUMMY_FIRST;
    }

    public int get(int key) {
        if (CACHE.containsKey(key)) {
            ListNode node = CACHE.get(key);
            moveToTheLast(node);
            return node.val;
        }

        return -1;
    }

    public void put(int key, int value) {
        if (CACHE.containsKey(key)) {
            ListNode node = CACHE.get(key);
            node.val = value;

            moveToTheLast(node);
            return;
        }

        if (CACHE.size() == CAPACITY) {
            removeFirst();
            addNode(key, value);
        } else {
            addNode(key, value);
        }
    }

    private void addNode(int key, int value) {
        ListNode newNode = new ListNode(value, key);
        ListNode tmp = DUMMY_LAST.left;
        DUMMY_LAST.left = newNode;
        newNode.right = DUMMY_LAST;
        newNode.left = tmp;
        tmp.right = newNode;

        CACHE.put(key, newNode);
    }

    private void removeFirst() {
        removeNode(DUMMY_FIRST.right);
    }

    private void removeNode(ListNode node) {
        unlink(node);
        CACHE.remove(node.key);
    }

    private void moveToTheLast(ListNode node) {
        unlink(node);
        ListNode last = DUMMY_LAST.left;

        last.right = node;
        node.left = last;

        node.right = DUMMY_LAST;
        DUMMY_LAST.left = node;
    }

    private void unlink(ListNode node) {
        ListNode left = node.left;
        ListNode right = node.right;

        node.right = null;
        node.left = null;
        left.right = right;
        right.left = left;
    }
}
