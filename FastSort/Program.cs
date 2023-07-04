using System;

namespace FastSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 2, 4, 1, 8, 5, 6, 9, 3, 7, 11, 10, 521, 379, 2, 849, 91, 73920, 132, 637, 23, 527 };

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

        static void Sort(int[] targetArr, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return;
            }

            int counter = minIndex;

            for (int i = minIndex; i < maxIndex; i++)
            {
                if (targetArr[i] < targetArr[maxIndex])
                {
                    int temp = targetArr[i];
                    targetArr[i] = targetArr[counter];
                    targetArr[counter] = temp;
                    counter++;
                }
            }

            int secondTemp = targetArr[counter];
            targetArr[counter] = targetArr[maxIndex];
            targetArr[maxIndex] = secondTemp;

            Sort(targetArr, minIndex, counter-1);
            Sort(targetArr, counter + 1, maxIndex);
        }

        static void Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length-1);
        }

        //repeating
        static void FastSort(int[] arr, int min, int max)
        {
            if (min >= max)
            {
                return;
            }

            int counter = min;

            for (int i = min; i < max; i++)
            {
                if (arr[i] <= max)
                {
                    int temp = arr[counter];
                    arr[counter] = arr[i];
                    arr[i] = temp;
                    counter++;
                }
            }

            int sectemp = arr[counter];
            arr[counter] = arr[max];
            arr[max] = sectemp;

            FastSort(arr, min, counter - 1);
            FastSort(arr, counter + 1, max);
        }
    }
}
