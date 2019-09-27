using BookStoreAPI.Data.EntitySetups;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Data
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