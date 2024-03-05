using AnotherTest.Models;
using Dumpify;
using NUnit.Framework;

namespace AnotherTest
{
    public class DbTest
    {
        DatabaseContext db = new();

        [Test]
        public void AddDan()
        {
            db.Add(new YourEntity(){ Name = "Dan", Age = 29 });

            List<int> x = new List<int>() { 1,3,5,7,89};

            db.YourEntities.Dump();

            db.SaveChanges();
        }

        [Test]
        public void RemoveDan()
        {
            var dan = db!.YourEntities!.Where(e => e.Name == "Dan").FirstOrDefault();

            db!.Remove(dan!);
            db.SaveChanges();
        }
    }
}