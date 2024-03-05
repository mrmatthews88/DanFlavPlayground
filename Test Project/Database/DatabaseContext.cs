using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Project.Database
{
    internal class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=your_database.db");
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FlatDanTestDb;Trusted_Connection=True;");
        }


        public DbSet<YourEntity> YourEntities { get; set; }

    }

    internal class YourEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        // Add other properties as needed
    }
}
