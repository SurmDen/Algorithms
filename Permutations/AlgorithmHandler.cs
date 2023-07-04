using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permutations
{
    public class AlgorithmHandler
    {
        public AlgorithmHandler()
        {
            sets = new List<int[]>();
        }

        public void CreatePermutation(int[] arr, int position = 0)
        {

            if (position == arr.Length)
            {
                int[] copyArr = new int[arr.Length];

                for (int i = 0; i < arr.Length; i++)
                {
                    copyArr[i] = arr[i];
                }

                sets.Add(copyArr);

                return;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                bool found = false;

                for (int j = 0; j < position; j++)
                {
                    if (arr[j] == i)
                    {
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    continue;
                }
                arr[position] = i;
                CreatePermutation(arr, position +1);
            }
        }

        public List<int[]> sets { get; set; }

        public void ShowPermutations()
        {
            foreach (int[] subArrs in sets)
            {
                foreach (int num in subArrs)
                {
                    Console.Write(num + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
