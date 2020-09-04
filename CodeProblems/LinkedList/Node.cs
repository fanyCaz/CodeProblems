using System;
using System.Collections.Generic;
using System.Text;

namespace CodeProblems.LinkedList
{
    public class Node
    {
        int data;
        Node next; //is referring to the next box this one is connected to

        Node(int data)
        {
            this.data = data;
        }

        public static void AssignNodes()
        {
            Node nodeA = new Node(6);
            Node nodeB = new Node(3);
            Node nodeC = new Node(4);
            Node nodeD = new Node(2);
            Node nodeE = new Node(1);

            nodeA.next = nodeB;
            nodeB.next = nodeC;
            nodeC.next = nodeD;
            nodeD.next = nodeE;
        }

        int countNodes(Node head, int counter=1)
        {
            if (head.next != null)
            {
                countNodes(head, counter + 1);
            }
            return counter;
        }
    }

}
