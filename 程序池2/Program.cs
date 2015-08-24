using System;
using System.Threading;

namespace 程序池2
{
    internal class Program
    {
        private readonly int _n;
        private readonly ManualResetEvent _doneEvent;

        public int N
        {
            get { return _n; }
        }

        public int FibOfN { get; private set; }

        // Constructor.
        public Program(int n, ManualResetEvent doneEvent)
        {
            _n = n;
            _doneEvent = doneEvent;
        }

        // Wrapper method for use with thread pool.
        public void ThreadPoolCallback(Object threadContext)
        {
            var threadIndex = (int) threadContext;
            Console.WriteLine("线程 {0} 开始...", threadIndex);
            FibOfN = Calculate(_n);
            Console.WriteLine("线程 {0} 计算...", threadIndex);
            _doneEvent.Set();
        }

        // Recursive method that calculates the Nth Fibonacci number.
        public int Calculate(int n)
        {
            if (n <= 1) return n;
            return Calculate(n - 1) + Calculate(n - 2);
        }

        private static void Main(string[] args)
        {
            const int fibonacciCalculations = 10;

            var doneEvents = new ManualResetEvent[fibonacciCalculations];
            var fibArray = new Program[fibonacciCalculations];
            var r = new Random();

            Console.WriteLine("开始 {0} 任务...", fibonacciCalculations);
            for (var i = 0; i < fibonacciCalculations; i++)
            {
                doneEvents[i] = new ManualResetEvent(false);
                var f = new Program(r.Next(20, 40), doneEvents[i]);
                fibArray[i] = f;
                ThreadPool.QueueUserWorkItem(f.ThreadPoolCallback, i);
            }

            // Wait for all threads in pool to calculate.
            WaitHandle.WaitAll(doneEvents);
            Console.WriteLine("计算完成.");

            // Display the results.
            for (var i = 0; i < fibonacciCalculations; i++)
            {
                var f = fibArray[i];
                Console.WriteLine("Fibonacci({0}) = {1}", f.N, f.FibOfN);
            }

            Console.ReadLine();
        }
    }
}