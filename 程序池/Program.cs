using System;
using System.Collections.Generic;
using System.Threading;

namespace 程序池
{
    internal class Program
    {
        private static readonly WaitHandle[] WaitHandles =
        {
            new AutoResetEvent(false),
            new AutoResetEvent(false)
        };
        private static readonly AutoResetEvent AutoReset = new AutoResetEvent(false);

        public static List<int> Listint = new List<int> { 1, 2, 3, 4, 5, 6 };

        private static void Main()
        {
            Console.WriteLine("主线程开始");
            for (var i = 0; i < 2; i++)
            {
                ThreadPool.QueueUserWorkItem(DoTask, WaitHandles[0]);
                ThreadPool.QueueUserWorkItem(DoTask, WaitHandles[1]);
            }
            WaitHandle.WaitAll(WaitHandles);
            Console.WriteLine("线程完成");

            Console.ReadLine();
        }

        private static readonly Object ThisLock = new object();
        static Random r = new Random();

        private static void DoTask(Object state)
        {
            var are = (AutoResetEvent)state;
            var time = 100 * r.Next(2, 100);
            Console.WriteLine("Performing a task for {0} milliseconds.", time);
            //Thread.Sleep(time);
            lock (ThisLock)
            {
                while (Listint.Count > 0)
                {
                    Console.WriteLine(Listint[0]);
                    Listint.RemoveAt(0);
                }
            }
            are.Set();
        }
    }
}
