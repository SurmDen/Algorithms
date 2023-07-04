using System;
using System.Collections.Generic;
using System.Text;

// IT IS MY OWN VERSION OF BINARY TREE DATA STRUCTURE
//            SWALLOW MY CUM STUPID LOOSERS
//           I AM THE GOD OF THE PROGRAMMING

namespace BinaryTree
{
    public class Node<T>
    {
        public Node<T> Parent { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public T Data;

        public Node(T data)
        {
            Data = data;
        }
    }

    public class BinaryTree<T> where T : IComparable
    {
        private Node<T> rootNode;

        private void AddNode(T data, Node<T> node)
        {
            if (node.Data.CompareTo(data) < 0)
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(data);
                    node.Right.Parent = node;
                }
                else
                {
                    AddNode(data, node.Right);
                }
            }
            else
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(data);
                    node.Left.Parent = node;
                }
                else
                {
                    AddNode(data, node.Left);
                }
            }
        }

        public void AddNode(T data)
        {
            if (rootNode == null)
            {
                rootNode = new Node<T>(data);
            }
            else
            {
                AddNode(data, this.rootNode);
            }
        }

        private Node<T> GetNode(T data, Node<T> currentNode)
        {
            switch (data.CompareTo(currentNode.Data))
            {
                case 1: return GetNode(data, currentNode.Right);
                case -1: return GetNode(data, currentNode.Left);
                case 0:
                    return currentNode;
                default: return null;

            }
        }

        public Node<T> GetNode(T data)
        {
            return GetNode(data, this.rootNode) ?? null;
        }

        StringBuilder sb = new StringBuilder();

        private void CreatePictureTree(Node<T> node)
        {
            if (node.Left != null && node.Right !=null)
            {
                sb.AppendLine($"    {node.Left.Data}    {node.Right.Data}    ");
                CreatePictureTree(node.Left);
                CreatePictureTree(node.Right);
            }
            else if(node.Left != null && node.Right == null)
            {
                sb.AppendLine($"    {node.Left.Data}  ");
                CreatePictureTree(node.Left);
            }
            else if (node.Left == null && node.Right != null)
            {
                sb.AppendLine($"  {node.Right.Data}    ");
                CreatePictureTree(node.Right);
            }
            else
            {
                return;
            }
        }

        public void CreatePicture()
        {
            sb.Length = 0;
            sb.AppendLine($"    {rootNode.Data}    ");
            CreatePictureTree(rootNode);
        }

        public void ShowPicture()
        {
            Console.WriteLine(sb.ToString());
        }

        public bool DeleteNode(T data)
        {
            Node<T> neededNode = GetNode(data);

            if (neededNode != null)
            {
                //removing a lief
                if (neededNode.Left == null && neededNode.Right == null)
                {
                    if (neededNode.Parent != null)
                    {
                        if (neededNode.Parent.Left.Equals(neededNode))
                        {
                            neededNode.Parent.Left = null;
                        }
                        else
                        {
                            neededNode.Parent.Right = null;
                        }

                        neededNode.Parent = null;
                    }
                    else
                    {
                        rootNode = null;
                    }
                }

                //removing a node, that has left node, but hasn't right node
                if (neededNode.Left != null && neededNode.Right == null)
                {
                    if (neededNode.Parent != null)
                    {
                        neededNode.Parent.Left = neededNode.Left;
                        neededNode.Left.Parent = neededNode.Parent;
                    }
                    else
                    {
                        rootNode = neededNode.Left;
                    }
                }

                //removing a node, that has right node, but hasn't left node
                if (neededNode.Left == null && neededNode.Right != null)
                {
                    if (neededNode.Parent != null)
                    {
                        neededNode.Parent.Right = neededNode.Right;
                        neededNode.Right.Parent = neededNode.Parent;
                    }
                    else
                    {
                        rootNode = neededNode.Right;
                    }
                }

                //node has both left and right children
                if (neededNode.Left != null && neededNode.Right != null)
                {
                    if (neededNode.Right.Left == null)
                    {
                        neededNode.Right.Left = neededNode.Left;
                    }
                    else
                    {
                        Node<T> smallestChildOfRightNode = neededNode.Right.Left;

                        while (smallestChildOfRightNode.Left != null)
                        {
                            smallestChildOfRightNode = smallestChildOfRightNode.Left;
                        }

                        smallestChildOfRightNode.Left = neededNode.Left;
                        neededNode.Left.Parent = smallestChildOfRightNode;
                    }

                    if (neededNode.Parent != null)
                    {
                        neededNode.Right.Parent = neededNode.Parent;
                        if (neededNode.Parent.Left == neededNode)
                        {
                            neededNode.Parent.Left = neededNode.Right;
                        }
                        else if (neededNode.Parent.Right == neededNode)
                        {
                            neededNode.Parent.Right = neededNode.Right;
                        }
                    }
                    else
                    {
                        rootNode = neededNode.Right;
                    }
                }

                return true;
            }

            return false;
        }
    }

    class Program
    {
        static void Main()
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            int[] arr = { 7, 3, 8, 2, 6, 0, 6, 2, 5, 9, 0, 4, 2, 4, 7, 9, 5, 32, 5, 785 };

            for (int i = 0; i < arr.Length; i++)
            {
                tree.AddNode(arr[i]);
            }

            try
            {
                Node<int> node = tree.GetNode(785);
                Console.WriteLine("node founded");
            }
            catch (ArgumentNullException err)
            {
                Console.WriteLine(err.Message);
            }

            tree.CreatePicture();
            tree.ShowPicture();

            bool isDeleted = false;

            try
            {
                isDeleted = tree.DeleteNode(32);
                Console.WriteLine("Deleted!!!!!!!!!");
                tree.CreatePicture();
                tree.ShowPicture();
            }
            catch
            {
                Console.WriteLine("Incorrect programm");
            }

            Console.ReadLine();
        }
    }
}
