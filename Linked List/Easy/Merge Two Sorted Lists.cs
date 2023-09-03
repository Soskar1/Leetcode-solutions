//Problem: https://leetcode.com/problems/merge-two-sorted-lists/

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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null && list2 == null)
            return null;

        if (list1 != null && list2 == null)
            return list1;

        if (list1 == null && list2 != null)
            return list2;

        ListNode result = new ListNode();
        ListNode tmp = result;
        while (list1 != null || list2 != null)
        {
            if (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    tmp.val = list1.val;
                    list1 = list1.next;
                }
                else
                {
                    tmp.val = list2.val;
                    list2 = list2.next;
                }
            }
            else if (list1 == null && list2 != null)
            {
                tmp.val = list2.val;
                list2 = list2.next;
            }
            else if (list1 != null && list2 == null)
            {
                tmp.val = list1.val;
                list1 = list1.next;
            }

            if (list1 != null || list2 != null)
            {
                tmp.next = new ListNode();
                tmp = tmp.next;
            }
        }

        return result;
    }
}