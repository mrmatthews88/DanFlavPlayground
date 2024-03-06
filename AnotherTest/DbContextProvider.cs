
using AnotherTest.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AnotherTest
{
    public static class DbContextProvider
    {
        public static T LazyLoading<T>() where T : DbContext, new()
        {
            var options = new DbContextOptionsBuilder<T>().UseLazyLoadingProxies().Options;
            return (T)Activator.CreateInstance(typeof(T), options);
        }


        public static T Standard<T>() where T : DbContext, new()
        {
            return new T();
        }
    }
}