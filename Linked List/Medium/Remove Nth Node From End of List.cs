//Problem: https://leetcode.com/problems/remove-nth-node-from-end-of-list/

public class ListNode {
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null) {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode left = new ListNode(0, head);
        ListNode right = head.next;
        ListNode end = head;
        for (int i = 0; i < n; ++i)
            end = end.next;

        if (end == null)
        {
            if (right == null)
                return null;

            return right;
        }

        while (end != null)
        {
            left = left.next;
            right = right.next;
            end = end.next;
        }

        left.next.next = null;
        left.next = right;

        return head;
    }
}