using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStoreAPI.EntityFramework
{
    public abstract class BaseEntitySetupManager<TEntity> where TEntity : class
    {
        private readonly ModelBuilder _modelBuilder;

        public EntityTypeBuilder<TEntity> Entity => _modelBuilder.Entity<TEntity>();

        protected BaseEntitySetupManager(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public abstract void Setup();
    }
}