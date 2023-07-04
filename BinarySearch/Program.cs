using System;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {

            int result = Find(new int[] {1,2,4,4,6,7,8,8,8,9,10 }, 8);

            Console.WriteLine(result);

            long[] arr = new long[] { 1, 2, 4, 4, 6, 7, 8, 8, 8, 9, 10 };

            int secondResult = BinSearchLeftBorder(arr, 8, -1 ,arr.Length);

            Console.WriteLine(secondResult);

            Console.ReadLine();
        }

        static int Find(int[] arr, int query)
        {
            int left = 0;
            int right = arr.Length -1;

            while (left < right)
            {
                int middle = (left + right) / 2;

                if (query <= arr[middle])
                {
                    right = middle;
                }
                else
                {
                    left = middle + 1;
                }
            }

            if (query == arr[right])
            {
                return right;
            }

            return -1;
        }


        public static int BinSearchLeftBorder(long[] array, long value, int left, int right)
        {
            if (right == array.Length)
            {
                right -= 1;
                
            }

            if (value == array[right])
            {
                return left;
            }

            int middle = (left + right) / 2;

            if (array[middle] < value)
            {
                return BinSearchLeftBorder(array, value, middle + 1, right);
            }
            else
            {
                return BinSearchLeftBorder(array, value, left, middle);
            }
        }
    }
}
