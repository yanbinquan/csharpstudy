using System;
using System.Linq;

namespace _2的N次方组合
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var all = new[] {1, 2, 4, 8};
            const int t1 = 7;
            Console.WriteLine(t1);
            foreach (var t in all.Where(t => (t1 & t) != 0))
            {
                Console.WriteLine(t);
            }
            Console.ReadLine();
        }
    }
}