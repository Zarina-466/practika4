using Microsoft.EntityFrameworkCore;
using Praktos.Model;

namespace Praktos.DatabaseContext
{
    public class TestApiDB : DbContext
    {
        public TestApiDB(DbContextOptions options) : base (options)
        {
            
        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Readers> Readers { get; set; }
        public DbSet<BookRentalHistory> BookRentalsHistory { get; set; }
        public DbSet<Autors> Autors { get; set; }

    }
}
