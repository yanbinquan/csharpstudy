using System;

namespace 单例
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SingleClass.GetSingleClass();
            SingleClass.GetSingleClass(); //已经实例化过一次了不会再实例化了    
            Console.ReadLine();
        }
    }

    public class SingleClass
    {
        private static SingleClass _uniqueInstance = new SingleClass();

        private SingleClass()
        {
            Console.WriteLine("singleClass run");
        }

        public static SingleClass GetSingleClass()
        {
            return _uniqueInstance ?? (_uniqueInstance = new SingleClass());
        }
    }
}