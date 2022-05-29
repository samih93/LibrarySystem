using LibraryModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Models.product
{
    public class ProductRepository : IProductRepository
    {
        private readonly LibraryDbContext _appDbContext;



        public ProductRepository(LibraryDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

      
        public async Task<Product?> GetProduct(int id)
        {
            Product? Product = await _appDbContext.Products.FirstOrDefaultAsync(e => e.Id == id);

            return Product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            
            return await _appDbContext.Products.ToListAsync();
        }

      
        public async Task<IEnumerable<Product>> Search(string name)
        {
            IQueryable<Product> Products = _appDbContext.Products!;

            if (name != null)
            {
                Products = Products.Where(e => e.Name!.Contains(name));
            }

            return await Products.ToListAsync();

        }


        public async Task<Product> InsertProduct(Product product)
        {
            _appDbContext.Products.Add(product);
            await _appDbContext.SaveChangesAsync();
            return product;
                
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _appDbContext.Entry(product).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return product;

        }

        public  async Task DeleteProduct(int productID)
        {
            Product? product = _appDbContext.Products.Find(productID);
            if(product!=null)
            _appDbContext.Products.Remove(product);
            await _appDbContext.SaveChangesAsync();


        }

    }
}
