using System;
using System.Linq;

namespace 泛型
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(MathEx.Max(2.1, 1)); //类型自动判断
            Console.WriteLine(MathEx.Max("a", "bb"));
            Console.ReadLine();
        }

        private interface IPair<T>
        {
            T First { set; get; }
            T Second { set; get; }
        }

        public static class MathEx
        {
            public static T Max<T>(T first, params T[] values) where T : IComparable<T> //CompareTo必须为IComparable
            {
                T[] maximum = {first};
                foreach (var item in values.Where(item => item.CompareTo(maximum[0]) > 0))
                {
                    maximum[0] = item;
                }
                return maximum[0];
            }
        }

        public struct Pair<T> : IPair<T>
        {
            private T _first;

            private T _second;

            public Pair(T first)
            {
                _first = first;
                _second = default(T);
            }

            public T First
            {
                get { return _first; }
                set { _first = value; }
            }

            public T Second
            {
                get { return _second; }
                set { _second = value; }
            }
        }
    }
}