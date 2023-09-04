//Problem: https://leetcode.com/problems/reorder-list/

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
    public void ReorderList(ListNode head)
    {
        List<ListNode> nodes = new List<ListNode>();
        ListNode tmp = head;

        while (tmp != null)
        {
            nodes.Add(tmp);
            tmp = tmp.next;
        }

        int start = 0;
        int end = nodes.Count - 1;

        while (start < end)
        {
            nodes[start].next = nodes[end];
            ++start;

            if (start == end)
                break;

            nodes[end].next = nodes[start];
            --end;
        }

        nodes[end].next = null;
    }
}