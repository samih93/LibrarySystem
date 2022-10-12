using LibraryApi.Models;
using LibraryModel;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.services.category
{
    public class CategeryRepository : ICategoryRepository

    {
        private readonly LibraryDbContext _appDbContext;


        public CategeryRepository(LibraryDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Task DeleteCategory(int CategoryID)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _appDbContext.Categories.ToListAsync();
        }

        public Task<Category?> GetCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> InsertCategory(Category Category)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> Search(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateCategory(Category Category)
        {
            throw new NotImplementedException();
        }
    }
}
