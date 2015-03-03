using System;
using System.Reflection;

namespace 反射
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //GetProperties();
            //TRef();
            Console.Read();
        }

        public static void GetProperties()
        {
            var dt = new DateTime();
            Type type = dt.GetType(); //GetType()，获得与原始对象对应的System.Type的一个实例

            foreach (PropertyInfo item in type.GetProperties()) //获取属性
            {
                Console.WriteLine(item.Name);
            }
        }

        public static void TRef()
        {
            Type type;
            type = typeof (Nullable<>);
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
                Type t = typeof (T);
            }
        }
    }
}