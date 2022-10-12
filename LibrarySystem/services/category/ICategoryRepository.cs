using LibraryModel;

namespace LibraryApi.services.category
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category?> GetCategory(int id);
        Task<IEnumerable<Category>> Search(string name);
        Task<Category> InsertCategory(Category Category);
        Task DeleteCategory(int CategoryID);
        Task<Category> UpdateCategory(Category Category);
    }
}
