using System;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Make(4);

            Console.WriteLine();

            Console.WriteLine(Make(2, 2)); ;

            Console.ReadLine();
        }

        static void Make(int n)
        {
            for (int i = n-1; i >= 0; i--)
            {
                Console.Write(i);

                Make(i);
            }
        }

        static int Make(int x, int y)
        {
            if (x == 0 || y == 0)
            {
                return 1;
            }

            return Make(x - 1, y) + Make(x, y-1);
        }
    }
}
