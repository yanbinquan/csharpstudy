using System;

namespace Ref和Out
{
    /// <summary>
    /// ref传递的参数必须赋值在使用（在外赋值）
    /// out可以只声明不赋值，但是在方法体内必须赋值（在内赋值）
    /// </summary>
    class Program
    {
        static void Main()
        {
            int[] arr = { 56, 31, 2, 89, 76 };
            int sum = 0, max = 0, min = 0;

            int[] arr2 = { };
            int sum2, max2, min2;

            GetValueRef(arr, ref sum, ref max, ref min);
            Console.WriteLine("Ref：总和：" + sum + ",最大值：" + max + ",最小值：" + min);

            GetValueOut(arr2, out sum2, out max2, out min2);
            Console.WriteLine("Out：总和：" + sum2 + ",最大值：" + max2 + ",最小值：" + min2);

            Console.ReadLine();
        }

        public static void GetValueRef(int[] arr, ref int sum, ref int max, ref int min)
        {
            sum = 0;
            max = arr[0];
            min = arr[0];

            foreach (var t in arr)
            {
                sum += t;
                if (max < t)
                {
                    max = t;
                }
                if (min > t)
                {
                    min = t;
                }
            }
        }

        public static void GetValueOut(int[] arr, out int sum, out int max, out int min)
        {
            if (arr == null) throw new ArgumentNullException("arr");
            arr = new[] { 56, 31, 2, 89, 76 };
            sum = 0;
            max = arr[0];
            min = arr[0];

            foreach (var t in arr)
            {
                sum += t;
                if (max < t)
                {
                    max = t;
                }
                if (min > t)
                {
                    min = t;
                }
            }
        }
    }
}
