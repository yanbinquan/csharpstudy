using System;

namespace 枚举与位运算
{
    internal class Program
    {
        private static void Main()
        {
            var per = Permissions.Insert | Permissions.Update;
            if ((per & Permissions.Insert) == Permissions.Insert)
            {
                Console.WriteLine("yes:" + per);
            }
            else
            {
                Console.WriteLine("no:" + per);
            }
            Console.ReadLine();
        }

        [Flags]
        public enum Permissions
        {
            Insert = 1,
            Delete = 2,
            Update = 4,
            Query = 8
        }
    }
}