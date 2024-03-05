using AnotherTest.Database;
using Microsoft.EntityFrameworkCore;

namespace AnotherTest
{
    public static class DbContextProvider
    {
        public static DatabaseContext LazyLoading()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>().UseLazyLoadingProxies().Options;
            return new DatabaseContext(options);
        }

        public static DatabaseContext Standard()
        {
            return new DatabaseContext();
        }
    }
}