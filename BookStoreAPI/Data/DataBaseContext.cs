using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<SelectedBook> SelectedBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataBaseSetupManager.Setup(modelBuilder);
        }
    }
}