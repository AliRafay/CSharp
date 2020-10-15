using System;
//using System.Collections.Generic;
using System.Collections;

namespace Queues
{
    //public class Queue
    //{
    //    private List<int> pqueue = new List<int>();
    //    public void EnQueue(int item)
    //    {
    //        pqueue.Add(item);
    //    }
    //    public void DeQueue()
    //    {
    //        pqueue.RemoveAt(0);
    //    }
    //    public object Peek()
    //    {
    //        return pqueue[0];
    //    }
    //    public void ClearQueue()
    //    {
    //        pqueue.Clear();
    //    }
    //    public int Count()
    //    {
    //        return pqueue.Count;
    //    }
    //}
    class Program
    {
        static void Main(string[] args)
        {
            Queue myQueue = new Queue();
            //myQueue.EnQueue(7);
            //myQueue.EnQueue(2);
            //myQueue.EnQueue(13);
            myQueue.Enqueue(7);
            myQueue.Enqueue(2);
            myQueue.Enqueue(13);
            Console.WriteLine("Count: "+myQueue.Count);
            //Console.WriteLine("Count: " + myQueue.Count());

            Console.WriteLine("Peek: "+myQueue.Peek());
            //myQueue.DeQueue();
            //myQueue.DeQueue();
            myQueue.Dequeue();
            myQueue.Dequeue();

            Console.WriteLine("Peek: "+myQueue.Peek());
            Console.WriteLine("Count: "+myQueue.Count);
            //myQueue.ClearQueue();
            myQueue.Clear();
            Console.WriteLine("Count: "+myQueue.Count);

        }
    }
}
