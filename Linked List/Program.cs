using System;

namespace Linked_List
{
    public class Node
    {
        public int data;
        public Node next;

        public Node(int i)
        {
            data = i;
            next = null;
        }

        public void Print()
        {
            Console.Write("|" + data + "|-->");
            if (next != null)
            {
                next.Print();
            }
        }

        public void AddToEnd(int data)
        {
            if (next == null)
            {
                next = new Node(data);
            }
            else
            {
                next.AddToEnd(data);
            }
        }
    }

    public class LinkedList
    {
        public Node headNode;

        public LinkedList()
        {
            headNode = null;
        }

        public void AddToEnd(int data)
        {
            if (headNode == null)
            {
                headNode = new Node(data);
            }
            else
            {
                headNode.AddToEnd(data);
            }
        }

        public void Print()
        {
            if (headNode != null)
            {
                headNode.Print();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Node myNode = new Node(5);
            //myNode.next = new Node(3);             First Approach
            //myNode.next.next = new Node(9);

            //myNode.AddToEnd(3);
            //myNode.AddToEnd(9);                    Second Approach
            //myNode.AddToEnd(7);


            LinkedList myList = new LinkedList();
            myList.AddToEnd(3);
            myList.AddToEnd(4);                     //Third Approach
            myList.AddToEnd(8);

            myList.Print();
        }
    }
}
