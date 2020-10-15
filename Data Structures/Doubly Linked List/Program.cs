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
            Console.Write("|" + data + "|<-->");
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
                //Console.WriteLine(next.data);
                next.previous = this;
                //Console.WriteLine(next.previous.data);
                
            }
            else
            {
                next.AddToEnd(data);
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
        public Node FindPrevious(int data)
        {
            if (data == this.data && previous != null)    //this.data for node's data, next.data for next node's data
            {
                //Console.WriteLine("Found" + previous.data);
                return previous;
            }
            
            else if (next != null)
            {
                return next.FindPrevious(data);
            }
            else
            {
                return null;
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
        public void AddBefore(int data, int currentData)
        {
            Node NodeToAdd = new Node(data);
            if (FindPrevious(currentData) != null)
            {
                Node currentNode = FindPrevious(currentData);
                NodeToAdd.next = currentNode.next;
                currentNode.next = NodeToAdd;
            }
            else
            {
                Console.WriteLine("Couldn't Find the Node provided");
            }
        }
        public void Remove(int data)
        {
            Node NodeToRemove = Find(data);
            Node PreviousNode = FindPrevious(data);

            PreviousNode.next = NodeToRemove.next;
            NodeToRemove.next.previous = NodeToRemove.previous ;
        }
    }
    public class DoublyLinkedList
    {
        public Node headNode;
        public int count;
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
        public void Length()
        {
            Node temp = headNode;
            while (temp != null)
            {
                temp = temp.next;
                count++;
            }
            Console.WriteLine("The Length of List is {0}", count);
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
        public void AddBefore(int data, int currentData)
        {
            if (headNode == null)
            {
                Console.WriteLine("List is Empty");
            }
            else
            {
                headNode.AddBefore(data, currentData);
            }
        }
        public void Remove(int data)
        {
            if (headNode == null)
            {
                Console.WriteLine("List is already Empty");
            }
            else if (data == headNode.data)
            {
                headNode = headNode.next;
            }
            else
            {
                headNode.Remove(data);
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
            myList.AddToEnd(7);

            //myList.AddToBeginning(7);

            myList.Print();
            Console.WriteLine("\n");

            //myList.Find(17);
            //myList.Find(10);

            //myList.AddAfter(39, 17);
            //myList.Print();
            //myList.Length();
            //myList.Remove(9);
            ////myList.AddBefore(13, 40);
            //myList.Print();


        }

    }

}
