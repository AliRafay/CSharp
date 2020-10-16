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
        public Node Search(int i)
        {
            if (data == i)
            {
                Console.WriteLine("Found");
                return this;
            }
            else if (i < data && left != null)
            {
                return left.Search(i);
            }
            else if (i > data && right != null)
            {
                return right.Search(i);
            }
            else
            {
                Console.WriteLine("Not Found");
                return null;
            }
        }
        public void RemoveSearch(int i)
        {
            if (left != null)
            {
                if (left.data == i)   //finding child using parent as there is no reference from child to parent for deletion and we need to delete reference of child from parent
                {
                    Console.WriteLine("Found");
                    //Remove(left);
                    if(left.left==null && right.right == null) //for lead, no children
                    {
                        left = null;
                    }
                }
                else if (i < data)
                {
                    //Console.WriteLine("Moving left");
                    left.RemoveSearch(i);
                }
            }
            if (right != null)
            {
                if (right.data == i)
                {
                    Console.WriteLine("Found");
                    //Remove(right);
                    if (left.left == null && right.right == null)
                    {
                        right = null;
                    }

                }

                else if (i > data)
                {
                    //Console.WriteLine("Moving right");
                    right.RemoveSearch(i);
                }
            }
            else
            {
                Console.WriteLine("Element Not Found");
            }
        }
        public void Remove(Node myNode)
        {

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
            if (root == null)
            {
                Console.WriteLine("Emtpy Tree");
            }
            else
            {
                root.Search(i);
            }
        }
        //public void Remove(int i)
        //{
        //    if (root == null)
        //    {
        //        Console.WriteLine("Empty Tree");
        //    }
        //    else
        //    {
        //        root.Remove(i);
        //    }

        //}
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
                myTree.Insert(11);
                myTree.Insert(13);

                myTree.InOrderTreversal();
                //myTree.PreOrderTreversal();
                //myTree.PostOrderTreversal();

                ////myTree.Search(10);
                //myTree.Remove(20);
                //myTree.root.RemoveSearch(15);
                //myTree.InOrderTreversal();

            }
        }
    }
}
