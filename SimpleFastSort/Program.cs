using System;

namespace SimpleFastSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 2, 4, 1, 8, 5, 6, 9, 3, 7, 11, 10 };

            Console.Write("Unsorted data:  ");

            foreach (int n in arr)
            {
                Console.Write(n + " ");
            }

            Sort(arr);

            Console.WriteLine();

            Console.Write("Sorted data:  ");

            foreach (int n in arr)
            {
                Console.Write(n + " ");
            }

            Console.ReadLine();
        }


        static void Sort(int[] arr)
        {
            for (int i = arr.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] > arr[i])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }
}
