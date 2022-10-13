using LibraryModel;

namespace LibraryApi.Models.services
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product?> GetProduct(int id);
        Task<IEnumerable<Product>> Search(string name);
        Task<Product> AddProduct(Product product);
        Task DeleteProduct(int productID);
        Task<Product> UpdateProduct(Product product);
    }
}
