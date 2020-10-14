using System;

namespace Doubly_Linked_List
{
    public class Node
    {
        public int data;
        public Node next;
        public Node previous;

        public Node(int i)
        {
            data = i;
            next = null;
            previous = null;
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
                next.previous = this;

            }
            else
            {
                next.AddToEnd(data);
            }

        }

    }
    public class DoublyLinkedList
    {
        public Node headNode;
        public DoublyLinkedList()
        {
            headNode = null;
        }
        public void Print()
        {
            if (headNode != null)
            {
                headNode.Print();
            }
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
        public void AddToBeginning(int data)
        {
            if (headNode == null)
            {
                headNode = new Node(data);
            }
            else
            {
                Node temp = new Node(data);
                temp.next = headNode;
                headNode = temp;
            }
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList myList = new DoublyLinkedList();

            myList.AddToEnd(9);
            myList.AddToEnd(17);
            myList.AddToEnd(40);

            myList.AddToBeginning(7);

            myList.Print();

        }
    }

}
