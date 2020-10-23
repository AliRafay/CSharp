using System;
using System.Collections.Generic;

//https://codeforces.com/problemset/problem/520/A

namespace Pangram
{
    class Program
    {
        static bool CheckPangram(int length, string sentence)
        {
            char[] alphabets = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            List<char> alphabetsList = new List<char>(alphabets);
            if (sentence.Length > 25)
            {
                for (int i = 0; i < sentence.Length; i++)
                {
                    char character = sentence[i];
                    if (alphabetsList.Contains(character))
                    {
                        alphabetsList.Remove(character);
                    }
                }
                if (alphabetsList.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        static bool ReducedCostPangram(string sentence)
        {
            bool isPangram = false;
            if (sentence.Length > 25)
            {
                int[] arr = new int[26];
                for (int i = 0; i < sentence.Length; i++)
                {
                    int Ascii = sentence[i];
                    if (Ascii >= 'a')
                    {
                        arr[Ascii - 97]++;
                    }
                    else
                    {
                        arr[Ascii - 65]++;
                    }
                }

                isPangram = true;
                for (int i = 0; i < 26; i++)
                {
                    if (arr[i] == 0)
                    {
                        isPangram = false;
                        break;
                    }
                }
            }
            return isPangram;
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter Length of string: ");
            int length = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter Sentence: ");
            string sentence = Console.ReadLine();
            if (ReducedCostPangram(sentence))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");

            }
        }
    }
}
