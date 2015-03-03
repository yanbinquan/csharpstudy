using System;

namespace 委托匿名方法
{
    internal class Program
    {
        public delegate void FuncDelegate();

        private static void Main(string[] args)
        {
            //这样我们可以调用第一个方法，
            //Run(Func);
            //但是我们如何调用第二个方法了，这时候我们可以使用匿名方法
            // Run(FuncExt);

            //定义一个委托变量，实现一个匿名方法
            FuncDelegate MyFunc = delegate { Func(10); };
            //由于匿名方法比较灵活使用比较方法，但是还是要写很多代码，就借鉴了函数式编程便有了Lambda表达式
            //语法： 参数=>方法体
            FuncDelegate myFunc2 = () => { Func(20); };
            Run(MyFunc);
            Run(myFunc2);

            Console.ReadKey();
        }

        public static void Run(FuncDelegate target)
        {
            target();
        }

        public static void Func()
        {
            Console.WriteLine("无参数");
        }

        public static void Func(int num)
        {
            Console.WriteLine("数字{0}", num);
        }

        public static void FuncExt()
        {
            Func(10);
        }
    }
}