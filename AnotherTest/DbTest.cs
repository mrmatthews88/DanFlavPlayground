using AnotherTest.Models;
using Dumpify;
using NUnit.Framework;
using AnotherTest.Database;
using Bogus;

namespace AnotherTest
{

    public class DbTest
    {
        DatabaseContext db = new();

        [Test]
        public void AddDan()
        {


            db.Add(new YourEntity() { Name = "Dan", Age = 29 });

            List<int> x = new List<int>() { 1, 3, 5, 7, 89 };

            var result = db.Dump(tableConfig: new TableConfig { ShowRowSeparators = true, ShowMemberTypes = true });

            db.SaveChanges();
        }

        [Test]
        public void RemoveDan()
        {
            var dan = db!.YourEntities!.Where(e => e.Name == "Dan").FirstOrDefault();

            db!.Remove(dan!);
            db.SaveChanges();
        }

        [Test]
        public void SomeTestData()
        {
            for (int i = 0; i < 10; i++)
            {
                Faker faker = new Faker();
                string userName = faker.Name.FullName().ToString()!;
                var user = new User
                {
                    UserName = userName!,
                    Email = faker.Internet.Email().ToString(),
                };
                db.Users.Add(user);
                db.SaveChanges();

                Article article = new Article
                {
                    User = user,
                    Title = "My Article Title",
                    Content = "Content of my Article",
                    Comments = new List<Comment>
                {
                    new Comment {User = user,  CreatedAt = DateTime.Now, Text = "Something" },
                    new Comment {User = user, CreatedAt = DateTime.Now, Text = "Something2" },
                    new Comment {User = user, CreatedAt = DateTime.Now, Text = "Something3" }
                },
                    TagsTags = new List<Tag>
                {
                    new Tag { Name = "Tag 1" },
                    new Tag { Name = "Tag 2" }
                }
                };

                db.Articles.Add(article);
                db.SaveChanges();
            }
        }

        [Test]
        public void LazyLoading()
        {
            // i made this helper class to enable lazy loading if you want it normally this would go into the DbContext
            // but i made this incase you have to re-generate the db context, that would remove the code to add lazy loading
            // by using a provider helper class we can setup any additional DB options we want and like i have done here you can get a DB context for some pre-set options
            var db1 = DbContextProvider.LazyLoading<DatabaseContext>();
            var db2 = DbContextProvider.Standard<DatabaseContext>();

            // this shows all the related entities loading with lazy loading
            var data1 = db1.Users.ToList().Dump();

            //This shows it without lazy loading
            //var data2 = db2.Users.ToList().Dump();
            ;
        }
    }
}