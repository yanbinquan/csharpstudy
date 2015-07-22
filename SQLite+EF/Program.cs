using System;
using System.Data.Entity;
using System.Linq;

namespace SQLite_EF
{
    class Program
    {
        static void Main()
        {
            var context = new UserContext();
            var user = new User { Name = "张三" };
            var ss = context.User.Add(user);
            context.SaveChanges();
            var empList = context.User.OrderBy(c => c.Id).ToList();
            Console.WriteLine(empList.Count);
            Console.ReadLine();
        }
    }

    public class UserContext : DbContext
    {
        public DbSet<User> User { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
