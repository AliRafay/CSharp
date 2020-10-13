using System;

namespace Doubly_Linked_List
{
    public class Node
    {
        public int data;
        public Node flink;
        public Node blink;

        public Node(int i)
        {
            data = i;
            flink = null;
            blink = null;
        }

        public void Print()
        {
            Console.Write("|" + data + "|-->");
            if (flink != null)
            {
                flink.Print();
            }
        }

        public void AddToEnd(int data)
        {
            if (flink == null)
            {
                flink = new Node(data);
                flink.blink = this;
            }
            else
            {
                flink.AddToEnd(data);
            }
        }

        public void AddToBeginning(int data)   // error NOT ADDING TO BEGINNING
        {
            if (blink == null)
            {
                blink = new Node(data);
                blink.flink = this;
            }
            else
            {
                blink.AddToBeginning(data);
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
                headNode.AddToBeginning(data);
            }
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList myList = new DoublyLinkedList();

            myList.AddToEnd(9);
            myList.AddToEnd(40);
            myList.AddToBeginning(7);

            myList.Print();

        }
    }
}
