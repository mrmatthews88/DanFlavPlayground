using AnotherTest.Models;
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