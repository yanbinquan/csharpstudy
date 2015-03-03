using System;

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
                T maximum = first;
                foreach (T item in values)
                {
                    if (item.CompareTo(maximum) > 0)
                    {
                        maximum = item;
                    }
                }
                return maximum;
            }
        }

        public struct Pair<T> : IPair<T>
        {
            private T _First;

            private T _Second;

            public Pair(T first)
            {
                _First = first;
                _Second = default(T);
            }

            public T First
            {
                get { return _First; }
                set { _First = value; }
            }

            public T Second
            {
                get { return _Second; }
                set { _Second = value; }
            }
        }
    }
}