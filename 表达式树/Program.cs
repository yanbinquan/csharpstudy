using System.Collections.Generic;

namespace 表达式树
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var custs = new List<Customer>
            {
                new Customer {City = 1},
                new Customer {City = 2}
            };
            var list = new List<string>
            {
                "田三涛",
                "刘起涵",
                "张晓轩",
                "田圣彤",
                "文筠彤",
                "刘起涵",
                "田优乔",
                "文嘉珊",
                "白田彤",
                "廖子棉",
                "张泽菲",
                "田赞鑫"
            };
            List<string> result = list.FindAll(s => s.IndexOf("田") == 0);
        }
    }

    public class Customer
    {
        public int City { set; get; }
    }
}