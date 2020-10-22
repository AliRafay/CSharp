using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace AVLTree
{
    public class Node
    {
        public int data, height = 0;
        public Node left, right;
        public Node(int i)
        {
            data = i;
        }
    }
    public class AVLTree
    {
        public Node root;
        Stack<Node> StacksPermanent = new Stack<Node>();
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
        public void Insert(int i)
        {
            Node myNode = new Node(i);
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
                StacksPermanent = new Stack<Node>();
                PostOrderTreversalStacking(root);
                if (StacksPermanent.Count >= 3)
                {
                    AssignHeightsAndBalance(myNode);
                }
            }// end of insertion
            //post order treversal stacking should be done
        }
        private void PostOrderTreversalStacking(Node Current)
        {
            if (Current != null)
            {
                PostOrderTreversalStacking(Current.left);
                PostOrderTreversalStacking(Current.right);
                StacksPermanent.Push(Current);
            }
        }
        public void AssignHeightsAndBalance(Node PrevAddedNode)
        {
            //Stack<Node> temp = myStack;
            //Managing Height with Stacks
            Stack<Node> StackToBalance = new Stack<Node>(StacksPermanent);
            while (StackToBalance.Count != 0)
            {
                int temp = StackToBalance.Peek().data;
                Node Current = StackToBalance.Pop();
                Current.height = 0;
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
                //temp = Current.right.data;
                int balance = GetBalance(Current);
                //Console.WriteLine(balance);
                if (balance > 1)
                {
                    Node CriticalNode = Current;
                    if (PrevAddedNode.data < Current.left.data)
                    {
                        RightRotate(CriticalNode);
                    }
                    else
                    {
                        LeftRightRotate(CriticalNode);
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
                        RightLeftRotate(CriticalNode);
                    }
                }
            }
        }
        public void RightRotate(Node CriticalNode)
        {
            Console.WriteLine("Right Rotation");
            Node newCritical = new Node(CriticalNode.data);
            CriticalNode.data = CriticalNode.left.data;
            newCritical.left = CriticalNode.left.right;
            CriticalNode.left = CriticalNode.left.left;
            Node rightChild = CriticalNode.right;
            newCritical.right = rightChild;
            CriticalNode.right = newCritical;
            CriticalNode.height = Max(GetHeight(CriticalNode.left), GetHeight(CriticalNode.right));
            if (CriticalNode.data == root.data)
            {
                root = CriticalNode;
            }
            //return CriticalNode; // new root
        }
        public void LeftRotate(Node CriticalNode)
        {
            Console.WriteLine("Left Rotation");

            Node newCritical = new Node(CriticalNode.data);
            CriticalNode.data = CriticalNode.right.data;
            newCritical.right = CriticalNode.right.left;
            CriticalNode.right = CriticalNode.right.right;
            Node leftChild = CriticalNode.left;
            newCritical.left = leftChild;
            CriticalNode.left = newCritical;
            CriticalNode.height = Max(GetHeight(CriticalNode.left), GetHeight(CriticalNode.right));

            if (CriticalNode.data == root.data)
            {
                root = CriticalNode;
            }
            //return CriticalNode; // new root
        }
        public void RightLeftRotate(Node CriticalNode)
        {
            Console.WriteLine("Right Left Rotation");

            Node newCritical = new Node(CriticalNode.data);
            Node leftOfRight = new Node(CriticalNode.right.left.data);
            CriticalNode.data = leftOfRight.data;
            CriticalNode.left = newCritical;
            CriticalNode.right.left = null;
            CriticalNode.height = Max(GetHeight(CriticalNode.left), GetHeight(CriticalNode.right));
            if (newCritical.data == root.data)
            {
                root = CriticalNode;
            }
            //PreOrderTreversal();
            //return CriticalNode;
        }
        public void LeftRightRotate(Node CriticalNode)
        {
            Console.WriteLine("Left Right Rotation");

            Node newCritical = new Node(CriticalNode.data);
            Node rightOfLeft = new Node(CriticalNode.left.right.data);
            CriticalNode.data = rightOfLeft.data;
            CriticalNode.right = newCritical;
            CriticalNode.left.right = null;
            CriticalNode.height = Max(GetHeight(CriticalNode.left), GetHeight(CriticalNode.right));
            if (newCritical.data == root.data)
            {
                root = CriticalNode;
            }
            //PreOrderTreversal();
            //return CriticalNode;
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

                //Console.WriteLine(myTree.root.data);
                myTree.PreOrderTreversal();
            }
        }
    }
}
