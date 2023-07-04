using System;

namespace Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            MakeCombinations(new bool[10], 3);

            Console.ReadLine();
        }

        static void MakeCombinations(bool[] combinations, int sets, int position = 0)
        {
            if (sets == 0)
            {
                for (int i = position; i < combinations.Length; i++)
                {
                    combinations[i] = false;
                }
                foreach (bool n in combinations)
                {
                    Console.Write(n ? 1 : 0);
                }

                Console.WriteLine();
                return;
            }

            if (position == combinations.Length)
            {
                return;
            }

            combinations[position] = false;
            MakeCombinations(combinations, sets, position + 1);
            combinations[position] = true;
            MakeCombinations(combinations, sets - 1, position + 1);
        }
    }
}
