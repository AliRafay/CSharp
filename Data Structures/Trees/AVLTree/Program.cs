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
        public int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }
        public int GetBalance(Node myNode)
        {
            if (myNode == null)
                return 0;
            else
                return GetHeight(myNode.right) - GetHeight(myNode.left);
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
        Stack<Node> myStack = new Stack<Node>();
        public void Insert(int i) //we need node instead of data in order to increase height of node
        {
            Node myNode = new Node();
            myNode.data = i;
            if (root == null)
            {
                root = myNode;
                //myStack.Push(root);
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
                            myStack.Push(myNode);

                            break;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = myNode;
                            myStack.Push(myNode);
                            break;
                        }
                    }
                }
                //myNode.height = 1 + Max(Height(myNode.left), Height(myNode.right));
                //int balance = GetBalance(myNode);

            }// end of insertion

        }
        public void AssignHeightsAndBalance()
        {
            //Managing Height with Stacks
            while (myStack.Count != 0)
            {
                Node Current = myStack.Pop();
                if (Current.left == null && Current.right == null)
                { Current.height = 1; }
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
                int balance = GetBalance(Current);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                AVLTree myTree = new AVLTree();
                //myTree.Insert(43);
                //myTree.Insert(18);
                //myTree.Insert(22);
                //myTree.Insert(17);
                myTree.Insert(20);
                myTree.Insert(10);
                myTree.Insert(35);
                myTree.Insert(2);
                myTree.Insert(5);
                myTree.Insert(15);
                myTree.Insert(25);
                myTree.Insert(17);
                myTree.Insert(18);
                myTree.Insert(22);
                myTree.Insert(32);
                myTree.AssignHeights();
                //Console.WriteLine(myTree.GetHeight(myTree.root));
            }
        }
    }
}
