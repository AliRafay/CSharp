using System;

namespace Trees
{
    public class Node
    {
        public int data;
        public Node left;
        public Node right;
        public void DisplayNode()
        {
            Console.Write(data + "  ");
        }
        public void InOrderTreversal(Node Current)
        {
            if (Current != null)
            {
                InOrderTreversal(Current.left);
                Current.DisplayNode();
                InOrderTreversal(Current.right);
            }
        }
        public void PostOrderTreversal(Node Current)
        {
            if (Current != null)
            {
                PostOrderTreversal(Current.left);
                PostOrderTreversal(Current.right);
                Current.DisplayNode();
            }
        }
        public void PreOrderTreversal(Node Current)
        {
            if (Current != null)
            {
                Current.DisplayNode();
                PreOrderTreversal(Current.left);
                PreOrderTreversal(Current.right);
            }
        }
    }

    public class BinarySearchTree
    {
        public Node root;
        public BinarySearchTree()
        {
            root = null;
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
        public void InOrderTreversal()
        {
            if (root == null)
            {
                Console.WriteLine("The Tree is Empty");
            }
            else
            {
                Console.WriteLine("InOrder Treversal");
                root.InOrderTreversal(root);
                Console.WriteLine("\n");
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
                root.PreOrderTreversal(root);
                Console.WriteLine("\n");

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
                root.PostOrderTreversal(root);
                Console.WriteLine("\n");

            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                BinarySearchTree myTree = new BinarySearchTree();
                myTree.Insert(10);
                myTree.Insert(15);
                myTree.Insert(18);
                myTree.Insert(8);
                myTree.Insert(20);
                myTree.Insert(12);

                myTree.InOrderTreversal();
                myTree.PreOrderTreversal();
                myTree.PostOrderTreversal();
            }
        }
    }
}
