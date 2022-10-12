using LibraryApi.services.category;
using LibraryModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository) {
            _categoryRepository = categoryRepository; 
        }

        // GET: api/categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetProducts()
        {
            // if(await _productRepository.GetProducts()==null)
            //     return NotFound();

            return Ok(await _categoryRepository.GetCategories());
        }
    }
}
