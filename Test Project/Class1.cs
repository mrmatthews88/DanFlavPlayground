using Microsoft.EntityFrameworkCore;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Project.Database;

namespace Test_Project
{
    internal class Class1
    {
        [Test]
        public void Test()
        {
            var ctx = new DatabaseContext();

            var data = ctx.YourEntities.ToList();
            ctx.YourEntities.RemoveWhere(x => x.Name == "Sarah");
            ctx.SaveChanges();

            var a = 1;
            Assert.AreEqual(1, a);
        }
    }


    public static class DbExtensions
    {
        public static void RemoveWhere<T>(this DbSet<T> dbSet, Func<T, bool> predicate) where T : class
        {
            dbSet.RemoveRange(dbSet.Where(predicate));
        }
    }
}
