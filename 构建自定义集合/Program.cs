using System;
using System.Collections.Generic;

namespace 构建自定义集合
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            FindAll();
            Console.Read();
        }

        public static void FindAll()
        {
            var list = new List<int> {1, 2, 3, 4};
            var results = list.FindAll(Even); //委托
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        public static bool Even(int value)
        {
            return (value%2) == 0;
        }
    }
}