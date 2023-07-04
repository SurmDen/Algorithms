using System;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 2, 5, 3, 77, 8, 3, 99, 0, 3, 32, 45, 21, 7 };

            Console.WriteLine("Array before sort");

            foreach (int n in array)
            {
                Console.Write(n + "  ");
            }

            MergeSort(array);

            Console.WriteLine("Array after sort");

            foreach (int n  in array)
            {
                Console.Write(n+"  ");
            }

        }

        static void Merge(int[] targetArray, int[] array1, int[] array2 )
        {
            int array1MinIndex = 0;
            int array2MinIndex = 0;

            int targetArrayMinIndex = 0;

            while (array1MinIndex < array1.Length && array2MinIndex < array2.Length)
            {
                if (array1[array1MinIndex] <= array2[array2MinIndex])
                {
                    targetArray[targetArrayMinIndex] = array1[array1MinIndex];
                    array1MinIndex++;
                }
                else
                {
                    targetArray[targetArrayMinIndex] = array2[array2MinIndex];
                    array2MinIndex++;
                }
                targetArrayMinIndex++;
            }
            while (array1MinIndex < array1.Length)
            {
                targetArray[targetArrayMinIndex] = array1[array1MinIndex];
                array1MinIndex++;
                targetArrayMinIndex++;
            }
            while (array2MinIndex < array2.Length)
            {
                targetArray[targetArrayMinIndex] = array2[array2MinIndex];
                array2MinIndex++;
                targetArrayMinIndex++;
            }
        }

        static void MergeSort(int[] array)
        {
            if (array.Length <= 1)
            {
                return;
            }

            int mid = array.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[array.Length-mid];

            for (int i = 0; i < mid; i++)
            {
                left[i] = array[i];
            }

            for (int i = mid; i < array.Length; i++)
            {
                right[i-mid] = array[i];
            }

            MergeSort(left);
            MergeSort(right);

            Merge(array , left, right);
        }
    }
}
