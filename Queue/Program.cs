using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public Node<T> Next { get; set; }

    }

    public class MyQueue<T> : IEnumerable<T>
    {
        private Node<T> head;
        private Node<T> tail;

        private int count;

        public void Push(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
            }

            tail = node;

            count++;

        }

        public T Pop()
        {
            if (head != null)
            {
                T data = head.Data;

                if (head.Next != null)
                {
                    head = head.Next;

                    
                }
                else
                {
                    head = tail = null;
                }

                count--;

                return data;

                
            }

            throw new Exception("Queue is empty!");
        }

        public int Count()
        {
            return count;
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

            while (current!= null)
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
            MyQueue<int> queue = new MyQueue<int>();

            for (int i = 1; i <= 100; i++)
            {
                queue.Push(i);
            }

            Console.Write("after pushing: ");

            foreach (int n in queue)
            {
                Console.Write($"{n} ");
            }

            Console.WriteLine();
            Console.Write("Poping 10 items: ");

            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{queue.Pop() }  ");
            }

            Console.WriteLine();
            Console.Write("after poping: ");

            foreach (int n in queue)
            {
                Console.Write($"{n} ");
            }

            Console.ReadLine();
        }
    }
}
