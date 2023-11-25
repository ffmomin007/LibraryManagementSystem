using LibraryManagementSystem.DataAccess.Repo.Implementation;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.DataAccess.Repo.Interface
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
        void Save();
    }
}
