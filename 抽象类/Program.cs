using System;

namespace 抽象类
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var il1 = new IncandescentLamp();
            il1.TurnOn();
            Console.ReadLine();
        }
    }
}