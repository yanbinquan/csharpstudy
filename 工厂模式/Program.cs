using System;

namespace 简单工厂模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var cf = new CarFactory(); //工厂
            Car c = cf.getCar("BMW");
            if (c != null)
            {
                Console.WriteLine("您好，你的宝马我们已经帮您生产好了，请你有空前来提货并付款！");
            }
            else
            {
                Console.WriteLine("不好意思,恕我无能为力！");
            }
            Console.ReadLine();
        }


        /*
         * 汽车工厂类
         */

        /*
         * 宝马
         */

        private class BMW : Car
        {
            public override void run()
            {
                Console.WriteLine("宝马行驶中");
            }

            public override void stop()
            {
                Console.WriteLine("宝马停车了");
            }
        }

        private class Benz : Car
        {
            public override void run()
            {
                Console.WriteLine("奔驰行驶中");
            }

            public override void stop()
            {
                Console.WriteLine("奔驰停车了");
            }
        }

        private abstract class Car
        {
            /*
             * 开车
             */
            public abstract void run();
            /*
             * 停车
             */
            public abstract void stop();
        }

        private class CarFactory
        {
            /*
             * 生产汽车方法
             */

            public Car getCar(String type)
            {
                Car c = null;
                if ("BMW".Equals(type)) //判断顾客是需要那样的汽车
                {
                    c = new BMW(); //生产宝马汽车
                }
                else if ("Benz".Equals(type))
                {
                    c = new Benz(); //生产奔驰
                }
                return c;
            }
        }
    }
}