using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace return和finally
{
    /// <summary>
    /// 如果try语句里有return，那么代码的行为如下：
    ///1.如果有返回值，就把返回值保存到局部变量中
    ///2.执行jsr指令跳到finally语句里执行
    ///3.执行完finally语句后，返回之前保存在局部变量表里的值
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            var y = aaa();
            Console.WriteLine(y);
            Console.ReadLine();
        }

        public static int aaa()
        {
            var x = 1;
            try
            {
                return ++x;
            }
            catch (Exception e)
            {
            }
            finally
            {
                ++x;
            }
            return x;
        }
    }
}