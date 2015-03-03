using System;

namespace Lamda
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Func<int, bool> myFunc = p => p == 5;
            var result = myFunc(4);
            Console.WriteLine(result);
            Console.Read();
        }
    }
}