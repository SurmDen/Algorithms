using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Deque
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }

        public T Data { get; }

        public Node<T> Previous { get; set; }

        public Node<T> Next { get; set; }
    }

    public class MyDeque<T> : IEnumerable<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;

        public void PushToStart(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null && tail ==null)
            {
                head = node;
                tail = node;
            }
            else
            {
                node.Next = head;
                head.Previous = node;
                head = node;
            }

            count++;

        }

        public T PopFromStart()
        {
            if (head != null)
            {
                T data = head.Data;

                if (head.Next == null)
                {

                    head = null;
                    tail = null;

                }
                else
                {
                    head.Next.Previous = null;
                    head = head.Next;

                    
                }

                count--;
                return data;
                
            }

            throw new Exception("Deque is empty!");
        }

        public void PushToEnd(T data)
        {
            Node<T> node = new Node<T>(data);

            if (tail == null && head == null)
            {
                tail = head = node;
            }
            else
            {
                node.Previous = tail;
                tail.Next = node;
                tail = node;
            }

            count++;

        }

        public T PopFromEnd()
        {
            if (tail != null)
            {
                T data = tail.Data;

                if (tail.Previous == null)
                {
                    tail = head = null;
                }
                else
                {
                    tail.Previous.Next = null;
                    tail = tail.Previous;

                    
                }
                count--;
                return data;
            }

            throw new Exception("Deque is empty!");
        }

        public int Count 
        { 
            get 
            {
                return count;
            }

        }

        public bool IsExists(T data)
        {
            Node<T> current = head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current!=null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            MyDeque<int> deque = new MyDeque<int>();

            for (int i = 1; i <= 100; i++)
            {
                if (i % 2 == 0)
                {
                    deque.PushToEnd(i);
                }
                else
                {
                    deque.PushToStart(i);
                }
            }

            Console.WriteLine("After pushing: ");

            foreach (int n in deque)
            {
                Console.Write($"{n} ");
            }

            for (int i = 0; i < deque.Count / 2 - 2; i++)
            {
                deque.PopFromStart();
                deque.PopFromEnd();
            }

            Console.WriteLine();
            Console.WriteLine("After popping: ");

            foreach (int n in deque)
            {
                Console.Write($"{n} ");
            }

            Console.ReadLine();
        }
    }
}
