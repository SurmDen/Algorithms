using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podmnojestva
{
    class Program
    {
        static void Main(string[] args)
        {
            //MakeSubSets(new bool[3], 0);

            int[] nums = new int[] {1,2 ,3,4,5,6};

            //MyBruteforceFunc(nums);

            GuessThePass(new char[] {'s','u','r','m','a','n' });

            Console.ReadLine();
        }

        static void MakeSubSets(bool[] subset, int position)
        {
            if (position == subset.Length)
            {
                foreach (var e in subset)
                {
                    Console.Write(e ? 1 : 0);
                    
                }
                Console.WriteLine();
                return;
            }

            subset[position] = false;
            MakeSubSets(subset, position + 1);
            subset[position] = true;
            MakeSubSets(subset, position + 1);
        }

        static void MyBruteforceFunc(int[] nums, int position = 0)
        {
            if (position == nums.Length)
            {
                foreach (var num in nums)
                {
                    Console.Write(num);
                }
                Console.WriteLine();
                return;
            }


            nums[position] = 1;
            MyBruteforceFunc(nums, position + 1);

            nums[position] = 2;
            MyBruteforceFunc(nums, position + 1);

            nums[position] = 3;
            MyBruteforceFunc(nums, position + 1);

            nums[position] = 4;
            MyBruteforceFunc(nums, position + 1);

            nums[position] = 5;
            MyBruteforceFunc(nums, position + 1);

            nums[position] = 6;
            MyBruteforceFunc(nums, position + 1);


        }

        static void GuessThePass(char[] arr,int position = 0 )
        {
            if (position == arr.Length)
            {
                foreach (var item in arr)
                {
                    Console.Write(item);
                }

                Console.WriteLine();

                return;
            }

            arr[position] = char.ToLower(arr[position]);
            GuessThePass(arr, position + 1);
            arr[position] = char.ToUpper(arr[position]);
            GuessThePass(arr, position + 1);
        }
    }
}
