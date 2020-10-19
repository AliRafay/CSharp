using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    public class Node
    {
        public int data;
        public Node left;
        public Node right;
    }

    public class BinarySearchTree
    {
        public Node root;
        public List<Node> myInOrderList = new List<Node>();

        public BinarySearchTree()
        {
            root = null;
        }
        public void DisplayNode(Node myNode)
        {
            Console.Write(myNode.data + "  ");
        }
        public void Insert(int i)
        {
            Node myNode = new Node();
            myNode.data = i;
            if (root == null)
            {
                root = myNode;
            }
            else
            {
                Node current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (i < current.data)
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = myNode;
                            break;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = myNode;
                            break;
                        }
                    }
                }

            }
        }
        private void SearchRecur(Node Current, int i)
        {
            if (Current.data == i)
            {
                Console.WriteLine("Found");
                //return this;
            }
            else if (i < Current.data && Current.left != null)
            {
                //return 
                SearchRecur(Current.left, i);
            }
            else if (i > Current.data && Current.right != null)
            {
                //return
                SearchRecur(Current.right, i);
            }
            else
            {
                Console.WriteLine("Not Found");
                //return null;
            }
        }
        public void Search(int i)
        {
            if (root == null)
            {
                Console.WriteLine("Emtpy Tree");
            }
            else
            {
                SearchRecur(root, i);

            }
        }
        public Node BringInOrderSuccessor(Node Current)
        {
            InOrderToList(root);
            foreach (Node myNode in myInOrderList)
            {
                if (myNode.data == Current.data)
                {
                    Console.WriteLine(myInOrderList[myInOrderList.IndexOf(myNode) + 1].data);
                    return myInOrderList[myInOrderList.IndexOf(myNode) + 1];// successor to current
                }

            }
            return null;
            //return myInOrderList[1]; // successor to current
        }
        public void RemoveSearch(Node Current, int i)
        {
            if (Current.left != null)
            {
                if (Current.left.data == i)   //finding child using parent as there is no reference from child to parent for deletion and we need to delete reference of child from parent
                {
                    //Console.WriteLine("Found");
                    if (Current.left.left == null && Current.left.right == null) //for leaf, no children
                    {
                        Current.left = null;
                    }
                    else if ((Current.left.left == null && Current.left.right != null) || (Current.left.left != null && Current.left.right == null)) //one child null
                    {
                        if (Current.left.left != null && Current.left.right == null)
                        {
                            Current.left = Current.left.left;
                        }
                        else
                        {
                            Current.left = Current.left.right;
                        }
                    }
                    else //both children present
                    {
                        Node successor = BringInOrderSuccessor(Current.left);
                        Current.left.data = successor.data;
                        RemoveSearch(Current.left, successor.data);
                    }
                }
                else if (i < Current.data)
                {
                    //Console.WriteLine("Moving left");
                    RemoveSearch(Current.left, i);
                }
            }
            if (Current.right != null)
            {
                if (Current.right.data == i)
                {
                    //Console.WriteLine("Found");
                    //Remove(right);
                    if (Current.right.left == null && Current.right.right == null)
                    {
                        Current.right = null;
                    }
                    else if ((Current.right.left == null && Current.right.right != null) || (Current.right.left != null && Current.right.right == null)) //one child null
                    {
                        if (Current.right.left != null && Current.right.right == null)
                        {
                            Current.right = Current.right.left;
                        }
                        else
                        {
                            Current.right = Current.right.right;
                        }
                    }
                    else //both children present
                    {
                        Node successor = BringInOrderSuccessor(Current.right);
                        Current.right.data = successor.data;
                        RemoveSearch(Current.right, successor.data);
                    }
                }

                else if (i > Current.data)
                {
                    //Console.WriteLine("Moving right");
                    RemoveSearch(Current.right, i);
                }
            }
            else
            {
                Console.WriteLine("Element Not Found");
            }
        }
        public void Remove(int i)
        {
            if (root == null)
            {
                Console.WriteLine("empty tree");
            }
            else
            {
                RemoveSearch(root, i);
            }
        }
        private void InOrderTreversalRecur(Node Current)
        {
            if (Current != null)
            {
                InOrderTreversalRecur(Current.left);
                DisplayNode(Current);
                InOrderTreversalRecur(Current.right);
            }
        }
        public void InOrderTreversal()
        {
            if (root == null)
            {
                Console.WriteLine("The Tree is Empty");
            }
            else
            {
                Console.WriteLine("InOrder Treversal");
                InOrderTreversalRecur(root);
                Console.WriteLine("\n");
            }
        }
        public void InOrderToList(Node Current)
        {
            if (Current != null)
            {
                InOrderToList(Current.left);
                myInOrderList.Add(Current);
                InOrderToList(Current.right);
            }
        }
        private void PreOrderTreversalRecur(Node Current)
        {
            if (Current != null)
            {
                DisplayNode(Current);
                PreOrderTreversalRecur(Current.left);
                PreOrderTreversalRecur(Current.right);
            }
        }
        public void PreOrderTreversal()
        {
            if (root == null)
            {
                Console.WriteLine("The Tree is Empty");
            }
            else
            {
                Console.WriteLine("PreOrder Treversal");
                PreOrderTreversalRecur(root);
                Console.WriteLine("\n");

            }
        }
        private void PostOrderTreversalRecur(Node Current)
        {
            if (Current != null)
            {
                PostOrderTreversalRecur(Current.left);
                PostOrderTreversalRecur(Current.right);
                DisplayNode(Current);
            }
        }
        public void PostOrderTreversal()
        {
            if (root == null)
            {
                Console.WriteLine("The Tree is Empty");
            }
            else
            {
                Console.WriteLine("PostOrder Treversal");
                PostOrderTreversalRecur(root);
                Console.WriteLine("\n");

            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                BinarySearchTree myTree = new BinarySearchTree();
                myTree.Insert(20);
                myTree.Insert(10);
                myTree.Insert(35);
                myTree.Insert(2);
                myTree.Insert(5);
                myTree.Insert(15);
                myTree.Insert(25);
                myTree.Insert(30);
                myTree.Insert(18);
                myTree.Insert(22);
                myTree.Insert(32);


                myTree.InOrderTreversal();
                //myTree.PreOrderTreversal();
                //myTree.PostOrderTreversal();


                //myTree.Search(23);
                //myTree.Search(25);
                //myTree.Search(10);
                myTree.Remove(30);
                myTree.Remove(10);
                //myTree.Remove(15); 
                //myTree.Remove(35);
                myTree.InOrderTreversal();


            }
        }
    }
}
