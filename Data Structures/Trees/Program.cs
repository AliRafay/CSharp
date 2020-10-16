using System;
using System.ComponentModel.Design.Serialization;
using System.Transactions;

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
        public void Search(int i)
        {
            if (data == i)
            {
                Console.WriteLine("Found");
            }
            else if(i < data && left != null)
            {
                left.Search(i);
            }
            else if(i > data && right != null)
            {
                right.Search(i);
            }
            else
            {
                Console.WriteLine("Not Found");
            }
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
        public void Search(int i)
        {
            if(root == null)
            {
                Console.WriteLine("Emtpy Tree");
            }
            else
            {
                root.Search(i);
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

                //myTree.InOrderTreversal();
                //myTree.PreOrderTreversal();
                //myTree.PostOrderTreversal();

                myTree.Search(10);
                myTree.Search(15);
                myTree.Search(18);
                myTree.Search(8);
                myTree.Search(13);
            }
        }
    }
}
