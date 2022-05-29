using LibraryModel;

namespace LibraryApi.Models.product
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product?> GetProduct(int id);
        Task<IEnumerable<Product>> Search(string name);
        Task<Product> InsertProduct(Product product);
        Task DeleteProduct(int productID);
        Task<Product> UpdateProduct(Product product);
    }
}
