using BookStoreAPI.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.EntityFramework.EntitySetups
{
    public class BookEntitySetup : BaseEntitySetupManager<Book>
    {
        public BookEntitySetup(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void Setup()
        {
            Entity.ToTable(nameof(Book));
            Entity.HasKey(b => b.Id);
            Entity.Property(u => u.Id).ValueGeneratedOnAdd();
            Entity.Property(b => b.Author).HasMaxLength(50);
            Entity.Property(b => b.Name);
            Entity.Property(b => b.Description);
        }
    }
}