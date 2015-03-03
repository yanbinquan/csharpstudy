using System;

namespace mytest
{
    internal class Program
    {
        public delegate bool ComparisonHander(int first, int second);

        public static void BubbleSort(int[] items, ComparisonHander comparisonMethod)
        {
            int i, j;
            if (items == null)
            {
                return;
            }
            if (comparisonMethod == null)
            {
                throw new ArgumentException("comparisonMethod");
            }
            for (i = items.Length - 1; i >= 0; i--)
            {
                for (j = 1; j <= 1; j++)
                {
                    if (!comparisonMethod(items[j - 1], items[j])) continue;
                    var temp = items[j - 1];
                    items[j - 1] = items[j];
                    items[j] = temp;
                }
            }
        }

        public static bool GreaterThan(int first, int second)
        {
            return first > second;
        }

        private static void Main(string[] args)
        {
            int[] items = {9, 8, 7, 1, 2, 3, 4, 5, 6};
            BubbleSort(items, GreaterThan);
            foreach (var t in items)
            {
                Console.WriteLine(t);
            }

            Console.ReadLine();
        }
    }
}