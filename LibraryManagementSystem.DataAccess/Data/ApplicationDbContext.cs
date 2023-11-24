using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1,Name="History",DisplayOrder=1},
                new Category { Id=2,Name="Novel",DisplayOrder=2},
                new Category { Id=3,Name="Programming",DisplayOrder=3}

                );
        }
        public DbSet<Category> Categories { get; set; }
    }
}
