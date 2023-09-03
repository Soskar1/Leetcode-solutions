//Problem: https://leetcode.com/problems/reverse-linked-list/

public class ListNode {
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;     
    }
}

public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        ListNode previous = null;
        List<ListNode> list = new List<ListNode>();

        while (head != null)
        {
            list.Add(head);
            previous = head;
            head = head.next;
            previous.next = null;
        }

        for (int i = list.Count - 1; i > 0; --i)
            list[i].next = list[i - 1]; 

        return previous;
    }
}