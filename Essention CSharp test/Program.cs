using System;

namespace Essention_CSharp_test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            #region 引用类型

            //string txt=null;
            //var txt2 = txt;
            //Console.WriteLine(txt);

            #endregion

            #region 可空修饰符

            //int? count = null;
            //if (count == null)
            //{
            //    Console.WriteLine("null");
            //}
            //else
            //{
            //    Console.WriteLine("not null");
            //}

            #endregion

            #region 显示转换

            //checked
            //{
            //    long a = long.MaxValue;
            //    int b = (int)a;
            //    Console.WriteLine(b);
            //}

            #endregion

            #region 空结合运算符

            //checked
            //{
            //    string a = null;
            //    string b = a ?? "c";
            //    Console.WriteLine(b);
            //}

            #endregion

            #region 属性验证

            //Employee employee = new Employee();
            //employee.Initialize("aaa");
            ////employee.FirstName = "aaa";
            //Console.WriteLine(employee.FirstName);

            #endregion

            #region 聚合

            //Content content = new Content();
            //content.internalperson = new Person();
            //content.Name = "Yao Ming";
            //Console.WriteLine(content.internalperson.FirstName);

            #endregion

            #region 封箱拆箱

            var angel = new Angel();
            angel._Hours = 10;
            object objectAngel = angel;
            Console.WriteLine(((Angel) objectAngel)._Hours);

            ((Angel) objectAngel).MoveTo(12);
            Console.WriteLine(((Angel) objectAngel)._Hours);

            ((IAngel) angel).MoveTo(12);
            Console.WriteLine(angel._Hours);

            ((IAngel) objectAngel).MoveTo(12);
            Console.WriteLine(((Angel) objectAngel)._Hours);

            #endregion

            Console.Read();
        }
    }

    internal interface IAngel
    {
        void MoveTo(int hours);
    }

    internal struct Angel : IAngel
    {
        public int _Hours { set; get; }

        public void MoveTo(int hours)
        {
            _Hours = hours;
        }
    }

    internal class PadItem
    {
        public string LastName { set; get; }
    }

    internal class Person
    {
        public string FirstName { set; get; }
    }

    internal class Content : PadItem
    {
        public Person internalperson { set; get; }

        public string Name
        {
            get { return internalperson.FirstName + "_" + LastName; }
            set
            {
                string[] names = value.Split(' ');
                internalperson.FirstName = names[0];
                LastName = names[1];
            }
        }
    }

    internal class Employee
    {
        private string _LastName;

        public string FirstName
        {
            get { return _LastName; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException();
                }
                _LastName = value;
            }
        }

        public void Initialize(string newfirstname)
        {
            FirstName = newfirstname;
        }
    }
}