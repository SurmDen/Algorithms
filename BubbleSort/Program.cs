using System;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] {2,4,1,8,5,6,9,3,7,11,10 };

            Sort(arr);

            foreach (int n in arr)
            {
                Console.Write(n + " ");
            }

            int[] arr2 = new int[] { 2, 4, 1, 8, 5, 6, 9, 3, 7, 11, 10 };

            BubbleSortRange(arr2, 2, 7);

            Console.WriteLine();

            foreach (int n in arr2)
            {
                Console.Write(n + " ");
            }

            Console.ReadLine();
        }

        static void Sort(int[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (array[j-1] > array[j])
                    {
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        public static void BubbleSortRange(int[] array, int left, int right)
        {
            for (int i = right + 1; i > left; i--)
            {
                for (int j = left + 1; j <= i; j++)
                {
                    if (array[j - 1] > array[j])
                    {
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
    }
}
