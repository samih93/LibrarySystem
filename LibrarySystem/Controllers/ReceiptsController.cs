using LibraryApi.services.receipt;
using LibraryModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptsController : ControllerBase
    {

        private readonly IReceiptRepository _receiptRepository;

        public ReceiptsController(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }
        // GET: api/Receipts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receipt>>> GetReceipts()
        {

            return Ok(await _receiptRepository.GetReceipts());
        }

        // POST: api/Receipts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<Receipt> InsertReceipt(Receipt receipt)
        {

            return await _receiptRepository.AddReceipt(receipt);

        }

        // GET: api/Receipts/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Receipt>> GetReceipt(int id)
        {
            try
            {
                if (await _receiptRepository.GetReceipts() == null)
                {
                    return NotFound();
                }

                var result = await _receiptRepository.GetReceipt(id);

                if (result == null) return NotFound();

                return  result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

    }
}
