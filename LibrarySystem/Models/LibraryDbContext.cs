
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

        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Facture> Factures { get; set; }
        public DbSet<DetailsFacture> DetailsFactures { get; set; }
        public DbSet<Category> Categories { get; set; }













    }
}
