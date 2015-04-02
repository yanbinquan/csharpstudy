using System;
using System.Linq;
using System.Reflection;

namespace 反射
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GetProperties();
            Console.WriteLine("========分割线========");
            Ref();
            Console.Read();
        }

        public static void GetProperties()
        {
            var dt = new DateTime();
            var type = dt.GetType(); //GetType()，获得与原始对象对应的System.Type的一个实例

            foreach (var item in type.GetProperties().OrderBy(p=>p.GetType().Name)) //获取属性
            {
                Console.WriteLine(item.Name);
            }
        }

        public static void Ref()
        {
            var type = typeof (Nullable<>);
            Console.WriteLine(type.ContainsGenericParameters);
            Console.WriteLine(type.IsGenericType); //是否泛型

            type = typeof (DateTime?);
            Console.WriteLine(type.ContainsGenericParameters);
            Console.WriteLine(type.IsGenericType);
        }

        public class Stack<T>
        {
            public void Add(T i)
            {
                var t = typeof (T);
            }
        }
    }
}