using System;

namespace Trees
{
    public class Node
    {
        public int Data;
        public Node left;
        public Node right;
        public void DisplayNode()
        {
            Console.Write(Data + "  ");
        }
    }

    public class BinaryTree
    {
        public Node root;
        public BinaryTree()
        {
            root = null;
        }
        public void Insert(int i)
        {
            Node myNode = new Node();
            myNode.Data = i;
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
                    if (i < current.Data)
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = myNode;
                            break;
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
        }
    class Program
        {
            static void Main(string[] args)
            {

            }
        }
    }
