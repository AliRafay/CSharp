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
    class Program
    {
        static void Main(string[] args)
        {
            Node myNode = new Node(5);
            //myNode.next = new Node(3);
            //myNode.next.next = new Node(9);
            myNode.Print();
        }
    }
}
