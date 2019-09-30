using BookStoreAPI.EntityFramework.EntitySetups;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.EntityFramework
{
    public static class DataBaseSetupManager
    {
        public static void Setup(ModelBuilder modelBuilder)
        {
            new UserEntitySetup(modelBuilder).Setup();
            new BookEntitySetup(modelBuilder).Setup();
            new SelectedBookEntitySetup(modelBuilder).Setup();
        }
    }
}