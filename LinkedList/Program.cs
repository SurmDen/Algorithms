using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public class Node<T>
    {
        public T Data;

        public Node(T data)
        {
            Data = data;
        }

        public Node<T> Next { get; set; }

    }

    public class LinkedList<T> : IEnumerable<T>
    {
        Node<T> tail;
        Node<T> head;
        private static int count = 0;

        public void AddElement(T data)
        {
            Node<T> addition = new Node<T>(data);

            if (head == null)
            {
                head = addition;
            }
            else
            {
                tail.Next = addition;
            }

            tail = addition;

            count++;
        }

        public void RemoveElement(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            bool IsDeleted = false;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    
                    if (previous!=null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                        {
                            tail = previous;
                        }
                    }
                    else
                    {
                        head = head.Next;

                        if (head.Next == null)
                        {
                            tail = null;
                        }
                    }

                    IsDeleted = true;
                    count--;
                    break;
                }
                else
                {
                    previous = current;
                    current = current.Next;
                }
            }

            if (IsDeleted)
            {
                Console.WriteLine("Element successfully removed!");
            }
            else
            {
                Console.WriteLine("Warn: element is not founded!");
            }
        }

        public bool Contains(T data)
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

        public int Count { get => count; }

        public bool IsEmpty { get => count == 0; }

        public void Clear()
        {
            count = 0;
            head = null;
            tail = null;
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
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> nums = new LinkedList<int>();

            for (int i = 0; i < 100; i++)
            {
                nums.AddElement(i);
            }

            Console.WriteLine($"count: {nums.Count}");
            Console.WriteLine($"contains element 9: {nums.Contains(9)}");
            nums.RemoveElement(25);
            Console.WriteLine($"count: {nums.Count}");

            Console.Write("All elements: ");
            foreach (var item in nums)
            {
                Console.Write(item+" ");
            }

            Console.ReadLine();
        }
    }
}
