using System;

//https://codeforces.com/problemset/problem/1420/A

namespace CubesSorting
{
    class Program
    {
        static bool IsDecending(int[] arr, int numOfCubes)
        {
            bool isDecending = true;
            for (int i = 0; i < numOfCubes - 1; i++)
            {
                if (arr[i] <= arr[i + 1])
                {
                    isDecending = false;
                    break;
                }
                //isDecending = true;

            }
            return isDecending;
        }
        static void Main(string[] args)
        {
            int testCases = int.Parse(Console.ReadLine());
            for (int i = 0; i < testCases; i++)
            {
                int numOfCubes = int.Parse(Console.ReadLine());
                string[] tokens = Console.ReadLine().Split();
                int[] Cubes = new int[numOfCubes];
                int j = 0;
                foreach (string token in tokens)
                {
                    Cubes[j++] = int.Parse(token);
                }
                if (IsDecending(Cubes, numOfCubes))
                {
                    Console.WriteLine("NO");
                }
                else
                {
                    Console.WriteLine("YES");
                }
            }
        }
    }
}
