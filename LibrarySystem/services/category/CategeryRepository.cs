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
        public async Task DeleteCategory(int CategoryID)
        {
            Category? category = _appDbContext.Categories.Find(CategoryID);
            if (category != null)
                _appDbContext.Categories.Remove(category);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _appDbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategory(int id)
        {
            Category? category =await _appDbContext.Categories.FirstOrDefaultAsync(c=>c.id==id);
            return category;

        }

        public async Task<Category> AddCategory(Category category)
        {
            _appDbContext.Categories.Add(category);
            await _appDbContext.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> Search(string name)
        {
            IQueryable<Category> categories = _appDbContext.Categories;

            if (name != null)
            {
                categories = categories.Where(c => c.name!.Contains(name));
            }

            return await categories.ToListAsync();
        }

        public async Task<Category> UpdateCategory(Category Category)
        {
            _appDbContext.Entry(Category).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return Category;
        }
    }
}
