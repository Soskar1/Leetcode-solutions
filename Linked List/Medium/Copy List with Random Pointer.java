//Problem: https://leetcode.com/problems/copy-list-with-random-pointer/

import java.util.ArrayList;
import java.util.List;
class Node {
    int val;
    Node next;
    Node random;

    public Node(int val) {
        this.val = val;
        this.next = null;
        this.random = null;
    }
}

class Solution {
    public Node copyRandomList(Node head) {
        if (head == null)
            return null;

        Node newHead = new Node(head.val);
        Node prev = newHead;
        Node tmp = head.next;

        List<Node> oldLinkedList = new ArrayList<Node>();
        List<Node> newLinkedList = new ArrayList<Node>();

        oldLinkedList.add(head);
        newLinkedList.add(newHead);

        while (tmp != null)
        {
            Node node = new Node(tmp.val);
            prev.next = node;
            prev = node;

            oldLinkedList.add(tmp);
            newLinkedList.add(node);

            tmp = tmp.next;
        }

        for (int i = 0; i < oldLinkedList.size(); ++i)
        {
            Node randomNode = oldLinkedList.get(i).random;

            if (randomNode != null)
            {
                int index = oldLinkedList.indexOf(randomNode);
                newLinkedList.get(i).random = newLinkedList.get(index);
            }
            else
            {
                newLinkedList.get(i).random = null;
            }
        }

        return newHead;
    }
}