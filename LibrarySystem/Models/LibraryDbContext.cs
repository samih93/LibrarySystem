
using LibraryModel;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Models
{
    public class LibraryDbContext :DbContext
    {
        protected readonly IConfiguration Configuration;

        public LibraryDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("LibraryDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetailsReceipt>().HasKey(dr => new { dr.productId, dr.receiptId });
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<DetailsReceipt> DetailsReceipts{ get; set; }
        public DbSet<Category> Categories { get; set; }













    }
}
