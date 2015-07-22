using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace 生成动态查询
{
    class Program
    {
        static void Main()
        {
            var myArticleList = new List<MyArticle>
            {
                new MyArticle {Views = 1000,Published = Convert.ToDateTime("2015-06-01")},
                new MyArticle {Views = 400,Published = Convert.ToDateTime("2015-06-11")}
            };
            var results = Extention<MyArticle>.MySearchList(myArticleList.AsQueryable(), new MyArticle
            {
                Views = 500,
                Published = Convert.ToDateTime("2015-06")
            });
            foreach (var article in results) Console.WriteLine("发布日期:" + article.Published + "，浏览数：" + article.Views + "");
            Console.ReadLine();
        }
    }

    public class Extention<T>
    {
        public static IQueryable<T> MySearchList(IQueryable<T> myArticleTable, T myArticle)
        {  
            var myart = Expression.Parameter(typeof(T)); 
            
            Expression left = Expression.Property(myart, typeof(T).GetProperty("Published")); //访问属性的表达式
            Expression right = Expression.Property(Expression.Constant(myArticle), typeof(T).GetProperty("Published"));//访问属性的表达式
            Expression e1 = Expression.GreaterThanOrEqual(left, right); //大于等于
            
            Expression left2 = Expression.Property(myart, typeof(T).GetProperty("Views")); //访问属性的表达式
            Expression right2 = Expression.Property(Expression.Constant(myArticle), typeof(T).GetProperty("Views"));//访问属性的表达式
            Expression e2 = Expression.GreaterThanOrEqual(left2, right2);

           Expression predicateBody = Expression.AndAlso(e1, e2);

          var whereCallExpression = Expression.Call(
            typeof(Queryable),
            "Where",
            new[] { typeof(T) },
            myArticleTable.Expression,
            Expression.Lambda<Func<T, bool>>(predicateBody, new[] { myart }));

            //构造排序
            var orderByCallExpression = Expression.Call(
            typeof(Queryable),
            "OrderByDescending",
            new[] { typeof(T), typeof(int) },
            whereCallExpression,
            Expression.Lambda<Func<T, int>>(left2, new[] { myart }));

            //创建查询表达式树
            var results = myArticleTable.Provider.CreateQuery<T>(orderByCallExpression);

            return results;
        }
    }

    public class MyArticle
    {
        public DateTime Published { get; set; }
        public int Views { get; set; }
    }
}