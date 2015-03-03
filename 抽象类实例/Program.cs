using System;

namespace 抽象类实例
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var np = new NormalPlayer {WeekSalary = 700};
            Console.WriteLine(np.GetSalary());
            Console.ReadLine();
        }

        public abstract class BasePlayer
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public string GetFullName()
            {
                return FirstName + " " + LastName;
            }

            public abstract decimal GetSalary();
        }

        public class NormalPlayer : BasePlayer
        {
            public decimal WeekSalary { get; set; }
            //获取日薪
            public override decimal GetSalary()
            {
                return WeekSalary/7;
            }
        }

        public class SubPlayer : BasePlayer
        {
            public decimal MonthSalary { get; set; }
            //获取周薪
            public override decimal GetSalary()
            {
                return MonthSalary/4;
            }
        }
    }
}