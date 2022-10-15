using LibraryApi.Models;
using LibraryApi.Models.services;
using LibraryModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
           // if(await _productRepository.GetProducts()==null)
           //     return NotFound();

            return Ok(await _productRepository.GetProducts());
        }

        // GET: api/Students/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                if (await _productRepository.GetProducts() == null)
                {
                    return NotFound();
                }

                var result = await _productRepository.GetProduct(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        // GET: api/Students/search?name=5
        [HttpGet("{search}")]
        public async Task<IEnumerable<Product>> search(string name)
        {
            try
            {
                var students = await _productRepository.Search(name);
                if (students.Any())
                {
                    return students;
                }
                return students;
            }
            catch (Exception)
            {

                throw;
            }
        }


        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<Product> AddProduct(Product product)
        {
            
           return await _productRepository.AddProduct(product);

        }

        [HttpPut]
        // put: api/Products
        public async Task<Product> UpdateProduct(Product product)
        {

            return await _productRepository.UpdateProduct(product);

        }

        [HttpDelete]
        // put: api/Products
        public async Task DeleteProduct(int id)
        {

             await _productRepository.DeleteProduct(id);

        }

        // GET: api/Receipts/GetMostSellingProduct?date=
        [HttpGet("GetMostSellingProduct")]

        public async Task<ActionResult<double>> GetMostSellingProduct(DateTime date)
        {
            var receipt = await _productRepository.GetMostSellingProducts(date);

            return Ok(receipt);
        }



    }
}
