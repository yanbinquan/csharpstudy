using System;

namespace 委托传参
{
    internal class Program
    {
        public delegate void FuncDelagete();

        private static void Main(string[] args)
        {
            //将方法作为一个参数，传到另一个方法中执行，那么另一方法就可以作为一个执行的载体，他不管具体要干什么，只考虑自己的独有逻辑，可变化的方法有传入的方法执行
            // FuncDelagete myFunc = new FuncDelagete(Func);
            //Chinese(myFunc);
            Chinese(Func);

            //方法作为参数传递-回调函数.在回调函数里面私有方法照样被访问,
            var mc = new MyClassCol();
            mc.Initialize();
            mc.Run();

            Console.ReadKey();
        }

        public static void Func()
        {
            Console.WriteLine("钓鱼岛是我们的，就是我们的参数，我们要传到中国去");
        }

        public static void Chinese(FuncDelagete target)
        {
            if (target != null)
            {
                target();
            }
        }

        //这个类实现回调
        private class MyClass
        {
            private FuncDelagete target;

            public FuncDelagete Target
            {
                get { return target; }
                set { target = value; }
            }

            public void Run()
            {
                if (target != null)
                {
                    target();
                }
            }
        }

        private class MyClassCol
        {
            private MyClass m;

            public void Initialize()
            {
                m = new MyClass();
                m.Target = Func;
            }

            public void Run()
            {
                m.Run();
            }

            private void Func()
            {
                Console.WriteLine("我是回调方法");
            }
        }
    }
}