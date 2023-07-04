using System;

namespace Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            AlgorithmHandler handler = new AlgorithmHandler();

            handler.CreatePermutation(new int[5]);

            handler.ShowPermutations();

            //ShowPermutations(new int[5]);

            Console.ReadLine();
        }

        static void ShowPermutations(int[] array, int position = 0)
        {
            if (array.Length == position)
            {
                foreach (var item in array)
                {
                    Console.Write(item);
                }

                Console.WriteLine();

                return;
            }

            for (int i = 0; i < array.Length; i++)
            {
                bool found = false;

                for (int j = 0; j < position; j++)
                {
                    if (array[j] == i)
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    continue;
                }

                array[position] = i;
                ShowPermutations(array, position+1);
            }
        }
    }
}
