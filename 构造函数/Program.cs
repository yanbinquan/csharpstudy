using System;

namespace 构造函数
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var person = new Person(1, "Lucy");
            Console.ReadLine();
        }
    }

    public class Person
    {
        public int Age;
        public string Name;

        public Person(int age)
        {
            Age = age;
            Console.WriteLine("age=" + age);
        }

        public Person(int age, string name): this(age)
        {
            age += 1;
            Console.WriteLine("age=" + age + ";name=" + name);
        }
    }
}