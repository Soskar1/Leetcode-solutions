//Problem: https://leetcode.com/problems/merge-k-sorted-lists/

import java.util.Arrays;

class ListNode {
    int val;
    ListNode next;

    ListNode() {}

    ListNode(int val) {
        this.val = val;
    }

    ListNode(int val, ListNode next) {
        this.val = val;
        this.next = next;
    }
}

public class Solution {
    class Heap {
        private int capacity = 10;
        private int size = 0;
        private ListNode[] heap = new ListNode[capacity];

        private int getLeftChildIndex(int parentIndex) {
            return 2 * parentIndex + 1;
        }

        private int getRightChildIndex(int parentIndex) {
            return 2 * parentIndex + 2;
        }

        private int getParentIndex(int childIndex) {
            return (childIndex - 1) / 2;
        }

        private boolean hasLeftChild(int index) {
            return getLeftChildIndex(index) < size;
        }

        private boolean hasRightChild(int index) {
            return getRightChildIndex(index) < size;
        }

        private boolean hasParent(int index) {
            return getParentIndex(index) >= 0;
        }

        private ListNode leftChild(int index) {
            return heap[getLeftChildIndex(index)];
        }

        private ListNode rightChild(int index) {
            return heap[getRightChildIndex(index)];
        }

        private ListNode parent(int index) {
            return heap[getParentIndex(index)];
        }

        private void swap(int firstIndex, int secondIndex) {
            ListNode tmp = heap[firstIndex];
            heap[firstIndex] = heap[secondIndex];
            heap[secondIndex] = tmp;
        }

        private void ensureExtraCapacity() {
            if (size == capacity) {
                heap = Arrays.copyOf(heap, capacity * 2);
                capacity *= 2;
            }
        }

        public ListNode peek() {
            if (size == 0)
                return null;

            return heap[0];
        }

        public ListNode poll() {
            if (size == 0)
                return null;

            ListNode first = heap[0];
            heap[0] = heap[size - 1];
            --size;
            heapifyDown();
            return first;
        }

        public void add(ListNode node) {
            ensureExtraCapacity();
            heap[size] = node;
            ++size;
            heapifyUp();
        }

        private void heapifyUp() {
            int index = size - 1;
            while (hasParent(index) && parent(index).val > heap[index].val) {
                int parentIndex = getParentIndex(index);
                swap(parentIndex, index);
                index = parentIndex;
            }
        }

        private void heapifyDown() {
            int index = 0;
            while (hasLeftChild(index)) {
                int smallerChildIndex = getLeftChildIndex(index);
                if (hasRightChild(index) && rightChild(index).val < leftChild(index).val) {
                    smallerChildIndex = getRightChildIndex(index);
                }

                if (heap[index].val < heap[smallerChildIndex].val) {
                    break;
                }

                swap(index, smallerChildIndex);
                index = smallerChildIndex;
            }
        }

        public boolean isEmpty() {
            return size == 0;
        }
    }

    public ListNode mergeKLists(ListNode[] lists) {
        Heap heap = new Heap();

        for (var linkedList : lists) {
            ListNode tmp = linkedList;
            ListNode prev = tmp;
            while (tmp != null) {
                heap.add(tmp);
                tmp = tmp.next;

                prev.next = null;
                prev = tmp;
            }
        }

        ListNode dummy = new ListNode(0);
        ListNode prev = dummy;
        while (!heap.isEmpty()) {
            ListNode tmp = heap.poll();
            prev.next = tmp;
            prev = tmp;
        }

        return dummy.next;
    }
}