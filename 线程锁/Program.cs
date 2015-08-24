using System;
using System.Collections.Generic;
using System.Threading;

namespace 线程锁
{
    internal class Program
    {
        private static readonly AutoResetEvent AutoReset = new AutoResetEvent(false);
        private static int _countNum; //计数器
        private static readonly object Lockobj = new object(); //静态锁对象

        private static void Main(string[] args)
        {
            // test AutoResetEvent and Lock object or static object begin
            var thread1 = new Thread(Wirte1);
            thread1.Start(1);
            var thread2 = new Thread(Wirte1);
            thread2.Start(2);
            //--- test end---

            // test Monitor begin 
            //Thread thread3 = new Thread(wirte2);
            //thread3.Start(3);
            //Thread thread5 = new Thread(wirte2);
            //thread5.Start(5);
            // -- end ---

            //var thread4 = new Thread(Wirte4);
            // thread4.Start();

            AutoReset.WaitOne();
            Console.WriteLine("结束");
            Console.ReadLine();
        }

        public static List<int> Listint = new List<int> {1, 2, 3, 4, 5, 6, 7, 8};
        private static int selectindex = 0;
        private static Random rn = new Random();

        public static void Wirte1(object index)
        {
            //AutoReset.WaitOne();                //阻塞，直到收到信号
            //lock (new object())       //这样锁可以一次只能一个线程进入锁定的代码块，但一次过后可以其它的线程的抢到
            while (selectindex < Listint.Count)
            {
                int tt;
                lock (Lockobj) //锁定后只有一个线程进入直至块内代码执行完
                {
                    if (selectindex >= Listint.Count) continue;
                    tt = Listint[selectindex];
                    selectindex++;
                }
                Console.WriteLine("线程{0}:{1}", index, tt);
                Thread.Sleep(rn.Next(1, 9999));
            }
            AutoReset.Set();
        }

        public static void Wirte2(object index)
        {
            var isrealse = false;
            lock (Lockobj)
            {
                Console.WriteLine(index + " enter lock after");
                while (_countNum < 10)
                {
                    if (isrealse)
                    {
                        Monitor.Wait(Lockobj); //阻塞当前线程
                    }
                    Console.WriteLine(_countNum + " index:" + index);
                    Thread.Sleep(500);
                    //autoReset.Reset();
                    _countNum++;
                    if (_countNum > 5)
                    {
                        Monitor.PulseAll(Lockobj); //取消阻塞，并且当前lock无效
                    }
                    if (_countNum > 7)
                    {
                        isrealse = true;
                    }
                }
            }
        }

        public static void Wirte3()
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(i + " thread3");
                Thread.Sleep(500);
            }
        }

        public static void Wirte4()
        {
            lock (Lockobj)
            {
                for (var i = 0; i < 10; i++)
                {
                    Console.WriteLine(i + " thread4");
                    Thread.Sleep(500);
                    if (i > 5)
                    {
                        AutoReset.Set(); //置信号为true，阻塞的线程可以运行
                    }
                }
            }
        }
    }
}