using System;
using System.Linq.Expressions;

namespace Lambda_Tree
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var loop = Expression.Loop(
                Expression.Call(
                    null,
                    typeof (Console).GetMethod("WriteLine", new[] {typeof (string)}),
                    Expression.Constant("Hello"))
                );

            // 创建一个代码块表达式包含我们上面创建的loop表达式
            var block = Expression.Block(loop);

            // 将我们上面的代码块表达式
            var lambdaExpression = Expression.Lambda<Action>(block);
            lambdaExpression.Compile().Invoke();
            //Console.WriteLine(lambdaExpression.ToString());
           // Console.ReadLine();
        }
    }
}