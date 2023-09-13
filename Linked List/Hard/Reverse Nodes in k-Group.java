//Problem: https://leetcode.com/problems/reverse-nodes-in-k-group/

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

class Solution {
    public ListNode reverseKGroup(ListNode head, int k) {
        ListNode dummy = new ListNode(0);
        dummy.next = head;

        ListNode groupStart = dummy;
        ListNode groupEnd;

        int counter = 0;
        while (head != null) {
            ++counter;

            if (counter == k) {
                groupEnd = head.next;

                ListNode prev = groupStart.next;
                ListNode tmp = prev.next;
                ListNode next;

                while (tmp != groupEnd) {
                    next = tmp.next;
                    tmp.next = prev;

                    prev = tmp;
                    tmp = next;
                }

                groupStart.next.next = groupEnd;

                ListNode newGroupStart = groupStart.next;
                groupStart.next = prev;
                groupStart = newGroupStart;

                counter = 0;
                head = groupStart;
            }

            head = head.next;
        }

        return dummy.next;
    }
}