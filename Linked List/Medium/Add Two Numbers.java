//Problem: https://leetcode.com/problems/add-two-numbers/

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
    public ListNode addTwoNumbers(ListNode l1, ListNode l2) {
        ListNode newLinkedList = new ListNode(0);
        ListNode prev = newLinkedList;
        ListNode tmp;
        boolean reminder = false;

        while (l1 != null && l2 != null)
        {
            int sum = l1.val + l2.val + (reminder ? 1 : 0);
            reminder = false;

            if (sum >= 10)
            {
                reminder = true;
                sum %= 10;
            }

            tmp = new ListNode(sum);
            prev.next = tmp;
            prev = tmp;

            l1 = l1.next;
            l2 = l2.next;
        }

        while (reminder)
        {
            if (l1 == null && l2 == null)
            {
                prev.next = new ListNode(1);
                reminder = false;
            }
            else if (l1 == null)
            {
                int sum = l2.val + (reminder ? 1 : 0);

                reminder = false;
                if (sum >= 10)
                {
                    reminder = true;
                    sum %= 10;
                }

                tmp = new ListNode(sum);
                prev.next = tmp;
                prev = tmp;

                l2 = l2.next;
            }
            else if (l1 != null && l2 == null)
            {
                int sum = l1.val + (reminder ? 1 : 0);

                reminder = false;
                if (sum >= 10)
                {
                    reminder = true;
                    sum %= 10;
                }

                tmp = new ListNode(sum);
                prev.next = tmp;
                prev = tmp;

                l1 = l1.next;
            }
        }

        if (l1 != null)
            prev.next = l1;
        else if (l2 != null)
            prev.next = l2;

        return newLinkedList.next;
    }
}