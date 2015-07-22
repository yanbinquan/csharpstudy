using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 属性
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student();
            student.Id = 3;
            Console.WriteLine(student.Id);
            student.Id = -3;
            Console.WriteLine(student.Id);
            student.Id = -103;
            Console.WriteLine(student.Id);
            Console.ReadLine();
        }
    }

    class Student
    {
        private int _id;
        public int Id
        {
            get { return _id + 100; }
            set { _id = value > 0 ? value : 0; }
        }
    }
}
