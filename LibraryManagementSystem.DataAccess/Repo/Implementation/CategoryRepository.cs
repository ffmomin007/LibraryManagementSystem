using LibraryManagementSystem.DataAccess.Data;
using LibraryManagementSystem.DataAccess.Repo.Interface;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.DataAccess.Repo.Implementation
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}
