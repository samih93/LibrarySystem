using LibraryApi.helper;
using LibraryModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryApi.Models.services
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
            Product? Product = await _appDbContext.Products.Include(p=>p.Category).FirstOrDefaultAsync(e => e.id == id);

            return Product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            
            return await _appDbContext.Products.Include(c=>c.Category).ToListAsync();
        }

      
        public async Task<IEnumerable<Product>> Search(string name)
        {
            IQueryable<Product> Products = _appDbContext.Products!.Include(p => p.Category);

            if (name != null)
            {
                Products = Products.Where(e => e.name!.Contains(name));
            }

            return await Products.ToListAsync();

        }


        public async Task<Product> AddProduct(Product product)
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

        public async Task<List<Product>> GetMostSellingProducts(DateTime? date=null)
        {
            List<Product> products = new List<Product>();
            //if date null we need set current month
            DateTime currentdate = ((DateTime)date).Year!=1 ? (DateTime) date :   DateTime.Now;



            //query =    ($"select p.id , p.name, sum(dr.qty) as qty from Products as p join DetailsReceipts as dr on p.id=dr.productId join Receipts as r on r.id=dr.receiptId " +
            // $"where MONTH(r.receiptDate) = {d.Month} and  YEAR(r.receiptDate) = {d.Year}" +
            //"group by p.id, p.name order by qty desc", x => new Product { name = (string)x[1], qty = (int)x[2] });


            /// get list of selling product group by product id 
            var query = (from product in this._appDbContext.Products
             from dr in this._appDbContext.DetailsReceipts
             from r in this._appDbContext.Receipts
             where product.id == dr.productId && dr.receiptId == r.id
             where r.receiptDate.Year == currentdate.Year && r.receiptDate.Month == currentdate.Month
             select new { id = product.id, productname = product.name, qty = dr.qty }).AsEnumerable().GroupBy(c => c.id).Take(10);


            // loop to get the total sum of qty for each product
            foreach (var item in query)
            {
                var groupKey = item.Key;
                double qty = 0;
                Product p = new Product();
                foreach (var subitem in item)
                {

                    p.id = subitem.id;
                    p.name = subitem.productname;
                    
                    qty += subitem.qty;
                   
                }
                p.qty = qty;
                products.Add(p);
                // order by qty 
                products = products.OrderByDescending(e => e.qty).ToList();

            }


            return products;
        }
    }
}
