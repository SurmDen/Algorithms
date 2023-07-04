using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Deikstra_Algoritm
{
    public class Node
    {
        public Node()
        {
            counter++;
            Id = counter;
            Neibours = new List<Neibour>();
        }

        private static int counter;

        public int Id { get; set; }

        public List<Neibour> Neibours { get; set; }

        public int tempWayCost;

        public bool isChecked = false;
    }

    public class Neibour
    {
        public Neibour(Node neib, int w)
        {
            Neib = neib;
            Weight = w;
        }

        public int Weight { get; set; }

        public Node Neib { get; set; }
    }

    public class Graph
    {
        public Graph(Node head)
        {
            AllNodes = new List<Node>();
            Head = head;
        }

        private Node Head;

        private List<Node> AllNodes;

        public void ChangeHeadNode(Node newNode)
        {
            Head = newNode;
        }

        public Node CreateNode()
        {
            Node node = new Node();

            AllNodes.Add(node);

            return node;
        }

        public void LinkNodes(Node first, Node second, int weigth)
        {
            if (AllNodes.Contains(first) && AllNodes.Contains(second))
            {
                if (!first.Neibours.Select(n=>n.Neib).Contains(second) && !second.Neibours.Select(n => n.Neib).Contains(first))
                {
                    first.Neibours.Add(new Neibour(second, weigth));
                    second.Neibours.Add(new Neibour(first, weigth));
                }

                throw new Exception("One of this nodes has already contained another one, please delete it!");
            }

            throw new Exception("Nodes are note added to NodeList of this graph");
        }

        public void BuildShortestWay(Node current, Node target)
        {
            //Node next = current.Neibours.Select(n => n.Neib).Where(n=>!n.isChecked).
            //    First(n => n.tempWayCost == n.Neibours.Min(n => n.Neib.tempWayCost));

            
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
