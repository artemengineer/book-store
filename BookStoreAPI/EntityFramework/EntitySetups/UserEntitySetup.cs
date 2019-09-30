using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Data.EntitySetups
{
    public class UserEntitySetup : BaseEntitySetupManager<User>
    {
        public UserEntitySetup(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        public override void Setup()
        {
            Entity.ToTable(nameof(User));
            Entity.HasKey(u => u.Id);
            Entity.Property(u => u.Id).ValueGeneratedOnAdd();
            Entity.Property(u => u.Username).HasMaxLength(50);
            Entity.Property(u => u.PasswordHash);
            Entity.Property(u => u.PasswordSalt);
        }
    }
}