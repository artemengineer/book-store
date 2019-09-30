using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Data.EntitySetups
{
    public class SelectedBookEntitySetup : BaseEntitySetupManager<SelectedBook>
    {
        public SelectedBookEntitySetup(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void Setup()
        {
            Entity.ToTable(nameof(SelectedBook));

            Entity.HasKey(s => new {s.UserId, s.BookId});

            Entity.HasOne(s => s.User)
                .WithMany(d => d.SelectedBooks)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            Entity.HasOne(s => s.Book)
                .WithMany(d => d.SelectedBooks)
                .HasForeignKey(s => s.BookId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}