using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class Node<T>
    {
        public T Data { get; set; }

        public Node(T data)
        {
            Data = data;
        }

        //in stack next means 'previous'
        public Node<T> Previous { get; set; }
    }

    public class SimpleStack<T> : IEnumerable<T>
    {
        private static int count;

        private Node<T> tail;

        //add new element to the top of the stack
        public void Push(T data)
        {
            Node<T> node = new Node<T>(data);

            node.Previous = tail;

            tail = node;

            count++;
        }

        //get top element and kill it
        public T Pop()
        {
            if (tail == null)
            {
                throw new Exception("stack is empty ");
            }

            Node<T> temp = tail;

            tail = tail.Previous;

            count--;

            return temp.Data;
        }

        //only get value from top element
        public T Peek()
        {
            if (tail == null)
            {
                throw new Exception("stack is empty");
            }

            return tail.Data;
        }

        public int Count { 
            get 
            {
                return count;
            }
            
        }

        public bool IsEmpty
        {
            get
            {
                return tail == null;
            }
        }

        private bool IsExists(T value, Node<T> current)
        {
            while(current != null)
            {
                if (current.Equals(value))
                {
                    return true;

                }
                else
                {
                    current = current.Previous;
                }
            }

            return false;
        }

        public bool IsExists(T value)
        {
            return IsExists(value, tail);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            while (tail != null)
            {
                yield return tail.Data;

                tail = tail.Previous;
            }
        }
    } 

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            SimpleStack<int> stack = new SimpleStack<int>();

            for (int i = 0; i < 100; i++)
            {
                stack.Push(random.Next(1, 100));
            }

            Console.WriteLine($"is 25 exists: {stack.IsExists(25)}");

            Console.WriteLine("All elements");

            foreach (int n in stack)
            {
                Console.Write($"{n} ");
            }

            Console.ReadLine();
        }
    }
}
