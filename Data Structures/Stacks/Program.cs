using System;
using System.Collections.Generic;
using System.Collections;

namespace Stacks
{

    //class Stack
    //{
    //    private int p_index;
    //    private List<string> list = new List<string>();
    //    public Stack()
    //    {
    //        p_index = -1;
    //    }
    //    public int count
    //    {
    //        get
    //        {
    //            return list.Count;
    //        }
    //    }
    //    public void Push(string item)
    //    {
    //        list.Add(item);
    //        p_index++;
    //    }
    //    public object Pop()
    //    {
    //        string temp = list[p_index];
    //        list.RemoveAt(p_index);
    //        p_index--;
    //        return temp;
    //    }
    //    public void Clear()
    //    {
    //        list.Clear();
    //        p_index = -1;
    //    }
    //    public object Peek()
    //    {
    //        return list[p_index];
    //    }
    //}
    class Program
    {
        static void Main(string[] args)
        {
            Stack myStack = new Stack(); //C# built-in stack
            myStack.Push("HELLO");
            myStack.Push("WORLD");
            Console.WriteLine(myStack.Count); //built-in Count
            //Console.WriteLine(myStack.Count()); //my made Count()

            Console.WriteLine(myStack.Pop());
            Console.WriteLine(myStack.Peek());
            myStack.Clear();
            Console.WriteLine(myStack.Count); //built-in Count
            //Console.WriteLine(myStack.Count()); //my made Count()

        }
    }
}
