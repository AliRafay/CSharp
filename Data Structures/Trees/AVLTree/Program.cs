using System;
using System.Collections.Generic;

namespace AVLTree
{
    public class Node
    {
        public int data, height = 0;
        public Node left, right;
    }
    public class AVLTree
    {
        public Node root;
        public void DisplayNode(Node myNode)
        {
            Console.Write(myNode.data + "  ");
        }
        public int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }
        public int GetBalance(Node myNode)
        {
            if (myNode == null)
                return 0;
            else
                return GetHeight(myNode.left) - GetHeight(myNode.right);
        }
        public int GetHeight(Node myNode)
        {
            if (myNode == null)
            {
                return 0;
            }
            else
            {
                return myNode.height;
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
        //Stack<Node> StackToBalance = new Stack<Node>();
        Stack<Node> StacksPermanent = new Stack<Node>();
        public void Insert(int i) //we need node instead of data in order to increase height of node
        {
            Node myNode = new Node();
            myNode.data = i;
            if (root == null)
            {
                root = myNode;
                //StackToBalance.Push(myNode);
                StacksPermanent.Push(myNode);
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
                            //StackToBalance.Push(myNode);
                            StacksPermanent.Push(myNode);
                            break;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = myNode;
                            //StackToBalance.Push(myNode);
                            StacksPermanent.Push(myNode);
                            break;
                        }
                    }
                }
                if (StacksPermanent.Count >= 3)
                {
                    AssignHeightsAndBalance(myNode);
                }
            }// end of insertion

        }
        //public static Stack<Node> Clone<T>(this Stack<Node> original)
        //{
        //    var arr = new Node[original.Count];
        //    original.CopyTo(arr, 0);
        //    Array.Reverse(arr);
        //    return new Stack<Node>(arr);
        //}
        public void AssignHeightsAndBalance(Node PrevAddedNode)
        {
            //Stack<Node> temp = myStack;
            //Managing Height with Stacks
            Queue<Node> StackToBalance = new Queue<Node>(StacksPermanent);
            while (StackToBalance.Count != 0)
            {
                int temp = StackToBalance.Peek().data;
                Node Current = StackToBalance.Dequeue();
                if (Current.left == null && Current.right == null)
                { Current.height = 0; }
                else if (Current.left == null && Current.right != null)
                {
                    Current.height = 1 + Current.right.height;
                }
                else if (Current.left != null && Current.right == null)
                {
                    Current.height = 1 + Current.left.height;
                }
                else
                {
                    Current.height = 1 + Max(Current.left.height, Current.right.height);
                }

                //assigning Heights complete
                //temp = Current.right.data;
                int balance = GetBalance(Current);
                //Console.WriteLine(balance);
                if (balance > 1)
                {
                    Node CriticalNode = Current;
                    //popping order creating error, not in a child to parent direction
                    if (PrevAddedNode.data < Current.left.data)
                    {
                        RightRotate(CriticalNode);
                    }
                    else
                    {
                        //LeftRightRotate(CriticalNode);
                    }
                }
                else if (balance < -1)
                {
                    Node CriticalNode = Current;
                    if (PrevAddedNode.data > Current.right.data)
                    {
                        LeftRotate(CriticalNode);
                    }
                    else
                    {
                        //RightLeftRotate(CriticalNode);
                    }
                }
            }
        }
        public Node RightRotate(Node CriticalNode)
        {

            Node leftChild = CriticalNode.left;
            CriticalNode.left = leftChild.right;
            leftChild.right = CriticalNode;
            if (CriticalNode.data == root.data)
            {
                root = leftChild;
            }
            return leftChild; // new root
        }
        public Node LeftRotate(Node CriticalNode)
        {
            Node rightChild = CriticalNode.right;
            CriticalNode.right = rightChild.left;
            rightChild.left = CriticalNode;
            if(CriticalNode.data == root.data)
            {
                root = rightChild;
            }
            return rightChild; // new root
        }
        class Program
        {
            static void Main(string[] args)
            {
                AVLTree myTree = new AVLTree();
                myTree.Insert(43);
                myTree.Insert(18);
                myTree.Insert(22);
                myTree.Insert(9);
                myTree.Insert(21);
                myTree.Insert(6);
                myTree.Insert(8);
                myTree.Insert(20);
                myTree.Insert(63);
                myTree.Insert(50);

                //myTree.AssignHeightsAndBalance();
                Console.WriteLine(myTree.root.data);
                myTree.PreOrderTreversal();
            }
        }
    }
}
