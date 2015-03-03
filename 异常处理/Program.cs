using System;
using System.Data.SqlClient;

namespace 异常处理
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var result = Prase("three");
                Console.WriteLine(result);
            }
            catch (DataBaseException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadLine();
        }

        public static int Prase(string text)
        {
            string[] digitext = {"zero", "one", "two"};
            var result = Array.IndexOf(digitext, text);
            if (result < 0)
            {
                throw new SystemException("SystemException");
            }
            return result;
        }

        //自定义异常
        private class DataBaseException : SystemException
        {
            public DataBaseException(SqlException ex)
            {
            }
        }
    }
}