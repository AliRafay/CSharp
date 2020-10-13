using System;

namespace Singly_Linked_List
{
    public class Node
    {
        public int data;
        public Node next;

        public Node()
        {
            data = 0;
            next = null;
        }
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

        public void AddSorted(int data)
        {
            if (next == null)
            {
                next = new Node(data);
            }
            else if (data < next.data)
            {
                Node temp = new Node(data);
                temp.next = this.next;
                this.next = temp;
            }
            else
            {
                next.AddSorted(data);
            }
        }

        public Node Find(int data)
        {
            if (data == this.data)    //this.data for node's data, next.data for next node's data
            {
                Node temp = this;
                //Console.WriteLine("Found");
                return temp;
            }
            else if (next == null)
            {
                //Console.WriteLine("Not Found");
                return null;
            }
            else
            {
                return next.Find(data);
            }
        }

        public void AddAfter(int data, int currentData)
        {
            Node NodeToAdd = new Node(data);
            if (Find(currentData) != null)
            {
                Node currentNode = Find(currentData);
                NodeToAdd.next = currentNode.next;
                currentNode.next = NodeToAdd;
            }
            else
            {
                Console.WriteLine("Couldn't Find the Node provided");
            }
        }

        public Node FindPrevious(int data)
        {
            Node current = this;
            while ((current.next != null) && (current.next.data != data))
            {
                current = current.next;
            }
            Console.WriteLine(current.data);
            return current;
        }

        //public void Remove(int data)
        //{
        //    Node NodeToRemove = Find(data);
        //}
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

        public void AddSorted(int data)
        {
            if (headNode == null)
            {
                headNode = new Node(data);
            }
            else if (data < headNode.data)
            {
                AddToBeginning(data);
            }
            else
            {
                headNode.AddSorted(data);
            }
        }

        public void Find(int data)
        {
            if (headNode == null)
            {
                Console.WriteLine("List is Empty");
            }
            else
            {
                headNode.Find(data);
            }
        }
        public void AddAfter(int data, int currentData)
        {
            if (headNode == null)
            {
                Console.WriteLine("List is Empty");
            }
            else
            {
                headNode.AddAfter(data, currentData);
            }
        }

        public void FindPrevious(int data)
        {
            if (headNode == null)
            {
                Console.WriteLine("List is Empty");
            }
            else
            {
                headNode.FindPrevious(data);
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
            //myList.AddToEnd(3);
            //myList.AddToEnd(4);                    Third Approach
            //myList.AddToEnd(8);

            //myList.AddToBeginning(10);

            myList.AddSorted(6);
            myList.AddSorted(4);
            myList.AddSorted(9);
            myList.AddSorted(2);


            myList.Print();
            Console.WriteLine("\n");

            //myList.Find(3);
            //myList.Find(6);

            myList.AddAfter(7, 6);

            myList.Print();

            myList.FindPrevious(9);
        }
    }
}
